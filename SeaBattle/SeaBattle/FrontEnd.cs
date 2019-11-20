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
    public partial class FrontEnd : Form
    {
        Image miss = Properties.Resources.miss;
        Image sea = Properties.Resources.sea;
        Image shooted = Properties.Resources.shooted;
        Image ship = Properties.Resources.ship;

        const int _size = 10;
        int valueOfClick;
        PictureBox[,] battleGround = new PictureBox[_size, _size];
        PictureBox[,] EbattleGround = new PictureBox[_size, _size];
        public FrontEnd()
        {
            InitializeComponent();
        }

        private void FrontEnd_Load(object sender, EventArgs e)
        {

            drawBattleGround();
            drawEBattleGround();
            

            foreach (PictureBox pict in battleGround)
            {
                pict.Click += (pb, eArgs) =>
                {
                    int x = (Convert.ToInt32(pict.Name)) / 10; 
                    int y = (Convert.ToInt32(pict.Name)) % 10; 
                    
                    if(valueOfClick == -1)
                    {
                        BackEnd.getInstance().destroy(x, y);
                    }
                    else
                    {
                        BackEnd.getInstance().place(x, y, valueOfClick);
                    }

                    check();
                    eCheck();
                };
            }
            foreach (PictureBox picts in EbattleGround)
            {
                picts.Click += (pb, eArgs) =>
                {
                    int x = (Convert.ToInt32(picts.Name)) / 10;
                    int y = (Convert.ToInt32(picts.Name)) % 10;
                    BackEnd.getInstance().shoot(x, y);
                    check();
                    eCheck();
                };
            }
        }
        public void missClick()
        {
            MessageBox.Show("Миссклик");
        }
        public void check()
        {
            for (int i = 0; i != _size; ++i)
            {
                for (int j = 0; j != _size; ++j)
                {
                    if (BackEnd.getInstance().getValueOfGround(i, j) == BackEnd.groundStats.Miss)
                    {
                        battleGround[i, j].Image = miss;
                    }
                    else if (BackEnd.getInstance().getValueOfGround(i, j) == BackEnd.groundStats.Sea)
                    {
                        battleGround[i, j].Image = sea;
                    }
                    else if (BackEnd.getInstance().getValueOfGround(i, j) == BackEnd.groundStats.Ship)
                    {
                        battleGround[i, j].Image = ship;
                    }
                    else if (BackEnd.getInstance().getValueOfGround(i, j) == BackEnd.groundStats.Shooted)
                    {
                        battleGround[i, j].Image = shooted;
                    }
                }
            }
        }
        public void win()
        {
            MessageBox.Show("Вы выиграли!");
        }
        public void outOfCountShip()
        {
            MessageBox.Show("Корабли кончились!");
        }
        public void drawBattleGround()
        {
            const int start = 15;
            int width = start;
            int height = start;
            int size = 30;

            for (int i = 0; i != _size; ++i)
            {
                width = start;
                for (int j = 0; j != _size; ++j)
                {
                    battleGround[i, j] = new PictureBox();
                    battleGround[i, j].Location = new Point(width, height);
                    battleGround[i, j].Size = new Size(size, size);
                    battleGround[i, j].Name = i.ToString() + j.ToString();
                    this.Controls.Add(battleGround[i, j]);
                    width += size;

                }
                height += size;
            }
        }
        public void drawEBattleGround()
        {
            const int start = 485;
            int width = start;
            int height = 15;
            int size = 30;

            for (int i = 0; i != _size; ++i)
            {
                width = start;
                for (int j = 0; j != _size; ++j)
                {
                    EbattleGround[i, j] = new PictureBox();
                    EbattleGround[i, j].Location = new Point(width, height);
                    EbattleGround[i, j].Size = new Size(size, size);
                    EbattleGround[i, j].Name = i.ToString() + j.ToString();
                    this.Controls.Add(EbattleGround[i, j]);
                    width += size;

                }
                height += size;
            }
        }
        public void eCheck()
        {
            for (int i = 0; i != _size; ++i)
            {
                for (int j = 0; j != _size; ++j)
                {
                    if (BackEnd.getInstance().getValueOfGround(i, j) == BackEnd.groundStats.Miss)
                    {
                        EbattleGround[i, j].Image = miss;
                    }
                    else if (BackEnd.getInstance().getValueOfGround(i, j) == BackEnd.groundStats.Sea)
                    {
                        EbattleGround[i, j].Image = sea;
                    }
                    else if (BackEnd.getInstance().getValueOfGround(i, j) == BackEnd.groundStats.Shooted)
                    {
                        EbattleGround[i, j].Image = shooted;
                    }
                }
            }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////


        private void Start_button_Click(object sender, EventArgs e)
        {
            start_button.Visible = false;
            panel1.Visible = true;
            Destroy.Visible = true;
            check();
            eCheck();
        }
        private void Ship1_Click(object sender, EventArgs e)
        {
                valueOfClick = 1;   
        }
        private void Ship2_Click(object sender, EventArgs e)
        {
            valueOfClick = 2;
        }
        private void Ship3_Click(object sender, EventArgs e)
        {
            valueOfClick = 3;
        }
        private void Ship4_Click(object sender, EventArgs e)
        {
            valueOfClick = 4;
        }
        private void EndPlace_Click(object sender, EventArgs e)
        {
            valueOfClick = 0;
            panel1.Visible = false;
            Destroy.Visible = false;
        }
        private void Rotation_Click(object sender, EventArgs e)
        {
            BackEnd.getInstance().doRotation();
            panel2.Visible = true;
            panel1.Visible = false;

        }
        private void Rotation2_Click(object sender, EventArgs e)
        {
            BackEnd.getInstance().doRotation();
            panel2.Visible = false;
            panel1.Visible = true;


        }
        private void RShip1_Click(object sender, EventArgs e)
        {
            valueOfClick = 1;
        }
        private void RShip2_Click(object sender, EventArgs e)
        {
            valueOfClick = 2;
        }
        private void RShip3_Click(object sender, EventArgs e)
        {
            valueOfClick = 3;
        }
        private void RShip4_Click(object sender, EventArgs e)
        {
            valueOfClick = 4;
        }
        private void End_button1_Click(object sender, EventArgs e)
        {
            valueOfClick = 0;
            panel2.Visible = false;
            Destroy.Visible = false;
        }
        private void Destroy_Click(object sender, EventArgs e)
        {

            valueOfClick = -1;
        }
    }
}
 