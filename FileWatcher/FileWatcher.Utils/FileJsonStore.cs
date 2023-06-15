using FileWatcher.Config;
using System.Text.Json;

namespace FileWatcher.Utils;
public class FileJsonStore
{
    private readonly string _path;

    public FileJsonStore(Configuration configuration)
    {
        _path = configuration.JsonPath;
    }


    public void CreateJsonStore(List<FileObject> fileObjects)
    {
        var fileName = $"{_path}\\FileStorage.json";

        var options = new JsonSerializerOptions { WriteIndented = true };
        using var createStream = File.Create(fileName);
        JsonSerializer.Serialize(createStream, fileObjects, options);
    }


    public async Task<List<FileObject>?> ReadJsonStore()
    {
        var fileName = $"{_path}\\FileStorage.json";

        await using var openStream = File.OpenRead(fileName);
        var fileObjects = await JsonSerializer.DeserializeAsync<List<FileObject>>(openStream);
        return fileObjects;
    }
}
