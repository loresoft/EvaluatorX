# EvaluatorX

Performance reviews, simplified

## Rebuilding initial migrations

Use [Rebuild-InitialMigration.ps1](scripts/Rebuild-InitialMigration.ps1) to replace
the migration history for SQLite, SQL Server, and PostgreSQL with a new
`InitialCreate` migration based on the current `EvaluatorContext`.

Requires the .NET SDK and `dotnet-ef` matching the
`Microsoft.EntityFrameworkCore.Design` version in `Directory.Packages.props`.
If needed, install the tool with `dotnet tool install --global dotnet-ef --version <version>`.

```powershell
# Preview without changing files.
.\scripts\Rebuild-InitialMigration.ps1 -WhatIf

# Rebuild all three providers.
.\scripts\Rebuild-InitialMigration.ps1
```

The script can run from any working directory. It deletes each provider's entire
`Migrations` directory, including the model snapshot, before generating its new
migration. Use only when intentionally resetting migration history, not for
incremental schema changes or databases with existing applied migrations.
It does not connect to, update, or delete databases.
