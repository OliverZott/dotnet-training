#!/usr/bin/env dotnet
var name = args.Length > 0 ? args[0] : "World";
Console.WriteLine($"Hello, {name}!");

/* 
run in linux with just either:

./linux_hello.cs 
./linux_hello
so symlink or semantic link possible without fileending in unix
*/