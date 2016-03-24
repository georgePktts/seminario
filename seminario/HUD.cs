using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using seminario.Entities;

namespace seminario {

    class HUD {
        private SpriteFont font = null;
        private int w = 0, h = 0;
        private string health = "", ammo = "", score = ""; 
        private Color c;

        // Constructor
        public HUD() {
            w = Settings.window.Width;
            h = Settings.window.Height;
            c = Color.Black;
        }

        // Load Content
        public void LoadContent(ContentManager CM) {
            font = CM.Load<SpriteFont>("Content\\Fonts\\menuFont");
        }

        // Update
        public void Update() {
            Player P = EntitiesManager.getPlayer();
            health = "HEALTH : ";
            health += (P.health > 9) ? ((P.health > 99) ? "" + P.health : "0" + P.health) : "00" + P.health;

            int bullets = 100 - EntitiesManager.bulletsFired;
            ammo = "AMMO   : ";
            ammo += (bullets > 10) ? ((bullets > 99) ? "" + bullets : "0" + bullets) : "00" + bullets;

            score = "SCORE  : " + Settings.score;
        }

        // Draw
        public void Draw(SpriteBatch SB) {
            int row = 0;
            SB.DrawString(font, health, new Vector2(10, 10 + font.LineSpacing * row), c);
            row++;

            SB.DrawString(font, ammo, new Vector2(10, 10 + font.LineSpacing * row), c);
            row++;

            SB.DrawString(font, score, new Vector2(10, 10 + font.LineSpacing * row), c);
            row++;
        }


    }

}
