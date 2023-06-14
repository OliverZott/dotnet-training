namespace FileWatcher.Utils;
public class FileObjectStore
{
    // Todo: move to config file
    private static readonly string BasePath = "C:\\Train\\dotnet-training\\FileWatcher\\";
    //private const string Path = "C:\\Train\\FileWatcherExample\\data";
    private readonly string _path = $"{BasePath}\\data";
    private readonly string[] _allowedExtensions = { ".pdf", ".txt" };
    public List<FileObject>? FileObjects;

    public List<FileObject> GetFileObjects()
    {
        var filePaths = GetAllFilesFromDirectory();
        FileObjects = filePaths.Select(CreateFileObject).ToList();

        return FileObjects;
    }

    public List<string> GetAllFilesFromDirectory()
    {
        var files = Directory
            .GetFiles(_path, "*", SearchOption.AllDirectories)
            .Where(f => _allowedExtensions.Any(f.ToLower().EndsWith))
            //.Where(f => _allowedExtensions.Any(x => f.ToLower().EndsWith(x))
            .ToList();
        return files;
    }

    public FileObject CreateFileObject(string filePath)
    {
        var fileInfo = new FileInfo(filePath);

        return new FileObject()
        {
            Name = fileInfo.Name,
            Date = fileInfo.CreationTime,
            Type = fileInfo.Extension,
            Topic = fileInfo.Directory?.Name,
        };
    }

}
