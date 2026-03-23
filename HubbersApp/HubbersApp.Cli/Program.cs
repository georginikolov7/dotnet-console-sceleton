using HubbersApp.Cli;
using HubbersApp.Cli.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HubbersApp.Infrastructure;
using HubbersApp.Infrastructure.Models;
using HubbersApp.Infrastructure.Repos;


var builder = Host.CreateApplicationBuilder(args);
// Ensure the builder looks at the physical file in the execution directory
builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables(); // Essential for Docker!


var connectionString = builder.Configuration.GetConnectionString("PostgresConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException(
        "Could not find 'PostgresConnection'. Check appsettings.json or Environment Variables.");
}

// --------------------
// Register DI Services
// --------------------

//Db Context:
builder.Services.AddDbContext<HubDbContext>(options =>
    options.UseNpgsql(connectionString));
//Repos:
builder.Services.AddScoped<IRepo<Hubber>, HubberRepo>();

//Core Services:
builder.Services.AddCoreServices();

//Command Line Services:
builder.Services.AddCommandServices();
using IHost host = builder.Build();


// --------------------
// Migrate and Seed Db
// --------------------
using (var scope = host.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var dbContext = services.GetRequiredService<HubDbContext>();
        await dbContext.Database.MigrateAsync();
        Console.WriteLine("Db migrated successfully!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[ERROR] An error occurred while seeding the DB: {ex.Message}");
    }
}

// --------------------
// Interactive CLI Loop
// --------------------
var parser = host.Services.GetRequiredService<CommandParser>();

Console.WriteLine("Hubbers CLI (type 'exit' to quit)");

while (true)
{
    Console.Write("hubbers> ");
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input))
        continue;

    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
        break;

    try
    {
        await parser.ExecuteAsync(input, host.Services);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}