# README

file-based C# is still compiled and NOT only interpreted! So it still generates bin/ob output/artifacts.

## Prerequisites

- in settings: "file-based" enabled
- global.json with sdk version 10 defined

- <https://www.nuget.org/packages/humanizer/>

## packages - ignored directives

- `#:` is an ignored directive for package references/püroperties...
- this was only c# language specification chnage in C#14 !! Allows C# to ignore everything after that line

## linux with shebang

## debugging

- set breakpoint
- in vs code press F5 -> C# -> file-based script

## inlcude pojects

- `#:project MyLib/MyLib.csproj`
