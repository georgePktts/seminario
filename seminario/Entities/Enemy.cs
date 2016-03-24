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

    class Enemy : Entity {
        private int damage = 0, health = 0;

        // Constructor
        public Enemy() {
            textureName = "enemy";
            speed = 2;
            damage = 5;
            health = 10;
        }

        // Update
        public override void Update() {
            if (!alive) return;
            // Movement
            Player P = EntitiesManager.getPlayer();
            direction = PointAt(position.X, position.Y, P.position.X, P.position.Y);

            // Collision
            Collision(P);

            base.Update();
        }

        // Collision
        private void Collision(Player P) {
            if (textureBox.Intersects(P.textureBox)) {
                alive = false;
                textureBox = Rectangle.Empty;
                P.TakeDamage(damage);
            }
        }

        // Take damage
        public void TakeDamage(int _damage) {
            health -= _damage;
            if (health < 1) {
                Settings.score += 5;
                alive = false;
            }
        }

        // Reset
        public void Reset() {
            health = 10;
        }

    }

}
