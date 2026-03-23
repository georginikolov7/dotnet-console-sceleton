using HubbersApp.Cli.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace HubbersApp.Cli.Commands;

public class GetAllCommand : ICommand
{
    public string Name => "get-all";

    public async Task ExecuteAsync(string[] args, IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<HubberHandlers>();
        await handler.GetAllAsync();
    }
}