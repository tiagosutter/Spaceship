using Microsoft.Xna.Framework;

namespace Spaceship;

public class Ship
{
    public Vector2 Position = new(100, 100);
    private float _width = 68;
    private float _height = 100;
    
    public Vector2 MiddlePosition => new(Position.X - _width / 2, Position.Y - _height / 2);
}