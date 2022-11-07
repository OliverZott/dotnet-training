namespace HelloWorldLibrary.BusinessLogic;

public interface IMessages
{
    private string LookUpCustomText(string key, string language)
    {
        throw new NotImplementedException();
    }

    string Greeting(string language);
}