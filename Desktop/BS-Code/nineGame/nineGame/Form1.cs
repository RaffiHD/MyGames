using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nineGame
{
    public partial class Nine : Form
    {
        public Nine()
        {
            InitializeComponent();
        }

        public int position = 1;

        public int fishPosition = 3;

        public int score = 0;

        public void methodeUp()
        {
            if (position == 1)
            {
                position = 5;
                field1.Visible = false;
                field5.Visible = true;
            }
            else if (position == 2)
            {
                position = 1;
                field2.Visible = false;
                field1.Visible = true;
            }
            else if (position == 3)
            {
                position = 2;
                field3.Visible = false;
                field2.Visible = true;
            }
            else if (position == 4)
            {
                position = 3;
                field4.Visible = false;
                field3.Visible = true;
            }
            else if (position == 5)
            {
                position = 4;
                field5.Visible = false;
                field4.Visible = true;
            }

            if (position == fishPosition)
            {
                spawnFish();
            }
        }

        public void methodeDown()
        {
            if (position == 1)
            {
                position = 2;
                field1.Visible = false;
                field2.Visible = true;
            }
            else if (position == 2)
            {
                position = 3;
                field2.Visible = false;
                field3.Visible = true;
            }
            else if (position == 3)
            {
                position = 4;
                field3.Visible = false;
                field4.Visible = true;
            }
            else if (position == 4)
            {
                position = 5;
                field4.Visible = false;
                field5.Visible = true;
            }
            else if (position == 5)
            {
                position = 1;
                field5.Visible = false;
                field1.Visible = true;
            }


            if (position == fishPosition)
            {
                spawnFish();
            }
        }

        public void spawnFish()
        {

            score++;

            textBoxCounter.Text = score.ToString();

            fish1.Visible = false;
            fish2.Visible = false;
            fish3.Visible = false;
            fish4.Visible = false;
            fish5.Visible = false;

            Random rndm = new Random();

            while (fishPosition == position)
            {
                fishPosition = rndm.Next(1, 5);
            }

            if (fishPosition == 1)
            {
                fish1.Visible = true;
            }
            else if (fishPosition == 2)
            {
                fish2.Visible = true;
            }
            else if (fishPosition == 3)
            {
                fish3.Visible = true;
            }
            else if (fishPosition == 4)
            {
                fish4.Visible = true;
            }
            else if (fishPosition == 5)
            {
                fish5.Visible = true;
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {

            methodeUp();

        }

        private void buttonDown_Click(object sender, EventArgs e)
        {

            methodeDown();
        }

        private void Nine_Load(object sender, EventArgs e)
        {

        }

        private void Nine_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Up)
            {
                methodeUp();
            }
            else if(e.KeyCode == Keys.Down)
            {
                methodeDown();
            }

        }

        private void Nine_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
