namespace MarsRover.Commands;

public class MoveForwardCommand : ICommand
{
    public void ExecuteCommand(Rover rover)
        => rover.State.MoveForward(rover);
}