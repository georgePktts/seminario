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

namespace seminario {

    public class Game1 : Microsoft.Xna.Framework.Game {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = Settings.window.Width;
            graphics.PreferredBackBufferHeight = Settings.window.Height;
            Window.Title = Settings.title;
            Content.RootDirectory = "Content";
        }

        
        protected override void Initialize() {
            EntitiesManager.Initialize();
            base.Initialize();
        }

        
        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            EntitiesManager.LoadContent(Content);
        }

        
        protected override void UnloadContent() { }

        
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Settings.state.Equals(Settings.States.Exit))
                this.Exit();
            EntitiesManager.Update();
            base.Update(gameTime);
        }

        
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
                EntitiesManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
