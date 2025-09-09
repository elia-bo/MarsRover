using MarsRover.RoverStates;

namespace MarsRover.Memento;

public class RoverMemento
{
    private static RoverMemento? _instance;
    private record Memento(Position Position, IRoverState RoverState);
    private readonly Stack<Memento> _mementos = new();
    
    public static RoverMemento Instance()
        => _instance ?? ( _instance = new RoverMemento());
    
    public void Save(Rover rover)
        => _mementos.Push(new Memento(rover.Position, rover.State));

    public void Restore(Rover rover)
    {
        if (!_mementos.TryPop(out var memento)) return;
        rover.Position = memento.Position;
        rover.State = memento.RoverState;
    }
}