﻿using System;
using System.Collections.Generic;
using System.Text;
using Game;



namespace Game
{
    public class GameArea
    {
        private char[,] _gameArea = new char[StaticParams.N, StaticParams.N];
        private char _emptySymbol = '.';
        private char _wallSymbol = '#';
        List<Wall> walls = new List<Wall>();
        List<Chest> chests = new List<Chest>();
     
        public GameArea()
        {
            Clear();

            for (int i = 0; i < StaticParams.N; i++)
            {
                walls.Add(new Wall());
            }

            foreach (var wall in walls)
            {
                while (!IsEmpty(wall.CoordI, wall.CoordJ))
                {
                    wall.move();
                }
                Draw(wall);
            }

            for (int i = 0; i < StaticParams.F; i++)
            {
                chests.Add(new Chest());
            }

            foreach (var chest in chests)
            {
                while (!IsEmpty(chest.CoordI, chest.CoordJ))
                {
                    chest.move();
                }
                Draw(chest);
                
            }
        }
        public Chest GetChest(int i)
        {
            return chests[i];
        }
       
        
        
        public void Clear()
        {

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
        public void TestChest(Player player)
        {


            foreach (var chest in chests)
            {
                if (ArePlayerChest(chest.CoordI, chest.CoordJ, player))
                {
                    chest.deactiveate();
                
                }
            }
        }
        public int GetActiveChestCount()
        {
            int c = 0;
            foreach (var chest in chests)
            {
                if (chest.is_active())
                {
               
                    c++;
                }
            }
            return c;
        }
        public void DrawScene()
        {
            foreach (var wall in walls)
            {
                Draw(wall);
            }
            foreach (var chest in chests)
            {
                if (chest.is_active())
                    Draw(chest);
            }
        }

        public bool ArePlayerChest(int i, int j, GamePoint g_a)
        {
            if (i == g_a.CoordI && j == g_a.CoordJ)
                return true;
            else
                return false;
        }

        public void Draw(GamePoint game_point)
        {
            int i = game_point.CoordI;
            int j = game_point.CoordJ;
            char skin = game_point.Skin;

            _gameArea[i, j] = skin;
        }

        public bool IsFree(int i, int j)
        {
            return _gameArea[i, j] == _emptySymbol;
        }

        public bool IsWall(int i, int j)
        {
            return _gameArea[i, j] == _wallSymbol;
        }

        public bool IsEmpty(int i, int j)
        {
            return _gameArea[i, j] == _emptySymbol;
        }
        public bool IsChestSkin(int i, int j)
        {
            foreach (var chest in chests)
            {
                if (_gameArea[i, j] == chest.Skin)
                    return true;
            }
          
          return false;
        }


        public bool IsChestCoord(int i, int j)
        {
            foreach (var chest in chests)
            {
                if (i == chest.CoordI && j == chest.CoordJ)
                    return true;
            }

            return false;
        }

        public char GetSymbol(int i, int j)
        {
            return _gameArea[i, j];
        }
    }
}
