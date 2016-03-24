using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using seminario.Menus;
using seminario.Entities;

namespace seminario {

    class EntitiesManager {
        private static MenuMain MM = null;
        private static Player P = null;
        private static Cursor C = null;
        private static Bullet[] Ammo = null;
        public static int bulletsFired = 0;
        private static Enemy[] Enemies = null;
        private static Spawn S = null;
        private static HUD H = null;
        private static Texture2D background = null;
        private static int x = 0, y = 0, stopWidth = 0, stopHeight = 0, step = 3;

        // Initialize
        public static void Initialize() {
            MM = new MenuMain();
            P = new Player(new Vector2(Settings.window.Width / 2, Settings.window.Height / 2));
            C = new Cursor(new Vector2(Settings.window.Width / 2, Settings.window.Height / 2));
            Ammo = new Bullet[100];
            for (int i = 0; i < Ammo.Length; i++) Ammo[i] = new Bullet();
            Enemies = new Enemy[10];
            for (int i = 0; i < Enemies.Length; i++) Enemies[i] = new Enemy();
            S = new Spawn();
            H = new HUD();
        }

        // LoadContent
        public static void LoadContent(ContentManager CM) {
            MM.LoadContent(CM);
            P.LoadContent(CM);
            C.LoadContent(CM);
            foreach (Bullet b in Ammo) b.LoadContent(CM);
            foreach (Enemy e in Enemies) e.LoadContent(CM);
            H.LoadContent(CM);
            background = CM.Load<Texture2D>("Content\\Sprites\\background");
            stopWidth = background.Width - 700;
            stopHeight = background.Height - 500;
        }

        // Update
        public static void Update() {
            MoveBackground();
            switch (Settings.state) {
                case Settings.States.Menu :
                    MM.Update();
                    break;
                case Settings.States.Play :
                    P.Update();
                    foreach (Bullet b in Ammo) b.Update();
                    foreach (Enemy e in Enemies) e.Update();
                    C.Update();
                    S.Update();
                    H.Update();
                    break;
                case Settings.States.GameOver :
                    P.Reset();
                    Settings.score = 0;
                    Settings.state = Settings.States.Menu;
                    break;
            }
        }

        // Draw
        public static void Draw(SpriteBatch SB) {
            SB.Draw(background, Vector2.Zero, null, Color.White, MathHelper.ToRadians(0), new Vector2(x, y), 1.0f, SpriteEffects.None, 0);
            switch (Settings.state) {
                case Settings.States.Menu:
                    MM.Draw(SB);
                    break;
                case Settings.States.Play:
                    P.Draw(SB);
                    foreach (Bullet b in Ammo) b.Draw(SB);
                    foreach (Enemy e in Enemies) e.Draw(SB);
                    C.Draw(SB);
                    H.Draw(SB);
                    break;
                case Settings.States.GameOver:

                    break;
            }
        }

        // Shoot bullets
        public static void Shoot(Vector2 position, float direction) {
            if (bulletsFired < Ammo.Count()) {
                Ammo[bulletsFired].index = bulletsFired;
                Ammo[bulletsFired].alive = true;
                Ammo[bulletsFired].position = position;
                Ammo[bulletsFired].direction = direction;
                bulletsFired++;
            }
        }

        // relaod Weapon
        public static void Reload() {
            bulletsFired = 0;
        }

        // setBulletDead
        public static void setBulletDead(int position) {
            Ammo[position].alive = false;
        }

        // Spawn Enemies
        public static void Spawnenemy(Vector2 position) {
            foreach (Enemy e in Enemies)
                if (!e.alive) {
                    e.position = position;
                    e.alive = true;
                    e.Reset();
                    return;
                }
        }

        // Move background
        private static void MoveBackground() {
            if (P.position.Y >= Settings.frame.Height)
                if (y + step < stopHeight)
                    y += step;
            if (P.position.Y <= Settings.frame.Y)
                if (y - step > 0)
                    y -= step;
            if (P.position.X >= Settings.frame.Width)
                if (x + step < stopWidth)
                    x += step;
            if (P.position.X <= Settings.frame.X)
                if (x - step > 0)
                    x -= step;
        }

        // get Enemies
        public static Enemy[] getEnemies() { return Enemies; }

        // get Player
        public static Player getPlayer() { return P; }

    }

}
