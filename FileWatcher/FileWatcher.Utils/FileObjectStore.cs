using FileWatcher.Config;

namespace FileWatcher.Utils;


public class FileObjectStore
{
    private readonly string _path;
    private readonly List<string> _extensions;

    // why not just public field???
    private List<FileObject>? FileObjects { get; set; }

    public FileObjectStore(Configuration config)
    {
        _path = config.Path;
        _extensions = config.Extensions;
    }



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
            .Where(f => _extensions.Any(f.ToLower().EndsWith))
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
