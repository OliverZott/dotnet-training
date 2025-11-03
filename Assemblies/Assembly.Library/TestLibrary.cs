namespace Assembly.Library;

public class TestLibrary
{
    private readonly DateTime _dateTimeNow = DateTime.Now;

    private string FormattedDate => _dateTimeNow.ToString("yyyy-MM-dd HH:mm:ss");

    public string TestLibraryMessage => $"Hello from inside TestLibrary on {FormattedDate}";
}