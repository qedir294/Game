using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Player : GamePoint
    {
        private const char _KEY_UP = 'w';
        private const char _KEY_DOWN = 's';
        private const char _KEY_LEFT = 'a';
        private const char _KEY_RIGHT = 'd';

        public Player(int player_i, int player_j, char c)
        {
            CoordI = player_i;
            CoordJ = player_j;
            Skin = c;
        }

        public void Move(char d, GameArea g_a)
        {
            int last_i = CoordI;
            int last_j = CoordJ;
            switch (d)
            {
                case _KEY_UP: move_up(); break;
                case _KEY_DOWN: move_down(); break;
                case _KEY_LEFT: move_left(); break;
                case _KEY_RIGHT: move_right(); break;
            }

            if (g_a.IsWall(CoordI, CoordJ))
            {

                CoordI = last_i;
                CoordJ = last_j;
            }
        }
    }

}
