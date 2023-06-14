using FileWatcher.Utils;

var fileStore = new FileObjectStore();
var filePaths = fileStore.GetAllFilesFromDirectory();
var fileObjects = fileStore.GetFileObjects();

//foreach (var filePath in filePaths)
//{
//    Console.WriteLine(filePath);
//}


//foreach (var fileObject in fileObjects)
//{
//    Console.WriteLine(fileObject);
//}

var fileJsonStore = new FileJsonStore();
fileJsonStore.CreateJsonStore(fileObjects);

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