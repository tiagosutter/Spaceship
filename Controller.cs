using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship;

public class Controller
{
    private List<Asteroid> _asteroids = new();
    private double _timer = 2;
    private double _maxTime = 2;
    private int _nextSpeed = 240;
    private Texture2D _asteroidSprite;
    public bool InGame = false;

    public Controller(Texture2D asteroidSprite)
    {
        _asteroidSprite = asteroidSprite;
    }

    public void ControllerUpdate(GameTime gameTime)
    {
        if (InGame)
        {
            _timer -= gameTime.ElapsedGameTime.TotalSeconds;
        }
        else
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Enter))
            {
                InGame = true;
            }
        }
        if (_timer <= 0)
        {
            _asteroids.Add(new Asteroid(_nextSpeed));
            _timer = _maxTime;
            if (_maxTime > 0.5)
            {
                _maxTime -= 0.1;
            }

            if (_nextSpeed < 720)
            {
                _nextSpeed += 4;
            }
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