using HubbersApp.Cli.Commands;
using HubbersApp.Cli.Handlers;
using HubbersApp.Core.Services;
using HubbersApp.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HubbersApp.Cli.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IHubberService, HubberService>();
        return services;
    }

    public static IServiceCollection AddCommandServices(this IServiceCollection services)
    {
        //Command handlers:
        services.AddScoped<HubberHandlers>();

        //Commands:
        services.AddScoped<ICommand, GetAllCommand>();

        //Parser:
        services.AddSingleton<CommandParser>();
        return services;
    }
}