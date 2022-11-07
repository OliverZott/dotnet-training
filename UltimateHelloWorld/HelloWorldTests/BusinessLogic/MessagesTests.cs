using HelloWorldLibrary.BusinessLogic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace HelloWorldTests.BusinessLogic;
public class MessagesTests
{
    [Fact]
    public void Greeting_InEnglish()
    {
        // Arrange
        ILogger<Messages> logger = new NullLogger<Messages>();
        Messages messages = new(logger);
        const string expected = "Hello World";

        // Act
        var result = messages.Greeting("en");

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Greeting_InItalian()
    {
        // Arrange
        ILogger<Messages> logger = new NullLogger<Messages>();
        Messages messages = new(logger);
        const string expected = "Ciao Mondo";

        // Act
        var result = messages.Greeting("it");

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Greeting_Invalid()
    {
        // Arrange
        ILogger<Messages> logger = new NullLogger<Messages>();
        Messages messages = new(logger);

        // Act & Assert
        Assert.Throws<NullReferenceException>(() => messages.Greeting("fr"));
    }


}
