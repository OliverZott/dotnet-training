using Assembly.Library;

var myTestlib = new TestLibrary();
var message = myTestlib.TestLibraryMessage;

Console.WriteLine($"Hello, World! Also: \n{message}");
Console.ReadLine();
