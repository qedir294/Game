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
            bool isLoose =false;
            do
            {
                d = Console.ReadKey().KeyChar;

                Console.Clear();
                game_area.Clear();
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
                game_area.TestChest(player);

                game_area.Draw(player);


                for (int i = 0; i < StaticParams.N; i++)
                {
                    for (int j = 0; j < StaticParams.N; j++)
                    {
                        Console.Write(game_area.GetSymbol(i, j));
                        Console.Write(' ');
                    }
                    Console.WriteLine();
                }

                if (game_area.GetActiveChestCount() == 0)
                {
                    Console.WriteLine("You Win");
                    break;
                }

                foreach (var enemy in enemies)
                {
                    if (player.CoordI == enemy.CoordI && player.CoordJ == enemy.CoordJ)
                    {

                        Console.WriteLine("You loose!\n");
                        isLoose = true;
                        break;
                    }

                }
                if (isLoose)
                    break;
            } while (true);
            Console.WriteLine("Game Over!\n");
            Console.WriteLine("Press to key to exit...");
            Console.ReadLine();

        }
    }
}
    

    
