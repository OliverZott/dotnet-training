/*
 * Run / Debug and check https://localhost:7008/weatherforecast/
 * 
 * https://www.youtube.com/watch?v=Lvdyi5DWNm4
 * 
 * If class (e.g. Datetime or stopwatch) is instantiated, it is allocated on the heap. 
 * With structs (allocated on stack) it can be more performant.
 */

using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.Use(async (context, next) =>
{
    var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();

    //var before = DateTimeOffset.UtcNow;  // not too good

    //var sw = new Stopwatch();  // better but still creating sw class (living on the heap)
    //sw.Start();

    var startTime = Stopwatch.GetTimestamp();

    logger.LogInformation("Benchmarking Started");
    await next(context);

    //var delta = DateTimeOffset.UtcNow - before;
    //sw.Stop();
    var delta = Stopwatch.GetElapsedTime(startTime);

    logger.LogInformation("Benchmarking Ended after {timespan}", delta);  // sw.Elapsed
});


var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", async () =>
{
    await Task.Delay(543);
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
