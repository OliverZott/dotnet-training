namespace FileWatcher.Config;

public class Configuration
{
    public Configuration(string jsonPath, string path, List<string> extensions)
    {
        JsonPath = jsonPath;
        Path = path;
        Extensions = extensions;
    }

    public string Path { get; }
    public string JsonPath { get; }
    public List<string> Extensions { get; }
}