namespace MarsRover.Commands;

public class TurnRightCommand : ICommand
{
    public void ExecuteCommand(Rover rover)
        => rover.State.TurnRight(rover);
}