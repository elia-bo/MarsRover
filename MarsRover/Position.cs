namespace MarsRover;

public class Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int x, int y)
    {
        X  = x;
        Y = y;
    }

    public override bool Equals(object? obj) 
        => this.X == (obj as Position).X && this.Y == (obj as Position).Y;
    
    public override string ToString()
        => $"({X},{Y})";
}