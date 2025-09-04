namespace MarsRover.Commands;

public class TurnLeftCommand : ICommand
{
    public void ExecuteCommand(Rover rover)
        => rover.State.TurnLeft(rover);
}