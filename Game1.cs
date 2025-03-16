using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _shipSprite;
    private Texture2D _asteroidSprite;
    private Texture2D _spaceSprite;

    private SpriteFont _gameSprite;
    private SpriteFont _timerSprite;
    
    private readonly Ship _player = new Ship();
    private readonly Asteroid _testAsteroid = new Asteroid(Asteroid.BaseSpeed);

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _shipSprite = Content.Load<Texture2D>("ship");
        _asteroidSprite = Content.Load<Texture2D>("asteroid");
        _spaceSprite = Content.Load<Texture2D>("space");
        _gameSprite = Content.Load<SpriteFont>("spaceFont");
        _timerSprite = Content.Load<SpriteFont>("timerFont");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        _player.ShipUpdate(Keyboard.GetState(), gameTime);
        _testAsteroid.AsteroidUpdate(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_spaceSprite, new Vector2(0, 0), Color.White);
        _spriteBatch.Draw(_asteroidSprite, _testAsteroid.MiddlePosition, Color.White);
        _spriteBatch.Draw(_shipSprite, _player.MiddlePosition, Color.White);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}