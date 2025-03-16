using Microsoft.Xna.Framework;

namespace Spaceship;

public class Asteroid
{
    public const int BaseSpeed = 250;
    public Vector2 Position = new(600, 300);
    private readonly int _speed;
    private const float Radius = 59;

    public Asteroid(int speed)
    {
        _speed = speed;
    }

    public Vector2 MiddlePosition => new(Position.X - Radius, Position.Y - Radius);

    public void AsteroidUpdate(GameTime gameTime)
    {
        Position.X -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}