using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    public partial class Form1 : Form
    {
        dynamic miss = Properties.Resources.ground01;
        dynamic sea = Properties.Resources.ground0;
        dynamic shooted = Properties.Resources.ground1;
        dynamic ship = Properties.Resources.ground2;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = ship;
            pictureBox2.Image = ship;
            pictureBox3.Image = ship;

            pictureBox11.Image = ship;
            pictureBox12.Image = ship;
            pictureBox13.Image = ship;

            pictureBox21.Image = ship;
            pictureBox22.Image = ship;
            pictureBox23.Image = ship;
        }

        int[,] battleGround = new int[10, 10];
        private void PictureBox1_Click(object sender, EventArgs e)
        {

            --battleGround[0, 0];
            int val = battleGround[0, 0];

            if(val == -1)
            {
                pictureBox1.Image = miss;
            }
            else if(val == 1)
            {
                pictureBox1.Image = shooted;
            }
            else if(val == 2)
            {
                pictureBox1.Image = (ship);
            }
        }
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            --battleGround[0, 1];
            int val = battleGround[0, 1];

            if (val == -1)
            {
                pictureBox2.Image = miss;
            }
            else if (val == 1)
            {
                pictureBox2.Image = shooted;
            }
            else if (val == 2)
            {
                pictureBox2.Image = (ship);
            }
        }
        private void PictureBox3_Click(object sender, EventArgs e)
        {
            --battleGround[0, 2];
            int val = battleGround[0, 2];

            if (val == -1)
            {
                pictureBox3.Image = miss;
            }
            else if (val == 1)
            {
                pictureBox3.Image = shooted;
            }
            else if (val == 2)
            {
                pictureBox3.Image = ship;
            }
        }
        private void PictureBox11_Click(object sender, EventArgs e)
        {
            --battleGround[1, 0];
            int val = battleGround[1, 0];

            if (val == -1)
            {
                pictureBox11.Image = miss;
            }
            else if (val == 1)
            {
                pictureBox11.Image = shooted;
            }
            else if (val == 2)
            {
                pictureBox11.Image = ship;
            }
        }
        
        private void PictureBox12_Click(object sender, EventArgs e)
        {
            --battleGround[1, 1];
            int val = battleGround[1, 1];

            if (val == -1)
            {
                pictureBox12.Image = miss;
            }
            else if (val == 1)
            {
                pictureBox12.Image = shooted;
            }
            else if (val == 2)
            {
                pictureBox12.Image = ship;
            }
        }
        private void PictureBox13_Click(object sender, EventArgs e)
        {
            --battleGround[1, 2];
            int val = battleGround[1, 2];

            if (val == -1)
            {
                pictureBox13.Image = miss;
            }
            else if (val == 1)
            {
                pictureBox13.Image = shooted;
            }
            else if (val == 2)
            {
                pictureBox13.Image = ship;
            }
        }
        private void PictureBox21_Click(object sender, EventArgs e)
        {
            --battleGround[2, 0];
            int val = battleGround[2, 0];

            if (val == -1)
            {
                pictureBox21.Image = miss;
            }
            else if (val == 1)
            {
                pictureBox21.Image = shooted;
            }
            else if (val == 2)
            {
                pictureBox21.Image = ship;
            }
        }
        private void PictureBox22_Click(object sender, EventArgs e)
        {
            --battleGround[2, 1];
            int val = battleGround[2, 1];

            if (val == -1)
            {
                pictureBox22.Image = miss;
            }
            else if (val == 1)
            {
                pictureBox22.Image = shooted;
            }
            else if (val == 2)
            {
                pictureBox22.Image = ship;
            }
        }

        private void PictureBox23_Click(object sender, EventArgs e)
        {
            --battleGround[2, 2];
            int val = battleGround[2, 2];

            if (val == -1)
            {
                pictureBox23.Image = miss;
            }
            else if (val == 1)
            {
                pictureBox23.Image = shooted;
            }
            else if (val == 2)
            {
                pictureBox23.Image = ship;
            }
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i != 10; ++i)
            {
                for (int j = 0; j != 10; ++j)
                {
                    battleGround[i, j] = 2;
                }
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

    }
}
