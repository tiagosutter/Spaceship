using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship;

public class Game1 : Game
{
    public static int ScreenWidth = 1280;
    public static int ScreenHeight = 720;

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _shipSprite;
    private Texture2D _asteroidSprite;
    private Texture2D _spaceSprite;

    private SpriteFont _gameFont;
    private SpriteFont _timerFont;
    
    private Controller _controller;
    private readonly Ship _player = new Ship();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = ScreenWidth;
        _graphics.PreferredBackBufferHeight = ScreenHeight;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _shipSprite = Content.Load<Texture2D>("ship");
        _asteroidSprite = Content.Load<Texture2D>("asteroid");
        _spaceSprite = Content.Load<Texture2D>("space");
        _gameFont = Content.Load<SpriteFont>("spaceFont");
        _timerFont = Content.Load<SpriteFont>("timerFont");
        _controller = new Controller(_asteroidSprite);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        if (_controller.InGame)
        {
            _player.ShipUpdate(Keyboard.GetState(), gameTime);
        }
        _controller.ControllerUpdate(gameTime, _player);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        _spriteBatch.Draw(_spaceSprite, new Vector2(0, 0), Color.White);
        _controller.ControllerDrawAsteroids(_spriteBatch);
        _controller.ControllerDrawTime(_spriteBatch, _gameFont);
        _spriteBatch.Draw(_shipSprite, _player.MiddlePosition, Color.White);

        if (!_controller.InGame)
        {
            string message = "Press Enter to Begin!";
            Vector2 sizeOfText = _gameFont.MeasureString(message);
            int halfWidth = _graphics.PreferredBackBufferWidth / 2;
            _spriteBatch.DrawString(_gameFont, message, new Vector2(halfWidth - sizeOfText.X / 2, 200), Color.White);
        }
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}