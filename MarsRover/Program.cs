using MarsRover.Commands;
using MarsRover.I;
using MarsRover.Memento;
using MarsRover.Observers;
using Microsoft.Extensions.Configuration;

namespace MarsRover;

class Program
{
    static void Main()
    {
        var config = new ConfigurationBuilder().AddJsonFile("AppSettings.json").Build();
        
        int surfaceWidth =  int.Parse(config["SurfaceWidth"] ?? throw new InvalidOperationException());
        int surfaceHeight =  int.Parse(config["SurfaceHeight"] ?? throw new InvalidOperationException());
        string inputPath =  config["InputPath"] ?? throw new InvalidOperationException();
        string outputPath =   config["OutputPath"] ?? throw new InvalidOperationException();
        /*int surfaceWidth = 7;
        int surfaceHeight = 9;
        string inputPath = Path.Combine("C:\\MarsRover", "InputOutput", "commands.txt");
        string outputPath = Path.Combine("C:\\MarsRover", "InputOutput", "history.txt");*/
        
        MarsSurface surface = MarsSurface.Instance(surfaceWidth, surfaceHeight);
        
        Rover rover = Rover.BuildRover();
        LoggingObserver loggingObserver = new LoggingObserver();
        rover.AddObserver(new WrappingObserver());
        rover.AddObserver(new CollisionObserver());
        rover.AddObserver(loggingObserver);
        RoverMemento memento = RoverMemento.Instance();
        memento.Save(rover);
        IO io = new(inputPath, outputPath, rover);

        foreach (var c in io.ReadCommands())
        {
            ICommand? command = CommandFactory.Create(c);
            if (command == null) continue;
            RoverMemento.Instance().Save(rover);
            rover.ExecuteCommand(command);
            rover.NotifyObservers();
        }
        
        io.WriteLogs(loggingObserver.GetLog());
    }
}