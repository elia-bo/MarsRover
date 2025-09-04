namespace MarsRover.RoverStates;

public class NorthState : IRoverState
{
    public void TurnRight(Rover rover) 
        => rover.State = new EastState();

    public void TurnLeft(Rover rover)
        => rover.State = new WestState();

    public void MoveForward(Rover rover) 
        => rover.Position = new Position(rover.Position.X, rover.Position.Y + 1);

    public void MoveBackward(Rover rover)
        => rover.Position = new Position(rover.Position.X, rover.Position.Y - 1);
    
    public override string ToString()
    {
        return "North";
    }
}