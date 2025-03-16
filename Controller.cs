using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Spaceship;

public class Controller
{
    private const int TimeBetweenAsteroidCreation = 2;
    private List<Asteroid> _asteroids = new();
    private double _timer = 0;
    private Texture2D _asteroidSprite;

    public Controller(Texture2D asteroidSprite)
    {
        _asteroidSprite = asteroidSprite;
    }

    public void ControllerUpdate(GameTime gameTime)
    {
        _timer -= gameTime.ElapsedGameTime.TotalSeconds;
        if (_timer <= 0)
        {
            _asteroids.Add(new Asteroid(Asteroid.BaseSpeed));
            _timer = TimeBetweenAsteroidCreation;
        }

        for (var index = 0; index < _asteroids.Count; index++)
        {
            _asteroids[index].AsteroidUpdate(gameTime);
        }
    }    
    
    public void ControllerDrawAsteroids(SpriteBatch spriteBatch)
    {
        for (var index = 0; index < _asteroids.Count; index++)
        {
            spriteBatch.Draw(_asteroidSprite, _asteroids[index].MiddlePosition, Color.White);
        }
    }
}