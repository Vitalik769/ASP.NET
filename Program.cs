using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Components;

var builder = WebApplication.CreateBuilder();

builder.Services.AddTransient<Car>();
builder.Services.AddTransient<Owner>();

builder.Configuration.AddJsonFile("Configuration/Cars.json");

var app = builder.Build();
var configuration = app.Services.GetService<IConfiguration>();
var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Configuration/Owners");

if (File.Exists(jsonFilePath))
{
    var jsonContent = File.ReadAllText(jsonFilePath);
}

app.Map("/", () => "Index Page");

app.Map("/List", async (context) =>
{
    await context.Response.WriteAsync("Hello driver!");
});

app.Map("/List/Cars", async (context) =>
{
    var carsList = configuration.GetSection("Cars").Get<List<Car>>();
    foreach (var car in carsList)
    {
        await context.Response.WriteAsync($"Car: {car.CarMake} by {car.Year}\n");
    }
});

app.Map("/List/Profile/{id:int?}", (int? id) =>
{
    if (id.HasValue && id >= 0 && id <= 5)
    {
        var configFileName = $"Configuration/Owners/owner{id}.json";
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), configFileName);

        if (File.Exists(filePath))
        {
            var owner = JsonConvert.DeserializeObject<Owner>(File.ReadAllText(filePath));
            return $"Name: {owner.Name}, Age: {owner.Age}";
        }
        else
        {
            return "File configuration of user is not found.";
        }
    }
    else
    {

        var defaultOwner = JsonConvert.DeserializeObject<Owner>(File.ReadAllText("owner0.json"));
        return $"Name: {defaultOwner.Name}, Age: {defaultOwner.Age}";
    }

});

app.MapGet("/allmaps", (IEnumerable<EndpointDataSource> endpointSources) =>
string.Join("\n", endpointSources.SelectMany(source => source.Endpoints)));

app.Run();