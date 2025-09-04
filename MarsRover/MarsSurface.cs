namespace MarsRover;

public class MarsSurface
{
    private static MarsSurface? _instance;
    public int Width, Height;
    private List<Position>? _obstacles = new();
    
    private MarsSurface(int width, int height)
    {
        Width = width;
        Height = height;
        BuildObstacles(width, height);
        _instance = this;
    }

    private void BuildObstacles(int width, int height)
    {
        List<Position> obstacles = new();
        Random random = new Random();
        int numberOfObstacles = random.Next(1, width * height / 10);
        for (int i = 0; i < numberOfObstacles; i++)
        {
            int obstacleX = random.Next(0, width - 1);
            int obstacleY = random.Next(0, height - 1);
            
            if (obstacles.Contains(new Position(obstacleX, obstacleY)))
                i--;
            else
                obstacles.Add(new Position(obstacleX, obstacleY));
        }
        _obstacles = obstacles;
        //_obstacles = [new Position(0,0)];
    }

    public static MarsSurface Instance(int width = 0, int height = 0) 
        => _instance ?? (_instance = new MarsSurface(width, height));

    public bool IsObstacle(Position position) 
        => _obstacles != null && _obstacles.Contains(position);
    
    public string GetObstacleList() 
        => string.Join(", ", _obstacles);
}