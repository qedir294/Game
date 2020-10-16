using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Enemy : GamePoint
    {

        public Enemy()
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
            } while (g_a.IsWall(CoordI, CoordJ) || g_a.IsChestCoord(CoordI, CoordJ));
        }
    }
}
