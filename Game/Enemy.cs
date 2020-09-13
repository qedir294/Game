using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Enemy : GamePoint
    {

        public Enemy() : base()
        {
            Skin = '@';
        }

        public void move(GameArea g_a)
        {
            int last_i = CoordI;
            int last_j = CoordJ;
            int i = 0;

            do
            {
                CoordI = last_i;
                CoordJ = last_j;

                move();

                i++;
                if (i > 10)
                    break;
            } while (g_a.is_wall(CoordI, CoordJ) || g_a.is_chest(CoordI, CoordJ));
        }
    }
}
