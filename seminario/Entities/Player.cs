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

    class Player : Entity {
        public int health = 0;
        private int _speed = 0, fireTime = 0, reloadTime = 0;
        private KeyboardState key;
        private MouseState mou;
        private bool reloading = false;

        // Constructor
        public Player(Vector2 _position) {
            position = _position;
            direction = 270;
            textureName = "bot";
            textureName2 = "top";
            _speed = 2;
            health = 100;
            alive = true;
        }

        // Update
        public override void Update() {
            key = Keyboard.GetState();
            mou = Mouse.GetState();

            // Movement
            if (key.IsKeyDown(Keys.W) || key.IsKeyDown(Keys.Up)) speed = _speed;
            if (key.IsKeyUp(Keys.W) && key.IsKeyUp(Keys.Up)) speed = 0;
            if (key.IsKeyDown(Keys.A) || key.IsKeyDown(Keys.Left)) direction -= _speed;
            if (key.IsKeyDown(Keys.D) || key.IsKeyDown(Keys.Right)) direction += _speed;

            // Rotot movement
            direction2 -= 15;

            // Check and keep player into frame
            if (speed != 0) {
                if (position.X <= Settings.frame.X) position.X = Settings.frame.X;
                if (position.Y <= Settings.frame.Y) position.Y = Settings.frame.Y;
                if (position.X >= Settings.frame.Width) position.X = Settings.frame.Width;
                if (position.Y >= Settings.frame.Height) position.Y = Settings.frame.Height;
            } else {
                if (position.X <= Settings.frame.X) position.X = Settings.frame.X + 1;
                if (position.Y <= Settings.frame.Y) position.Y = Settings.frame.Y + 1;
                if (position.X >= Settings.frame.Width) position.X = Settings.frame.Width - 1;
                if (position.Y >= Settings.frame.Height) position.Y = Settings.frame.Height - 1;
            }

            // Pause
            if (key.IsKeyDown(Keys.Escape)) Settings.state = Settings.States.Menu;

            // Shoot
            fireTime++;
            if (mou.LeftButton.Equals(ButtonState.Pressed) && !reloading) Shoot();

            // Reload
            if (key.IsKeyDown(Keys.R)) reloading = true;
            Reload();

            base.Update();
        }

        // Shoot bullets
        private void Shoot() {
            if (fireTime > 15) {
                fireTime = 0;
                EntitiesManager.Shoot(position, PointAt(position.X, position.Y, mou.X, mou.Y));
            }
        }

        // Reload weapon
        private void Reload() {
            if (!reloading) return;
            reloadTime++;
            if (reloadTime > 60) {
                reloadTime = 0;
                EntitiesManager.Reload();
                reloading = false;
            }
        }

        // Take Damage
        public void TakeDamage(int damage) {
            health -= damage;
            if (health < 1) Settings.state = Settings.States.GameOver;
        }

        // Reset
        public void Reset() {
            health = 100;
            EntitiesManager.Reload();
            position = new Vector2(Settings.window.Width / 2, Settings.window.Height / 2);
        }
    }

}
