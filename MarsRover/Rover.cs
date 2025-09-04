using MarsRover.Commands;
using MarsRover.I;
using MarsRover.Observers;
using MarsRover.RoverStates;

namespace MarsRover;

public class Rover
{
    public Position Position { get; set; }
    public IRoverState State { get; set; }
    private readonly List<IObserver> _observers = new();

    private Rover(Position startingPosition, IRoverState startingState)
    {
        Position = startingPosition;
        State = startingState;
    }

    public static Rover BuildRover()
    {
        Random random = new Random();
        MarsSurface surface = MarsSurface.Instance();
        while (true)
        {
            Position roverPosition = new Position(random.Next(0, surface.Width - 1), random.Next(0, surface.Height - 1));
            if (!surface.IsObstacle(roverPosition))
                return new Rover(roverPosition, new NorthState());
            //return new Rover(new Position(0, 7), new NorthState());
        }
    }

    public void ExecuteCommand(ICommand command)
        => command.ExecuteCommand(this);
    
    public void AddObserver(IObserver observer)
        => _observers.Add(observer);

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
            observer.Update(this);
    }
}