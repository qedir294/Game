using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Chest : GamePoint
    {
        private bool _activation;
        public Chest() : base()
        {
            Skin = '$';
            _activation = true;
        }

        public bool is_active()
        {
            return _activation;
        }

        public void deactiveate()
        {
            _activation = false;
        }
    }
}

