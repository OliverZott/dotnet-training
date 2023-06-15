using FileWatcher.Config;
using FileWatcher.Utils;


var config = ConfigReader.ReadConfiguration();


// Save files to Json
var fileStore = new FileObjectStore(config);
var fileObjects = fileStore.GetFileObjects();
var fileJsonStore = new FileJsonStore(config);
fileJsonStore.CreateJsonStore(fileObjects);


// Get files from json
var fileObjectsFromJson = fileJsonStore.ReadJsonStore().Result;

foreach (var fileObject in fileObjectsFromJson)
{
    Console.WriteLine(fileObject);
}



// 1. read all pdf-files from directory (including subdirectories)
// 1.1 create pdf-file-object with more information
// 1.2 add pdf-file-objects to a list
// 1.3 write pdf-file-object-list to json-file (serialize)

// 2. check if something changes in directory
// 2.1 onChange replace json-file

// 3. add config
// 3.1 for directory path
// 3.2 for json-list path

// 4. Add IoC/DI