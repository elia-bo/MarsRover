namespace MarsRover.I;

public class IO
{
    private readonly string _inputFilePath;
    private readonly string? _outputFilePath;

    public IO(string inputFilePath, string? outputFilePath, Rover rover)
    {
            _inputFilePath = inputFilePath;
            _outputFilePath = outputFilePath;
            MarsSurface surface = MarsSurface.Instance();
            string starting =
                $"Starting configuration: Surface: {surface.Width}x{surface.Height}; Obstacles: {surface.GetObstacleList()}; Rover: {rover.Position.X},{rover.Position.Y}\n";
            File.WriteAllText(_outputFilePath, starting);
    }

    public string ReadCommands() 
        => File.ReadAllText(_inputFilePath).Trim();

    public void WriteLogs(IEnumerable<string> commands) 
        => File.AppendAllLines(_outputFilePath, commands);
}