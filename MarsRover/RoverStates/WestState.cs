namespace MarsRover.RoverStates;

public class WestState : IRoverState
{
    public void TurnRight(Rover rover)
        => rover.State = new NorthState();

    public void TurnLeft(Rover rover)
        => rover.State = new SouthState();

    public void MoveForward(Rover rover) 
        => rover.Position = new Position(rover.Position.X - 1, rover.Position.Y);

    public void MoveBackward(Rover rover)
        => rover.Position = new Position(rover.Position.X + 1, rover.Position.Y);
    
    public override string ToString()
    {
        return "West";
    }
}