using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game;

namespace GameForms
{
    public partial class Form1 : Form
    {
        GameArea gameArea;
        Player player;
       List<Enemy> enemy;
        int blockSize = 10;
        List<Chest> chest;

        public Form1()
        {
            InitializeComponent();
            enemy = new List<Enemy>();
            gameArea = new GameArea();
            player = new Player(StaticParams.N / 2, StaticParams.N / 2, '&');
            for (int i = 0; i < StaticParams.F; i++)
            {
                enemy.Add(new Enemy());

            }
             chest = new List<Chest>();
        


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;

            gameArea.Clear();
            
            gameArea.DrawScene();

            for (int i = 0; i < StaticParams.N; i++)
            {
                for (int j = 0; j < StaticParams.N; j++)
                {
                    if (gameArea.IsWall(i, j))
                        DrawWall(g, i, j);
                    if (gameArea.IsChestSkin(i, j))
                    {

                        DrawChest(g, i, j);

                    }
                }
            }

            DrawPlayer(g);

            foreach (var enemys in enemy)
            {
                DrawEnemy(g, enemys.CoordI, enemys.CoordJ);
            }

        }






      

        private void DrawWall(Graphics g, int i, int j)
        {
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(j * blockSize, i * blockSize, blockSize, blockSize));
        }
        private void DrawChest(Graphics g, int i, int j)
        {
            g.FillRectangle(new SolidBrush(Color.Orange), new Rectangle(j * blockSize, i * blockSize, blockSize, blockSize));
        }
        private void DrawPlayer(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Green), new Rectangle(player.CoordJ * blockSize, player.CoordI * blockSize, blockSize, blockSize));
        }
        private void DrawEnemy(Graphics g, int i, int j)
        {
            g.FillRectangle(new SolidBrush(Color.Red), new Rectangle(j * blockSize, i * blockSize, blockSize, blockSize));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Refresh();

            foreach (var enemys in enemy)
            {
                enemys.move(gameArea);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();

        }        
           
        
       
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

           
            char d = e.KeyChar;
           
            player.Move(d,gameArea);
            foreach (var enemys in enemy)
            {
                if (player.CoordI == enemys.CoordI && player.CoordJ == enemys.CoordJ)
                {
                    timer1.Stop();
                    MessageBox.Show("You Loose","Warning",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    Application.Exit();
                
                }
                    }
            gameArea.TestChest(player);
            if(gameArea.GetActiveChestCount() == 0)
            {
                timer1.Stop();
                MessageBox.Show("You Win", "Win", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            panel1.Controls.Clear();
            panel1.Refresh();

        }
    }
}
