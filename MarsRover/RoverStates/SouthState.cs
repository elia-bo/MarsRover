namespace MarsRover.RoverStates;

public class SouthState : IRoverState
{
    public void TurnRight(Rover rover) 
        => rover.State = new WestState();

    public void TurnLeft(Rover rover)
        => rover.State = new EastState();

    public void MoveForward(Rover rover) 
        => rover.Position = new Position(rover.Position.X, rover.Position.Y - 1);

    public void MoveBackward(Rover rover)
        => rover.Position = new Position(rover.Position.X, rover.Position.Y + 1);
    
    public override string ToString()
    {
        return "South";
    }
}