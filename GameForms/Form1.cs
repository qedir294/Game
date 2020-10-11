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
        int blockSize = 10;

        public Form1()
        {
            InitializeComponent();

            gameArea = new GameArea();
            player = new Player(StaticParams.N / 2, StaticParams.N / 2, '&');
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            var p = sender as Panel;
            var g = e.Graphics;


            for (int i = 0; i < StaticParams.N; i++)
            {
                for (int j = 0; j < StaticParams.N; j++)
                {
                    if (gameArea.IsWall(i, j))
                        DrawWall(g, i, j);
                    if (gameArea.IsChest(i, j))
                        DrawChest(g, i, j);
                   
                }
            }
            DrawPlayer(g);
        }

        private void DrawWall(Graphics g, int i, int j)
        {
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(i * blockSize, j * blockSize, blockSize, blockSize));
        }
        private void DrawChest(Graphics g, int i, int j)
        {
            g.FillRectangle(new SolidBrush(Color.Orange), new Rectangle(i * blockSize, j * blockSize, blockSize, blockSize));
        }
        private void DrawPlayer(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Green), new Rectangle(player.CoordI * blockSize, player.CoordJ * blockSize, blockSize, blockSize));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            player.move();
            panel1.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
