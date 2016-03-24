using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace seminario.Entities {

    class Entity {
        public Vector2 position = Vector2.Zero;
        public Texture2D texture = null, texture2 = null;
        public string textureName = null, textureName2 = null;
        public Rectangle textureBox = Rectangle.Empty;
        public float direction = 0f, direction2 = 0f, scale = 1f;
        public int speed = 0;
        public bool alive = false;

        // Constructor
        public Entity() { }

        // Load Content
        public void LoadContent(ContentManager CM) {
            texture = CM.Load<Texture2D>("Content\\Sprites\\" + textureName);
            if (textureName2 != null) texture2 = CM.Load<Texture2D>("Content\\Sprites\\" + textureName2);
        }

        // Update
        public virtual void Update() {
            if (!alive) return;
            textureBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            Move(speed, direction);
        }

        // Draw
        public virtual void Draw(SpriteBatch SB) {
            if (!alive) return;
            SB.Draw(texture, position, null, Color.White, MathHelper.ToRadians(direction), new Vector2(texture.Width / 2, texture.Height / 2), scale, SpriteEffects.None, 0);
            if (textureName2 != null) SB.Draw(texture2, position, null, Color.White, MathHelper.ToRadians(direction2), new Vector2(texture2.Width / 2, texture2.Height / 2), scale, SpriteEffects.None, 0);
        }

        // Move
        private void Move(float s, float d) {
            float nX = (float)Math.Cos(MathHelper.ToRadians(d));
            float nY = (float)Math.Sin(MathHelper.ToRadians(d));
            position.X += s * (float)nX;
            position.Y += s * (float)nY;
        }

        // Point At
        public float PointAt(float x, float y, float x2, float y2) {
            float dx = x - x2;
            float dy = y - y2;
            float adj = dx;
            float opp = dy;
            float res = MathHelper.ToDegrees((float)Math.Atan2(opp, adj));
            res = (res - 180) % 360;
            if (res < 0) res += 360;
            return res;
        }

    }

}
