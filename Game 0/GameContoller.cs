using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_0
{
    public class GameContoller : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public SpriteFont FutureFont;
        public SpriteFont FutureFontLarge;

        public BackgroundElement BackgroundElement;
        public BackgroundElement BackgroundElement2;
        public BackgroundElement BackgroundElement3;
        public Texture2D BackgroundAtlas;

        public Character character;

        public GameContoller()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            BackgroundElement = new BackgroundElement(new Vector2(0, -100), "Kenny Background Elements Redux/Backgrounds/backgroundForest");
            BackgroundElement2 = new BackgroundElement(new Vector2(-500, -100), "Kenny Background Elements Redux/Backgrounds/backgroundForest");
            BackgroundElement3 = new BackgroundElement(new Vector2(500, -100), "Kenny Background Elements Redux/Backgrounds/backgroundForest");
            character = new Character();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            FutureFont = Content.Load<SpriteFont>("Future");
            FutureFontLarge = Content.Load<SpriteFont>("FutureLarge");
            BackgroundElement.LoadContent(Content);
            BackgroundElement2.LoadContent(Content);
            BackgroundElement3.LoadContent(Content);
            BackgroundAtlas = Content.Load<Texture2D>("Kenny Background Elements Redux/Spritesheet/spritesheet_default");
            character.LoadContent(Content);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            character.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            float cloudMovementTime = 25 * (float)gameTime.TotalGameTime.TotalSeconds;


            Vector2 mousePosition = -(new Vector2(Mouse.GetState().X - 500, Mouse.GetState().Y) / 500);

            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            BackgroundElement.Draw(gameTime, _spriteBatch, mousePosition * 40);
            BackgroundElement2.Draw(gameTime, _spriteBatch, mousePosition * 40);
            BackgroundElement3.Draw(gameTime, _spriteBatch, mousePosition * 40);
            //clouds
            _spriteBatch.Draw(BackgroundAtlas, new Vector2(50 + cloudMovementTime / 2 + mousePosition.X * 20, 50 + mousePosition.Y * 20), new Rectangle(250, 365, 203, 121), Color.White);
            _spriteBatch.Draw(BackgroundAtlas, new Vector2(500 + cloudMovementTime / 4 + mousePosition.X * 5, 100 + mousePosition.Y * 5), new Rectangle(0, 363, 250, 146), Color.White);
            _spriteBatch.Draw(BackgroundAtlas, new Vector2(150 + cloudMovementTime + mousePosition.X * 10, 80 + mousePosition.Y * 10), new Rectangle(281, 0, 195, 156), Color.White);

            _spriteBatch.Draw(BackgroundAtlas, new Vector2(50 + cloudMovementTime / 2 + mousePosition.X * 20 - 500, 50 + mousePosition.Y * 20), new Rectangle(250, 365, 203, 121), Color.White);
            _spriteBatch.Draw(BackgroundAtlas, new Vector2(500 + cloudMovementTime / 4 + mousePosition.X * 5 - 500, 100 + mousePosition.Y * 5), new Rectangle(0, 363, 250, 146), Color.White);
            _spriteBatch.Draw(BackgroundAtlas, new Vector2(150 + cloudMovementTime + mousePosition.X * 10 - 500, 80 + mousePosition.Y * 10), new Rectangle(281, 0, 195, 156), Color.White);


            character.Draw(gameTime, _spriteBatch, mousePosition * 13 + new Vector2(-100, 0));

            _spriteBatch.DrawString(FutureFontLarge, "Super Spud", new Vector2(100 + mousePosition.X * 10, 100 + mousePosition.Y * 10), Color.Black);
            _spriteBatch.DrawString(FutureFont, "Press Escape to Close", new Vector2(100 + mousePosition.X * 10, 400 + mousePosition.Y * 10), Color.Chocolate);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}