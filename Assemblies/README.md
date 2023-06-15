# Assemblies Example

How to reference projects/nugets in dotnet core.


## Run

Project Reference:
- add project reference inside Assembly.Executable (in .csproj file or via vs2022)	
- `dotnet run` to start the console app (inside project folder)

Nuget Reference:
- generate nuget:
	- `nuget pack .\lib.nuspec` to create nuget (inside project folder)
- add local feed in nuget packet manager (VS 2022)
- add nuget reference inside Assembly.Executable (in .csproj file or via nuget package manager)	


## Prerequisites

- install nuget CLI:
	- `winget search nuget` `winget install -e --id Microsoft.NuGet`
    - https://winget.run/pkg/Microsoft/NuGet
	- https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-nuget-cli
- copy dll to lib folder or reference build folder
- 


## TODO

- change lib folder path to the debug build? whats best practice?