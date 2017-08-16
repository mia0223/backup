param(
 [string] $sqlFile,
 [string] $ResourceAccessProjectPath,
 [string] $packagePath

)

[string] $efCoreTool = Join-Path -Path "$packagePath" -ChildPath "Microsoft.EntityFrameworkCore.Tools.1.1.1\tools\net451\ef.exe"
& $efCoreTool migrations script -o "$sqlFile" -i -a "$ResourceAccessProjectPath" -s "$ResourceAccessProjectPath"