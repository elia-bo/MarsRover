namespace MarsRover.RoverStates;

public interface IRoverState
{
    public void TurnRight(Rover rover);
    public void TurnLeft(Rover rover);
    public void MoveForward(Rover rover);
    public void MoveBackward(Rover rover);
}