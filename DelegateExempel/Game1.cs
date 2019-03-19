using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace DelegateExempel
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Button b;
        Texture2D pixel;
        List<Button> buttons = new List<Button>();
        System.Random rand = new System.Random();
        MouseState oldMouse;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            CreateTexture();
            b = new Button(pixel, new Vector2(400 - 80 / 2, 240 - 30 / 2), new Vector2(80, 30), OnClick);
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // När man klickar på knappen ska OnClick anropas
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && oldMouse.LeftButton == ButtonState.Released)
                if (b.ClickBox.Contains(Mouse.GetState().Position))
                    b.OnClick();

            // TODO: Add your update logic here
            oldMouse = Mouse.GetState();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            b.Draw(spriteBatch);
            foreach (var item in buttons)
            {
                item.Draw(spriteBatch);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        /// <summary>
        /// Metoden som knappen använder sig av
        /// </summary>
        void OnClick()
        {
            Vector2 pos = new Vector2(rand.Next(800),rand.Next(480));
            Vector2 size = new Vector2(rand.Next(100), rand.Next(50));
            buttons.Add(new Button(pixel, pos, size, OnClick));
        }

        /// <summary>
        /// Skapa pixel
        /// </summary>
        void CreateTexture()
        {
            // Skapa texturobjektet.
            pixel = new Texture2D(GraphicsDevice, 1, 1);

            // Skicka in datan, i det här fallet färg.
            pixel.SetData(new Color[] { Color.White });
        }
    }
}
