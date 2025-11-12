/* 
dotnet run .\hello.cs
dotnet .\hello.cs

dotnet run .\hello.cs "Ahoi =)"
*/


// Packages and  Properties with ignore-directives
#:package Humanizer@2.14.1
#:project MyLib/MyLib.csproj
// #:property TargetFramework=net9.0

using Humanizer;
using MyLib;

var message = args.FirstOrDefault() ?? "Hello there :)";

Console.WriteLine(message);

// package usage
Console.WriteLine(TimeSpan.FromDays(2).Humanize());


// file-based still compiled!!!
Console.WriteLine($"Current directory: {Environment.CurrentDirectory}");
Console.WriteLine($"Base directory: {AppContext.BaseDirectory}");
Console.WriteLine($"File Path: {AppContext.GetData("EntryPointFilePath")}");


// Project References
var greeter = new Greeter();
Console.WriteLine(Greeter.Greet("there"));