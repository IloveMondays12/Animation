using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D greyTribble;
        Rectangle window;
        Rectangle greyTribbleRect;
        Vector2 greyTribbleSpeed;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800,600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            greyTribbleRect = new Rectangle(300,10,100,100);
            greyTribbleSpeed = new Vector2(1,1);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            greyTribble = Content.Load<Texture2D>("tribbleGrey");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            greyTribbleRect.X += (int)greyTribbleSpeed.X;
            greyTribbleRect.Y += (int)greyTribbleSpeed.Y;
            base.Update(gameTime);
            if (greyTribbleRect.Right > window.Width || greyTribbleRect.Left < 0)
            {
                greyTribbleSpeed.X = greyTribbleSpeed.X * -1;
            }
            if (greyTribbleRect.Bottom > window.Height || greyTribbleRect.Top < 0)
            {
                greyTribbleSpeed.Y = greyTribbleSpeed.Y * -1;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightPink);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(greyTribble, greyTribbleRect, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}