@echo off

.nuget\nuget.exe install FAKE -OutputDirectory packages -ExcludeVersion -Version 2.10.24

.nuget\nuget.exe install FSharp.Formatting.CommandTool -OutputDirectory packages -ExcludeVersion  -nocache -prerelease

if not exist packages\SourceLink.Fake\tools\SourceLink.fsx ( 
  .nuget\nuget.exe install SourceLink.Fake -OutputDirectory packages -ExcludeVersion
)

cls

set encoding=utf-8
packages\FAKE\tools\FAKE.exe build.fsx %*


