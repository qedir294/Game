using System;
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

            Random rnd = new Random((int)DateTime.Now.Ticks);
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

                game_area.clear();
                game_area.Test_chest(player, ref c);
                game_area.draw_scene();

                foreach (var enemy in enemies)
                {
                    enemy.move(game_area);
                }

                player.Move(d, game_area);

                foreach (var enemy in enemies)
                {
                    game_area.draw(enemy);
                }

                game_area.draw(player);

                game_area.print();

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
    

    
