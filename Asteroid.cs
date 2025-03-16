using System;
using Microsoft.Xna.Framework;

namespace Spaceship;

public class Asteroid
{
    public Vector2 Position;
    private readonly int _speed;
    private const float Radius = 59;

    public Asteroid(int speed)
    {
        var random = new Random();
        Position = new(1380, random.Next(0, 721));
        _speed = speed;
    }

    public Vector2 MiddlePosition => new(Position.X - Radius, Position.Y - Radius);

    public void AsteroidUpdate(GameTime gameTime)
    {
        Position.X -= _speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }
}