using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Spaceship;

public class Ship
{
    public Vector2 Position = new(100, 100);
    private float _width = 68;
    private float _height = 100;
    private float _speed = 180;

    public Vector2 MiddlePosition => new(Position.X - _width / 2, Position.Y - _height / 2);

    public void ShipUpdate(KeyboardState keyboardState, GameTime gameTime)
    {
        float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
        var positionIncrease = delta * _speed;
        if (keyboardState.IsKeyDown(Keys.Up))
        {
            Position.Y -= positionIncrease;
        }

        if (keyboardState.IsKeyDown(Keys.Right))
        {
            Position.X += positionIncrease;
        }

        if (keyboardState.IsKeyDown(Keys.Down))
        {
            Position.Y += positionIncrease;
        }

        if (keyboardState.IsKeyDown(Keys.Left))
        {
            Position.X -= positionIncrease;
        }
    }
}