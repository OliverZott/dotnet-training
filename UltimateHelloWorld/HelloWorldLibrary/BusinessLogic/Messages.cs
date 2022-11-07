using HelloWorldLibrary.Models;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace HelloWorldLibrary.BusinessLogic;

public class Messages : IMessages
{
    private readonly ILogger<Messages> _logger;

    public Messages(ILogger<Messages> logger)
    {
        _logger = logger;
    }

    public string Greeting(string language)
    {
        return LookUpCustomText(nameof(Greeting), language);
    }

    private string LookUpCustomText(string key, string language)
    {
        JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        try
        {
            List<CustomText>? messageSets = JsonSerializer
               .Deserialize<List<CustomText>>(File.ReadAllText("CustomText.json"), options);

            var customText = messageSets?.Where(x => x.Language == language);

            if (!customText.Any())
            {
                throw new NullReferenceException($"Language ({language}) not found.");
            }

            return customText.First().Translations[key];
        }
        catch (Exception e)
        {
            _logger.LogError($"Error looking up custom text: {e.Message}");
            throw;
        }

    }
}
