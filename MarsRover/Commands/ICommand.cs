namespace MarsRover.Commands;

public interface ICommand
{
    void ExecuteCommand(Rover rover);
}