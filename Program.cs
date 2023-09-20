var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async context =>
{
    //1
    Company company = new Company();
    company.Name = "Apple";
    company.Email = "Apple@gmail.com";
    company.Address = "Infinite Loop Cupertino, California 95014";

    //2
    Random random = new Random();
    int randomNumber = random.Next(0, 101);
    //Îutput
    await context.Response.WriteAsync($"Compamy:\n {company.Name} \n {company.Email} \n {company.Address} ");
    await context.Response.WriteAsync($"\nRandom number: {randomNumber}");

});
app.Run();
public class Company
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }


}