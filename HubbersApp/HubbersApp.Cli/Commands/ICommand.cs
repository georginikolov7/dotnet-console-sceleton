namespace HubbersApp.Cli.Commands;

public interface ICommand
{
    string Name { get; }
    Task ExecuteAsync(string[] args, IServiceProvider services);
}