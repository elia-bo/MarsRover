namespace MarsRover.Commands;

public static class CommandFactory
{
    public static ICommand? Create(char command)
        => command switch
        {
            'F' => new MoveForwardCommand(),
            'B' => new MoveBackwardCommand(),
            'L' => new TurnLeftCommand(),
            'R' => new TurnRightCommand(),
            ' ' or '\t' or '\r' or '\n' => null,
            _ => throw new ArgumentException($"Invalid command : {command}")
        };
}