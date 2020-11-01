using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class GamePoint
    {
        private int _coordI;
        public int CoordI
        {
            get

            {
                return _coordI;
            }
            set
            {
                if (value > 0 && value < StaticParams.N - 1)
                    _coordI = value;
            }
        }

        private int _coordJ;
        public int CoordJ
        {
            get
            {
                return _coordJ;
            }
            set
            {
                if (value > 0 && value < StaticParams.N - 1)
                    _coordJ = value;
            }
        }


        protected char _skin;
        public char Skin
        {
            get
            {
                return _skin;
            }
            set
            {
                _skin = value;
            }
        }
        static public Random rnd;
        static GamePoint()
        {
            rnd = new Random((int)DateTime.Now.Ticks);
        }

        public GamePoint()
        {
            CoordI = rnd.Next(1, 19);
            CoordJ = rnd.Next(1, 19);
        }

        public void move_left()
        {
            if (_coordJ > 1)
                _coordJ--;
        }

        public void move_right()
        {
            if (_coordJ < StaticParams.N - 1)
                _coordJ++;
        }

        public void move_up()
        {
            if (_coordI > 1)
                _coordI--;
        }

        public void move_down()
        {
            if (_coordI < StaticParams.N - 1)
                _coordI++;
        }

        public void move()
        {
            int r = rnd.Next(0, 4);

            switch (r)
            {
                case 0: move_up(); break;
                case 1: move_down(); break;
                case 2: move_right(); break;
                case 3: move_left(); break;
            }
        }
    }
}
