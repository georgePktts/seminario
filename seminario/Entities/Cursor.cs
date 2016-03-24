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

    class Cursor : Entity {
        private MouseState mou;

        // Constructor
        public Cursor(Vector2 _position) {
            position = _position;
            textureName = "cursor";
            alive = true;
        }

        //  Update
        public override void Update() {
            mou = Mouse.GetState();
            position = new Vector2(mou.X, mou.Y);
            base.Update();
        }

    }

}
