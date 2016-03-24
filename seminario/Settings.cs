using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace seminario {

    class Settings {
        // Title
        public static string title = "ablaoubla";
        // Window dimension
        public static Rectangle window = new Rectangle(0, 0, 700, 500);
        // Frame dimension
        public static Rectangle frame = new Rectangle(250, 200, window.Width - 250, window.Height - 200);
        // States
        public enum States { Play, Exit, Menu, GameOver }
        public static States state = States.Menu;
        // score
        public static int score = 0;
    }

}
