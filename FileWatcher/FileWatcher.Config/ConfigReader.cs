using System.Xml;

namespace FileWatcher.Config;


public class ConfigReader : IConfigReader
{
    private const string Url = "C:\\Train\\dotnet-training\\FileWatcher\\app.config";

    public Configuration ReadConfiguration()
    {
        var reader = new XmlTextReader(Url);

        var path = string.Empty;
        var jsonPath = string.Empty;
        var extensions = new List<string>();


        // TODO Linq to xml
        // TODO: eleganter -> (de)serializer in Configuration class
        while (reader.Read())
        {
            if (reader.NodeType is not XmlNodeType.Element) continue;
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

        }

        return new Configuration(jsonPath, path, extensions);
    }

}
