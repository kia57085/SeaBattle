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

        int edBackEnd = 2;
        int shoot = -1;

        int[,] backEnd = new int[10, 10];
        PictureBox[,] battleGround = new PictureBox[10, 10];


        private void Form1_Load(object sender, EventArgs e)
        {

            const int start = 15;
            int width = start;
            int height = start;
            int size = 30;


            for (int i = 0; i != 10; ++i)
            {
                width = start;
                for(int j = 0; j != 10; ++j)
                {
                    battleGround[i, j] = new PictureBox();
                    battleGround[i, j].Location = new Point(width, height);
                    battleGround[i, j].Size = new Size(size, size);
                    battleGround[i, j].BackColor = Color.Gray;
                    battleGround[i, j].Name = i.ToString() + j.ToString();
                    this.Controls.Add(battleGround[i, j]);
                    width += size;
                   
                }
                height += size;
            }

            for(int i = 0; i != 10; ++i)
            {
                for(int j = 0; j != 10; ++j)
                {
                    backEnd[i, j] = 0;
                }
            }


            foreach(PictureBox pict in battleGround)
            {
                pict.Click += (pb, eArgs) =>
                    {
                        int i = (Convert.ToInt32(pict.Name)) / 10;
                        int j = (Convert.ToInt32(pict.Name)) % 10;

                        if(edBackEnd == -1)
                        {
                            backEnd[i, j] += shoot;
                        }
                        else if(edBackEnd >= 2)
                        {
                            for(int u = 0; u != edBackEnd-1; ++u)
                            {
                                backEnd[i, j + u] += 2;
                                Console.WriteLine(backEnd[i, j + u]);
                                check();
                            }                          
                        }                       
                        check();
                    };
                  
            }

        }

        void check()
        {
            for (int i = 0; i != 10; ++i)
            {
                for (int j = 0; j != 10; ++j)
                {
                    
                    if (backEnd[i, j] == 0)
                    {
                        battleGround[i, j].Image = sea;
                    }
                    else if (backEnd[i, j] == 1)
                    {
                        battleGround[i, j].Image = shooted;
                    }
                    else if (backEnd[i, j] > 1)
                    {
                        battleGround[i, j].Image = ship;
                    }
                    else if (backEnd[i, j] == -1)
                    {
                        battleGround[i, j].Image = miss;
                    }
                }
            }
        }
        private void Start_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i != 10; ++i)
            {
                for (int j = 0; j != 10; ++j)
                {

                    battleGround[i, j].Image = sea;
                    backEnd[i, j] = 0;

                }
            }
        }

        private void Ship1_Click(object sender, EventArgs e)
        {
            edBackEnd = 2;
        }

        private void Ship2_Click(object sender, EventArgs e)
        {
            edBackEnd = 3;
        }

        private void Ship3_Click(object sender, EventArgs e)
        {
            edBackEnd = 4;
        }

        private void Ship4_Click(object sender, EventArgs e)
        {
            edBackEnd = 5;
        }

        private void EndPlace_Click(object sender, EventArgs e)
        {
            edBackEnd = -1;
        }
    }
}
 