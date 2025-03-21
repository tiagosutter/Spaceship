using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Spaceship;

public class Ship
{
    private static readonly Vector2 DefaultPosition = new Vector2(640, 360);
    public Vector2 Position = DefaultPosition;
    public const int Radius = 30;
        
    private const float Width = 68;
    private const float Height = 100;
    private const float Speed = 180;
    private const float HalfWidth = Width / 2;
    private const float HalfHeight = Height / 2;

    public Vector2 MiddlePosition => new(Position.X - HalfWidth, Position.Y - HalfHeight);

    public void ShipUpdate(KeyboardState keyboardState, GameTime gameTime)
    {
        float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
        var positionIncrease = delta * Speed;
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

    public void ResetPosition() => Position = DefaultPosition;
}