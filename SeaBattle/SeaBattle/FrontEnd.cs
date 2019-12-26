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
        Image turnPlayer1 = Properties.Resources.turnPlayer1;
        Image turnPlayer2 = Properties.Resources.turnPlayer2;

        static BackEnd _backEnd = new BackEnd();
        static BackEnd _EbackEnd = new BackEnd();

        bool isWeb = false;

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

            foreach (PictureBox picts in EbattleGround)
            {
                picts.Click += (pb, eArgs) =>
                {
                    
                    int x = (Convert.ToInt32(picts.Name)) / 10;
                    int y = (Convert.ToInt32(picts.Name)) % 10;

                    if (valueOfClick == -1)
                    {
                        if (Players.getInstance().getTurn2() == true)
                        {
                            _EbackEnd.destroy(x, y);
                        }
                        else
                        {
                            missClick();
                        }
                    }
                    else if (valueOfClick == 11)
                    {
                        if (Players.getInstance().getTurn1() == true)
                        {
                            _EbackEnd.shoot(x, y);
                            eCheck(x, y);
                        }
                        else
                        {
                            missClick();
                        }
                    }
                    else
                    {
                        if (Players.getInstance().getTurn2() == true)
                        {
                            _EbackEnd.place(x, y, valueOfClick);
                            fullECheck();
                        }
                        else
                        {
                            missClick();
                        }
                    }
                    
                };
            }    
            
            foreach (PictureBox pict in battleGround)
            {
                pict.Click += (pb, eArgs) =>
                {
                    Console.WriteLine("Hello, battel");
                    int x = (Convert.ToInt32(pict.Name)) / 10;
                    int y = (Convert.ToInt32(pict.Name)) % 10;
            
                    if (valueOfClick == -1)
                    {
                        if (Players.getInstance().getTurn1() == true)
                        {
                            _backEnd.destroy(x, y);
                        }
                        else
                        {
                            missClick();
                        }
                    }
                    else if (valueOfClick == 11)
                    {
                        if (Players.getInstance().getTurn2() == true)
                        {
                            _backEnd.shoot(x, y);
                            check(x, y);
                        }
                        else
                        {
                            missClick();
                        }
                    }
                    else
                    {
                        if (Players.getInstance().getTurn1() == true)
                        {
                            _backEnd.place(x, y, valueOfClick);
                            fullCheck();
                        }
                        else
                        {
                            missClick();
                        }
                    }
                    Console.WriteLine(pict.Name);
                };
            }            
        }
        public void missClick()
        {
            MessageBox.Show("Миссклик");
        }
        public void check(int i, int j)
        {
            if (_backEnd.getValueOfGround(i, j) == BackEnd.groundStats.Miss)
            {
                battleGround[i, j].Image = miss;
            }
            else if (_backEnd.getValueOfGround(i, j) == BackEnd.groundStats.Sea)
            {
                battleGround[i, j].Image = sea;
            }
            else if (_backEnd.getValueOfGround(i, j) == BackEnd.groundStats.Ship)
            {
                battleGround[i, j].Image = ship;
            }
            else if (_backEnd.getValueOfGround(i, j) == BackEnd.groundStats.Shooted)
            {
                battleGround[i, j].Image = shooted;
                for (i = 0; i != _size; ++i)
                {
                    for (j = 0; j != _size; ++j)
                    {
                        if (_backEnd.getValueOfGround(i, j) == BackEnd.groundStats.Miss)
                        {
                            battleGround[i, j].Image = miss;
                        }
                    }
                }
            }
            arrowTurn();
        }
        public void fullCheck()
        {
            for (int i = 0; i != _size; ++i)
            {
                for (int j = 0; j != _size; ++j)
                {
                    check(i, j);
                }
            }
            arrowTurn();
        }
        public void fullECheck()
        {
            for (int i = 0; i != _size; ++i)
            {
                for (int j = 0; j != _size; ++j)
                {
                    eCheck(i, j);
                }
            }
            arrowTurn();
        }
        public void eCheck(int i, int j)
        {
            if (_EbackEnd.getValueOfGround(i, j) == BackEnd.groundStats.Miss)
            {
                EbattleGround[i, j].Image = miss;
            }
            else if (_EbackEnd.getValueOfGround(i, j) == BackEnd.groundStats.Sea)
            {
                EbattleGround[i, j].Image = sea;
            }
            else if (_EbackEnd.getValueOfGround(i, j) == BackEnd.groundStats.Ship)
            {
                EbattleGround[i, j].Image = ship;
            }
            else if (_EbackEnd.getValueOfGround(i, j) == BackEnd.groundStats.Shooted)
            {
                EbattleGround[i, j].Image = shooted;
                for (i = 0; i != _size; ++i)
                {
                    for (j = 0; j != _size; ++j)
                    {
                        if (_EbackEnd.getValueOfGround(i, j) == BackEnd.groundStats.Miss)
                        {
                            EbattleGround[i, j].Image = miss;
                        }
                    }
                }
            }
            arrowTurn();

        }
        public void win()
        {

            string winner = Players.getInstance().win();
            MessageBox.Show("Побеждает, " + winner + "!");
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
        public void arrowTurn()
        {
            if(Players.getInstance().getTurn1() == true)
            {
                pictureBox_turn.Image = turnPlayer1;
            }
            else
            {
                pictureBox_turn.Image = turnPlayer2;
            }   
        }
        public void Fill()
        {
            for (int i = 0; i != _size; ++i)
            {
                for (int j = 0; j != _size; ++j)
                {
                    battleGround[i, j].Image = sea;
                }
            }
        }
        public void eFill()
        {
            for (int i = 0; i != _size; ++i)
            {
                for (int j = 0; j != _size; ++j)
                {
                    EbattleGround[i, j].Image = sea;
                }
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////


        private void Start_button_Click(object sender, EventArgs e) 
        {
            start_button.Visible = false;
            panel1.Visible = true;
            Destroy.Visible = true;
            End_button.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            
            Fill();
            eFill();
            MessageBox.Show("Расставляет корабли: Игрок1");
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
        private void Rotation_Click(object sender, EventArgs e)
        {
            _backEnd.doRotation();
            _EbackEnd.doRotation();
            panel2.Visible = true;
            panel1.Visible = false;

        }
        private void Rotation2_Click(object sender, EventArgs e)
        {
            _backEnd.doRotation();
            _EbackEnd.doRotation();
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
        private void Destroy_Click(object sender, EventArgs e)
        {

            valueOfClick = -1;
        }
        private void End_button_Click(object sender, EventArgs e)
        {
            if(Players.getInstance().getTurn1() == true)
            {
                Players.getInstance().changeTurn();
                Ship _ship = new Ship("reset");
                Fill();
                MessageBox.Show("Расставляет корабли: Игрок2");
            }
            else
            {
                Players.getInstance().changeTurn();
                eFill();
                valueOfClick = 11;
                panel1.Visible = false;
                Destroy.Visible = false;
                panel2.Visible = false;
                End_button.Visible = false;
                pictureBox_turn.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void OneComp_Click(object sender, EventArgs e)
        {
            OneComp.Visible = false;
            Web.Visible = false;
            start_button.Visible = true;

        }

        private void Web_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В разработке");
        }
    }
}
 