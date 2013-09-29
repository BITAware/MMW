using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace Tutorial
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        KeyboardState oldState;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            MediaPlayer.Stop();
            Uri uriStreaming = new Uri("C:/Users/Nick/Documents/School/Dropbox/final_fantasy_final_boss_music_final_fantasy_x_jecht_youtube.mp3");
            Song song = Song.FromUri("StreamingUri", uriStreaming);
            MediaPlayer.Play(song);

            oldState = Keyboard.GetState();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// 

        

        Texture2D myTexture;

        Vector2 buttPosition = Vector2.Zero;

        Vector2 buttSpeed = new Vector2(50.0f, 50.0f);






        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            myTexture = Content.Load<Texture2D>("Red_button");



        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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


            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
                ButtonState.Pressed)
                this.Exit();

            UpdateInput();



            // Move the sprite by speed, scaled by elapsed time.
            buttPosition +=
                buttSpeed * 5*(float)gameTime.ElapsedGameTime.TotalSeconds;

            int MaxX =
                graphics.GraphicsDevice.Viewport.Width - myTexture.Width;
            int MinX = 0;
            int MaxY =
                graphics.GraphicsDevice.Viewport.Height - myTexture.Height;
            int MinY = 0;

            // Check for bounce.
            if (buttPosition.X > MaxX)
            {
                buttSpeed.X *= -1;
                buttPosition.X = MaxX;
            }

            else if (buttPosition.X < MinX)
            {
                buttSpeed.X *= -1;
                buttPosition.X = MinX;
            }

            if (buttPosition.Y > MaxY)
            {
                buttSpeed.Y *= -1;
                buttPosition.Y = MaxY;
            }

            else if (buttPosition.Y < MinY)
            {
                buttSpeed.Y *= -1;
                buttPosition.Y = MinY;
            }
        }


        private void UpdateInput()
        {
            KeyboardState newState = Keyboard.GetState();

            // Is the SPACE key down?
            if (newState.IsKeyDown(Keys.Space))
            {
                // If not down last update, key has just been pressed.
                if (!oldState.IsKeyDown(Keys.Space))
                {
                    
                }
            }
            else if (oldState.IsKeyDown(Keys.Space))
            {
                // Key was down last update, but not down now, so
                // it has just been released.
            }

            // Update saved state.
            oldState = newState;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Fuchsia);

            // TODO: Add your drawing code here

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(myTexture, buttPosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
