using System.Xml;

namespace FileWatcher.Config;


public class Configuration
{
    public Configuration(string path, string jsonPath, List<string> extensionList)
    {
        JsonPath = jsonPath;
        Path = path;
        Extensions = extensionList;
    }

    public string Path { get; }
    public string JsonPath { get; }
    public List<string> Extensions { get; }
}

public static class ConfigReader
{

    public static Configuration ReadConfiguration()
    {
        var reader = new XmlTextReader("C:\\Train\\dotnet-training\\FileWatcher\\app.config");

        var path = string.Empty;
        var jsonPath = string.Empty;
        var extensions = new List<string>();

        while (reader.Read())
        {
            // TODO: Refactor!
            switch (reader.NodeType)
            {
                case XmlNodeType.Element: // The node is an element.
                    if (reader.Name == "configuration")
                    {
                        while (reader.MoveToNextAttribute())
                        {
                            switch (reader.Name)
                            {
                                case "filesPath":
                                    path = reader.Value;
                                    break;
                                case "jsonOutput":
                                    jsonPath = reader.Value;
                                    break;
                            }
                        }
                    }
                    if (reader.Name == "extension")
                    {
                        reader.MoveToNextAttribute();
                        extensions.Add(reader.Value);
                    }
                    break;
                case XmlNodeType.Text: //Text in each element. REMOVE in future
                    Console.WriteLine(reader.Name);
                    Console.WriteLine(reader.Value);
                    break;
                case XmlNodeType.EndElement: //End of the element.
                    break;
            }
        }

        return new Configuration(path, jsonPath, extensions);
    }

}
