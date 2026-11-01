<#
.SYNOPSIS
Rebuilds the initial EF Core migration for all database providers.
.DESCRIPTION
Deletes each provider's Migrations directory, including its model snapshot,
and generates a new InitialCreate migration from the current EvaluatorContext.
This resets migration source history only; it does not update any databases.
Requires the .NET SDK and dotnet-ef matching the project's EF Core version.
.EXAMPLE
.\scripts\Rebuild-InitialMigration.ps1 -WhatIf
.EXAMPLE
.\scripts\Rebuild-InitialMigration.ps1
#>
[CmdletBinding(SupportsShouldProcess = $true)]
param()

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$repositoryRoot = Split-Path -Parent $PSScriptRoot
$providers = @('Sqlite', 'SqlServer', 'PostgreSql')
$projects = foreach ($provider in $providers) {
    $projectName = "EvaluatorX.Migrations.$provider"
    $projectDirectory = Join-Path $repositoryRoot "src\$projectName"
    $projectPath = Join-Path $projectDirectory "$projectName.csproj"

    if (-not (Test-Path -LiteralPath $projectPath -PathType Leaf)) {
        throw "Migration project not found: $projectPath"
    }

    [pscustomobject]@{
        Provider = $provider
        Path = $projectPath
        MigrationsDirectory = Join-Path $projectDirectory 'Migrations'
    }
}

if (-not $PSCmdlet.ShouldProcess(
    'Sqlite, SqlServer and PostgreSql migration projects',
    'Replace all migration source history with a new InitialCreate migration'
)) {
    return
}

Push-Location -LiteralPath $repositoryRoot
try {
    & dotnet ef --version
    if ($LASTEXITCODE -ne 0) {
        throw 'dotnet-ef is unavailable. Install a version matching Microsoft.EntityFrameworkCore.Design in Directory.Packages.props.'
    }

    # Verify all projects build before deleting any migration source.
    foreach ($project in $projects) {
        & dotnet build $project.Path
        if ($LASTEXITCODE -ne 0) {
            throw "Build failed for $($project.Provider). Migration source has not been deleted."
        }
    }

    foreach ($project in $projects) {
        Write-Host "Rebuilding the initial migration for $($project.Provider)..."

        if (Test-Path -LiteralPath $project.MigrationsDirectory) {
            Remove-Item -LiteralPath $project.MigrationsDirectory -Recurse -Force
        }

        $efArguments = @(
            'ef', 'migrations', 'add', 'InitialCreate'
            '--project', $project.Path
            '--startup-project', $project.Path
            '--context', 'EvaluatorX.Data.EvaluatorContext'
            '--output-dir', 'Migrations'
        )

        & dotnet @efArguments
        if ($LASTEXITCODE -ne 0) {
            throw "Migration generation failed for $($project.Provider). Review its Migrations directory before retrying."
        }
    }

    Write-Host 'Initial migrations rebuilt for all providers. No databases were modified.'
}
finally {
    Pop-Location
}
