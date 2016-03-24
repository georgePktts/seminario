using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace seminario.Menus {

    class MenuMain {
        private string[] menu = null;
        private SpriteFont font = null;
        private KeyboardState key;
        private int selected = 0;

        // Constructor
        public MenuMain() {
            menu = new string[4];
            menu[0] = Settings.title;
            menu[1] = "";
            menu[2] = "Play";
            menu[3] = "Exit";
            selected = 2;
        }

        // Load Content
        public void LoadContent(ContentManager CM) {
            font = CM.Load<SpriteFont>("Content\\Fonts\\menuFont");
        }

        // Update
        public void Update() {
            key = Keyboard.GetState();

            if (key.IsKeyDown(Keys.Up)) if (selected > 2) selected--;
            if (key.IsKeyDown(Keys.Down)) if (selected < menu.Length - 1) selected++;
            if (key.IsKeyDown(Keys.Enter)) {
                if (selected == 2) Settings.state = Settings.States.Play;
                if (selected == 3) Settings.state = Settings.States.Exit;
            }
        }

        // Draw
        public void Draw(SpriteBatch SB) {
            for (int i = 0; i < menu.Length; i++) {
                string str = (selected == i) ? "[ " + menu[i] + " ]": menu[i];
                Vector2 position = new Vector2(Settings.window.Width / 2 -  font.MeasureString(str).X / 2,
                    Settings.window.Height / 2 - ((menu.Length / 2)) * font.LineSpacing + font.LineSpacing * i);
                SB.DrawString(font, str, position, Color.White);
            }
        }

    }

}
