using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;

namespace seminario.Entities {

    class Bullet : Entity {
        private int damage = 0;
        public int index = 0;

        // Constructor
        public Bullet() {
            textureName = "bullet";
            speed = 10;
            damage = 5;
        }

        // Update
        public override void Update() {
            if (!alive) return;
            // Check if bullet is out of border
            if (position.X < 0 || position.Y < 0 || position.X > Settings.window.Width || position.Y > Settings.window.Height) setBulletDead();

            // Collision
            Collision();

            base.Update();
        }

        // Collision
        private void Collision() {
            foreach (Enemy e in EntitiesManager.getEnemies()) {
                if (e.textureBox.Intersects(textureBox) && e.alive) {
                    e.TakeDamage(damage);
                    setBulletDead();
                    return;
                }
            }
        }

        // Bullet is NOT alive
        public void setBulletDead() {
            EntitiesManager.setBulletDead(index);
        }

    }

}
