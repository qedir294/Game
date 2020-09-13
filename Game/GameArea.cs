using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class GameArea
    {
        private char[,] _gameArea = new char[StaticParams.N, StaticParams.N];
        private char _emptySymbol = '.';
        private char _wallSymbol = '#';
        List<Wall> walls = new List<Wall>();
        List<Chest> chests = new List<Chest>();
        public GameArea()
        {
            clear();

            for (int i = 0; i < StaticParams.N; i++)
            {
                walls.Add(new Wall());
            }

            foreach (var wall in walls)
            {
                while (!is_empty(wall.CoordI, wall.CoordJ))
                {
                    wall.move();
                }
                draw(wall);
            }
            for (int i = 0; i < StaticParams.F; i++)
            {
                chests.Add(new Chest());
            }

            foreach (var chest in chests)
            {
                while (!is_empty(chest.CoordI, chest.CoordJ))
                {
                    chest.move();
                }
                draw(chest);
            }
        }

        public void clear()
        {
            Console.Clear();

            for (int i = 0; i < StaticParams.N; i++)
            {
                for (int j = 0; j < StaticParams.N; j++)
                {
                    _gameArea[i, j] = _emptySymbol;
                }
            }

            for (int i = 0; i < StaticParams.N; i++)
            {
                _gameArea[0, i] = _wallSymbol;
                _gameArea[i, 0] = _wallSymbol;
                _gameArea[i, StaticParams.N - 1] = _wallSymbol;
                _gameArea[StaticParams.N - 1, i] = _wallSymbol;
            }
        }
        public void Test_chest(GamePoint g_a, ref int c)
        {


            foreach (var chest in chests)
            {
                if (are_player_chest(chest.CoordI, chest.CoordJ, g_a))
                {
                    chest.deactiveate();
                    c++;
                }
            }
        }


        public void draw_scene()
        {
            foreach (var wall in walls)
            {
                draw(wall);
            }
            foreach (var chest in chests)
            {
                if (chest.is_active())
                    draw(chest);
            }
        }
        public bool are_player_chest(int i, int j, GamePoint g_a)
        {
            if (i == g_a.CoordI && j == g_a.CoordJ)
                return true;
            else
                return false;
        }

        public void draw(GamePoint game_point)
        {
            int i = game_point.CoordI;
            int j = game_point.CoordJ;
            char skin = game_point.Skin;

            _gameArea[i, j] = skin;
        }

        public bool is_free(int i, int j)
        {
            return _gameArea[i, j] == _emptySymbol;
        }

        public bool is_wall(int i, int j)
        {
            return _gameArea[i, j] == _wallSymbol;
        }

        public bool is_empty(int i, int j)
        {
            return _gameArea[i, j] == _emptySymbol;
        }

        public bool is_chest(int i, int j)
        {
            foreach (var chest in chests)
            {
                if (i == chest.CoordI && j == chest.CoordJ)
                    return true;
            }

            return false;
        }

        public void print()
        {
            for (int i = 0; i < StaticParams.N; i++)
            {
                for (int j = 0; j < StaticParams.N; j++)
                {
                    Console.Write(_gameArea[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }
    }
}
