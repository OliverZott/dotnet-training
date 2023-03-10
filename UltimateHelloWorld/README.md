# Ultime Hello World App

[Youtube](https://www.youtube.com/watch?v=dZSLm4tOI8o)

Best practices - and why they are not always good

- DRY
- SOLID
- Logging
- Dependency Injection
- Localization
- Separation of Concerns
- Unit Testing

## Run

- `cd \UltimateHelloWorld\bin\Debug\net6.0>`
- `.\UltimateHelloWorld.exe lang=it`

## Steps

- .NET 6 Console App
- Create Class Library (e.g. for business logic)) `HelloWorldLibrary`
  - Define Data: `CustomText.json` (properties - CopyIfNever)
  - Model
- DI
- XUnit tests

## Remarks

- Resource file - copy to output
- Json Deserializer
- Command Line args
  - [docs](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.commandlineconfigurationextensions.addcommandline?view=dotnet-plat-ext-6.0)
