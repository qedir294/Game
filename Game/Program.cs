﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "Game Point";
            Console.WriteLine("Input player skin (symbol): ");
            char skin = char.Parse(Console.ReadLine());

            Player player = new Player(20 / 2, 20 / 2, skin);
            GameArea game_area = new GameArea();
            List<Enemy> enemies = new List<Enemy>();
            for (int i = 0; i < StaticParams.F; i++)
            {
                enemies.Add(new Enemy());
            }

            char d;
            int a = 0, c = 0;
            do
            {
                d = Console.ReadKey().KeyChar;

                game_area.Clear();
                game_area.TestChest(player, ref c);
                game_area.DrawScene();

                foreach (var enemy in enemies)
                {
                    enemy.move(game_area);
                }

                player.Move(d, game_area);

                foreach (var enemy in enemies)
                {
                    game_area.Draw(enemy);
                }

                game_area.Draw(player);

                game_area.Print();

                if (c == StaticParams.F)
                {
                    Console.WriteLine("You Win");
                    break;
                }

                foreach (var enemy in enemies)
                {
                    if (player.CoordI == enemy.CoordI && player.CoordJ == enemy.CoordJ)
                    {

                        Console.WriteLine("Game Over!\n");
                        Console.WriteLine("Press to key to exit...");
                        a = 1;
                        break;
                    }

                }
                if (a == 1)
                    break;
            } while (true);

        }
    }
}
    

    
