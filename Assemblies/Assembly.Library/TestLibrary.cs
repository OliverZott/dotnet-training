namespace Assembly.Library;

public class TestLibrary
{
    private readonly DateTime dateTimeNow;

    public TestLibrary()
    {
        dateTimeNow = DateTime.Now;
    }

    public string FormattedDate => dateTimeNow.ToString("yyyy-MM-dd HH:mm:ss");

    public string TestLibraryMessage => $"Hello from inside TestLibrary on {FormattedDate}";
}