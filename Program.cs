var builder = WebApplication.CreateBuilder();
builder.Services.AddTransient<CalcService>();
builder.Services.AddTransient<TimeOfDayService>();
var app = builder.Build();
app.Run(async context =>
{
    var timeOfDayService = app.Services.GetService<TimeOfDayService>();
    var CalcService = app.Services.GetService<CalcService>();

    await context.Response.WriteAsync($"Time: {timeOfDayService?.GetTimeOfDay()}");
    await context.Response.WriteAsync($"\nSum: {CalcService?.Add(5, 5)}");
    await context.Response.WriteAsync($"\nSubtraction: {CalcService?.Subtract(5, 5)}");
    await context.Response.WriteAsync($"\nDividion: {CalcService?.Divide(5, 5)}");
    await context.Response.WriteAsync($"\nMultiplication: {CalcService?.Multiplication(5, 5)}");

});
app.Run();