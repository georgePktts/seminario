using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace seminario {

    class Spawn {
        private Random R = null;
        private int w = 0, h = 0, spawnTime = 0;
        private Vector2 position = Vector2.Zero;

        // Constructor
        public Spawn() {
            R = new Random();
            w = Settings.window.Width;
            h = Settings.window.Height;
        }

        // Update
        public void Update() {
            spawnTime++;
            if (spawnTime > 60 * 3) {
                spawnTime = 0;

                if (R.Next(w) % 2 == 0 && R.Next(h) % 2 == 0)
                    position = new Vector2(0, R.Next(h));
                else if (R.Next(w) % 2 != 0 && R.Next(h) % 2 != 0)
                    position = new Vector2(R.Next(w), 0);
                else if (R.Next(w) % 2 == 0 && R.Next(h) % 2 != 0)
                    position = new Vector2(R.Next(w), h);
                else
                    position = new Vector2(w, R.Next(h));
                EntitiesManager.Spawnenemy(position);
            }
        }

    }

}
