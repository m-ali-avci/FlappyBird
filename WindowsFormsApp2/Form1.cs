using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int gravity = 8;
        readonly int pipeSpeed = 8;
        int score = 0;
        readonly int gap = 150;
        readonly Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;

            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = 20;
            gameTimer.Start();

            bird.Left = 100;
            bird.Top = 200;

            ground.Top = this.ClientSize.Height - ground.Height;

            ResetPipes();
            scoreText.Text = "Skor: 0";

            ground.BringToFront();
            pipeBottom.SendToBack();
            pipeTop.SendToBack();
            bird.BringToFront();

            this.Resize += (s, e) =>
            {
                ground.Top = this.ClientSize.Height - ground.Height;
            };
        }
        private void ResetPipes()
        {
            int minTopHeight = 50;
            int minBottomHeight = 50;

            int maxTopHeight = Math.Max(minTopHeight, ground.Top - gap - minBottomHeight);
            int topHeight = rnd.Next(minTopHeight, maxTopHeight + 1);

            pipeTop.Top = 0;
            pipeTop.Height = topHeight;

            pipeBottom.Height = ground.Top - pipeTop.Height - gap;
            pipeBottom.Top = ground.Top - pipeBottom.Height;

            int offset = rnd.Next(120, 300);
            int startX = this.ClientSize.Width + offset;
            pipeTop.Left = startX;
            pipeBottom.Left = startX;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            bird.Top += gravity;

            pipeTop.Left -= pipeSpeed;
            pipeBottom.Left -= pipeSpeed;

            if (pipeTop.Left < -pipeTop.Width)
            {
                score++;
                scoreText.Text = "Skor: " + score;
                ResetPipes();
            }

            if (bird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                bird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                bird.Bounds.IntersectsWith(ground.Bounds) ||
                bird.Top < 0)
            {
                GameOver();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                gravity = -10;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                gravity = 8;

            if (e.KeyCode == Keys.R && !gameTimer.Enabled)
                RestartGame();
        }

        private void GameOver()
        {
            gameTimer.Stop();
            scoreText.Text = "Oyun bitti! Skor: " + score + " (R ile tekrar)";
        }

        private void RestartGame()
        {
            score = 0;
            gravity = 8;
            scoreText.Text = "Skor: 0";

            bird.Left = 100;
            bird.Top = Math.Min(200, ground.Top - bird.Height - 10);

            ResetPipes();
            gameTimer.Start();
        }

    }
}
