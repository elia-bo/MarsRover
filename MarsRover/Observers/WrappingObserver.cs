namespace MarsRover.Observers;

public class WrappingObserver : IObserver
{
    public void Update(Rover rover)
    {
        MarsSurface surface = MarsSurface.Instance();
        if (rover.Position.X >= surface.Width)
            rover.Position.X = 0;
        else if (rover.Position.X < 0)
            rover.Position.X = surface.Width - 1;
        else if (rover.Position.Y >= surface.Height)
            rover.Position.Y = 0;
        else if (rover.Position.Y < 0)
            rover.Position.Y = surface.Height - 1;
    }
}