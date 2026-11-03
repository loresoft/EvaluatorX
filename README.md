# EvaluatorX

Performance reviews, simplified

## Debugging Arbiter from source

Clone [Arbiter](https://github.com/loresoft/Arbiter) beside this repository (`..\Arbiter`) and open
`EvaluatorX.Debug.slnx`. When built from that solution, `src\Directory.Build.targets` replaces the
`Arbiter.*` package references with project references to the local source. `EvaluatorX.slnx` always
uses the NuGet packages.

Override with `-p:UseArbiterSource=true|false` or point to another clone with `-p:ArbiterSourcePath=<path>\src`.
