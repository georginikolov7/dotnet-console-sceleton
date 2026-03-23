using HubbersApp.Core.Services.Interfaces;

namespace HubbersApp.Cli.Handlers;

public class HubberHandlers(IHubberService hubberService)
{
    public async Task GetAllAsync()
    {
        Console.WriteLine("[CLI] Fetching all Hubbers...");

        var hubbers = await hubberService.GetAllHubbers();

        if (!hubbers.Any())
        {
            Console.WriteLine("No Hubbers found in the database.");
            return;
        }

        Console.WriteLine($"Found {hubbers.Count()} Hubbers:");
        Console.WriteLine("----------------------------------");
        foreach (var hubber in hubbers)
        {
            // Update properties based on your actual Hubber model
            Console.WriteLine($"ID: {hubber.Id} | Name: {hubber.Name} ");
        }

        Console.WriteLine("----------------------------------");
    }
}