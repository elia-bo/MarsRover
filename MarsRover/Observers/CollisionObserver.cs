using MarsRover.Memento;

namespace MarsRover.Observers;

public class CollisionObserver : IObserver
{
    public void Update(Rover rover)
    {
        MarsSurface surface = MarsSurface.Instance();
        RoverMemento memento = RoverMemento.Instance();
        if (surface.IsObstacle(rover.Position))
            memento.Restore(rover);
    }
}