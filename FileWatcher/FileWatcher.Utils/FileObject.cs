namespace FileWatcher.Utils;

public class FileObject
{
    public string? Name { get; set; }
    public string? Topic { get; set; }
    public string? Type { get; set; }
    public DateTime Date { get; set; }

    public override string ToString()
    {
        return $"FileName: {Name}\nTopic: {Topic}\nType: {Type}\nDate: {Date}\n\n";
    }
}