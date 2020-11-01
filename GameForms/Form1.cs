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
using GameStorage;
using Npgsql;

namespace GameForms
{
    public partial class Form1 : Form
    {
        
        GameArea gameArea;
        Player player;
       List<Enemy> enemy;
        
        List<Chest> chest;
        int blockSize;

        IScoreRepository _scoreRepository;

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



            _scoreRepository = new PostgresScoreRepository();
            
        }
       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            blockSize = panel1.Width / 20;


            label4.Text = CollectChest.ToString();

            var p = sender as Panel;
            var g = e.Graphics;

            gameArea.Clear();
            
            gameArea.DrawScene();

            for (int i = 0; i < StaticParams.N; i++)
            {
                for(int j = 0; j< StaticParams.N; j++)
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
            
            g.DrawImage(Properties.Resources.download__4_, j * blockSize, i * blockSize, blockSize, blockSize);
        }
        private void DrawChest(Graphics g, int i, int j)
        {

            g.DrawImage(Properties.Resources.download__2_, j * blockSize, i * blockSize,blockSize,blockSize);
        }
        private void DrawPlayer(Graphics g)
        {

            g.DrawImage(Properties.Resources.download__1_, player.CoordJ* blockSize, player.CoordI * blockSize, blockSize, blockSize);
        }
        private void DrawEnemy(Graphics g, int i, int j)
        {

            g.DrawImage(Properties.Resources.download__6_, j * blockSize, i * blockSize, blockSize, blockSize);
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
           
        }
        
      

        char d;
        int CollectChest;
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {


            d = e.KeyChar;



            player.Move(d, gameArea);
            foreach (var enemys in enemy)
            {
                if (player.CoordI == enemys.CoordI && player.CoordJ == enemys.CoordJ)
                {
                    this.KeyPreview = false;
                    label6.Text = "You loose";
                    timer1.Stop();
                    timer2.Stop();
                    MessageBox.Show("You Loose", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();

                }
            }

            gameArea.TestChest(player);
            CollectChest = StaticParams.F - gameArea.GetActiveChestCount();

            if (CollectChest < 3)
                label6.Text = "Good";
            else if (CollectChest >= 3 && CollectChest <= 5)
                label6.Text = "Super";


            if (gameArea.GetActiveChestCount() == 0)
            {
                DateTime aDate = DateTime.Now;


                var score = new ScoreModel();
                score.Username = textBox1.Text;
                score.Second = int.Parse(label2.Text);
                score.DateTime = DateTime.Parse(aDate.ToString("yyyy-MM-dd HH:mm:ss"));

                _scoreRepository.Insert(score);


             
                this.KeyPreview = false;
                timer1.Stop();
                timer2.Stop();

                MessageBox.Show("You Win", "Win", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            panel1.Refresh();
        }
      

        int i = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
          
            i++;
            label2.Text = i.ToString();
          
        }




        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Please enter your name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                {
                this.KeyPreview = true;
                timer1.Start();
                timer2.Start();
                textBox1.Enabled = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.Hour.ToString();
            label9.Text = DateTime.Now.Minute.ToString();
            label10.Text = DateTime.Now.Second.ToString();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
