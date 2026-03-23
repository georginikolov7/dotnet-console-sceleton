using HubbersApp.Cli.Commands;

namespace HubbersApp.Cli;

public class CommandParser
{
    private readonly Dictionary<string, ICommand> commands;

    public CommandParser(IEnumerable<ICommand> commands)
    {
        this.commands = commands.ToDictionary(c => c.Name, StringComparer.OrdinalIgnoreCase);
    }

    public async Task ExecuteAsync(string input, IServiceProvider services)
    {
        var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length == 0)
            return;

        var commandName = parts[0];
        var args = parts.Skip(1).ToArray();

        if (commands.TryGetValue(commandName, out var command))
        {
            await command.ExecuteAsync(args, services);
        }
        else
        {
            Console.WriteLine($"Unknown command: {commandName}");
        }
    }
}