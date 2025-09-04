namespace MarsRover.Commands;

public class MoveBackwardCommand : ICommand
{
    public void ExecuteCommand(Rover rover)
        => rover.State.MoveBackward(rover);
}