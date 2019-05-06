using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyDownTests
{
    public partial class FormKeyDown : Form
    {
        public FormKeyDown()
        {
            InitializeComponent();
        }

        Point targetDirection = new Point(0, 0);

        Point currentPosition = new Point(132, 132);

        Point targetApple = new Point(132, 132);

        public int score = 0;

        public void newApple()
        {
            Random rnd = new Random();

            while (targetApple.X == currentPosition.X && targetApple.Y == currentPosition.Y)
            {
                int appleX = rnd.Next(0, 6);
                int appleY = rnd.Next(0, 6);

                targetApple.X = appleX * 40 + 12;
                targetApple.Y = appleY * 40 + 12;


            }

            pictureBoxApple.Location = targetApple;

            pictureBoxApple.Visible = true;

        }

        private void FormKeyDown_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {



                timerGame.Enabled = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                if (timerGame.Enabled == true)
                {
                    timerGame.Enabled = false;
                }
                else
                {
                    timerGame.Enabled = true;
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                targetDirection.X = -40;
                targetDirection.Y = 0;

            }
            else if (e.KeyCode == Keys.Down)
            {
                targetDirection.X = 0;

                targetDirection.Y = 40;


            }
            else if (e.KeyCode == Keys.Right)
            {
                targetDirection.X = 40;
                targetDirection.Y = 0;

            }
            else if (e.KeyCode == Keys.Up)
            {
                targetDirection.X = 0;

                targetDirection.Y = -40;

            }

        }

        private void FormKeyDown_Load(object sender, EventArgs e)
        {

            newApple();

        }

        public void functionPlay()
        {
            if (currentPosition.Y == 12 && targetDirection.Y == -40)
            {
                currentPosition.Y = 252;
            }
            else if (currentPosition.Y == 252 && targetDirection.Y == 40)
            {
                currentPosition.Y = 12;
            }
            else if (currentPosition.X == 12 && targetDirection.X == -40)
            {
                currentPosition.X = 252;
            }
            else if (currentPosition.X == 252 && targetDirection.X == 40)
            {
                currentPosition.X = 12;
            }
            else
            {
                currentPosition.X = currentPosition.X + targetDirection.X;
                currentPosition.Y = currentPosition.Y + targetDirection.Y;

            }

            if (currentPosition == targetApple)
            {
                newApple();

                if (timerGame.Interval >= 100)
                {
                    timerGame.Interval = timerGame.Interval - 25;
                }

                score++;
                textBoxKey.Text = score.ToString();
            }

            pictureBox1.Location = currentPosition;
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            functionPlay();
            
            textBoxKey.Focus();
        }
    }
}
