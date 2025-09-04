namespace MarsRover.Observers;

public class LoggingObserver : IObserver
{
    private readonly List<string> _log = new();
    private const string CollisionLine = "Collision detected on next step, skipping command";

    public void Update(Rover rover)
    {
        string line = $"Position: {rover.Position.X},{rover.Position.Y}, Facing: {rover.State}";
        if (GetLastValidLine() == line)
            line = CollisionLine;
        _log.Add(line);
    }

    public IEnumerable<string> GetLog()
        => _log;
    
    private string GetLastValidLine()
        => _log.LastOrDefault(x => x != CollisionLine);
}