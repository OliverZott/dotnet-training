using System.Text.Json;

namespace FileWatcher.Utils;
public class FileJsonStore
{
    // TODO: move to config file
    private const string Path = "C:\\Train\\FileWatcherExample\\data";

    public string FileList;

    public void CreateJsonStore(List<FileObject> fileObjects)
    {
        const string fileName = $"{Path}\\FileStorage.json";

        var options = new JsonSerializerOptions { WriteIndented = true };
        using var createStream = File.Create(fileName);
        JsonSerializer.Serialize(createStream, fileObjects, options);
    }

    // TODO: Generate List<FileObject> from Json store
    public async Task<List<FileObject>?> ReadJsonStore()
    {
        const string fileName = $"{Path}\\FileStorage.json";

        await using var openStream = File.OpenRead(fileName);
        var fileObjects = await JsonSerializer.DeserializeAsync<List<FileObject>>(openStream);
        return fileObjects;
    }
}
