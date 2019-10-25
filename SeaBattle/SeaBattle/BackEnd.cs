using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    class BackEnd
    {
        static BackEnd instance;
        bool rotation = false;
        int[,] backEnd = new int[10, 10];
        Ship[,] ships = new Ship[10, 10];
        FrontEnd frontEnd = new FrontEnd();
        enum groundStats
        {
            Miss,
            Sea,
            Shooted,
            Ship
        }
        BackEnd()
        {
            Fill();
        }

        public static BackEnd getInstance()
        {
            if (instance == null)
                instance = new BackEnd();
            return instance;
        }
        public void MissAroundKill(int x, int y, int length)
        {
           for(int i = -1; i != 1; ++i)
            {
                for(int j = -1; j != length; ++j)
                {
                    if (i == 0)
                    {
                        if (j == 0 || j == length)
                        {
                            backEnd[x + j, y + i] = -1;
                        }
                    }
                    else backEnd[x + j, y + i] = -1;
                }
            }
        }
        public void Fill()
        {
            for (int i = 0; i != 10; ++i)
            {
                for (int j = 0; j != 10; ++j)
                {
                    backEnd[i, j] = (int)groundStats.Sea;
                }
            }
        }
        public bool checkRotation()
        {
            return rotation;
        }
        public void doRotation()
        {
            if (rotation == false)
            {
                rotation = true;
            }
            else rotation = false;
        }
        public void shoot(int x, int y)
        {
            if (getValueOfGround(x, y) == (int)groundStats.Miss)
            {
                frontEnd.missClick();
            }
            else if (getValueOfGround(x, y) == (int)groundStats.Sea)
            {
                setValueOfGround(x, y, (int)groundStats.Miss);
            }
            else if (getValueOfGround(x, y) == (int)groundStats.Shooted)
            {
                frontEnd.missClick();
            }
            else if (getValueOfGround(x, y) == (int)groundStats.Ship)
            {
                setValueOfGround(x, y, (int)groundStats.Shooted);
                ships[x, y].HelloFrom();
                ships[x, y].shoot();
                Console.WriteLine(ships[x, y].getHp());
                checkForLife(x, y);
            }
            
        }
        public void install(int x, int y, int length)
        {
            if(length == 1)
            {
                ships[x, y] = new ship1();
                ships[x, y].setCoord(x, y);
                ships[x, y].setRotation(rotation);
            }
            else if(length == 2)
            {
                ships[x, y] = new ship2();
                ships[x, y].setCoord(x, y);
                ships[x, y].setRotation(rotation);
            }
            else if (length == 3)
            {
                ships[x, y] = new ship3();
                ships[x, y].setCoord(x, y);
                ships[x, y].setRotation(rotation);
            }
            else if (length == 4)
            {
                ships[x, y] = new ship4();
                ships[x, y].setCoord(x, y);
                ships[x, y].setRotation(rotation);
            }
        }
        public void place(int x, int y, int length)
        {
            if (ships[x, y] == null)
            {
                if (rotation == false)
                {
                    while (length + y > 10)
                    {
                        --y;
                    }
                    install(x, y, length);
                    for (int i = 0; i != length; ++i)
                    {
                        setValueOfGround(x, y + i, (int)groundStats.Ship);
                        ships[x, y + i] = ships[x, y];
                    }
                }
                else
                {
                    while (length + x > 10)
                    {
                        --x;
                    }
                    install(x, y, length);
                    for (int i = 0; i != length; ++i)
                    {
                        setValueOfGround(x + i, y, (int)groundStats.Ship);
                        ships[x + i, y] = ships[x, y];
                    }
                }
            }
            else frontEnd.missClick();

        }
        public int getValueOfGround(int x, int y)
        {
            return backEnd[x, y];
        }
        public void setValueOfGround(int x, int y, int value)
        {
            backEnd[x, y] = value;
        }
        public void kill(int x0, int y0, int length)
        {
            int x = ships[x0, y0].getCoordX();
            int y = ships[x0, y0].getCoordY();
            if (ships[x0, y0].getRotation() == false)
            {
                for (int i = -1; i <= 1; ++i)
                {
                    if (i == 0)
                    {
                        backEnd[x, y - 1] = (int)groundStats.Miss;
                        backEnd[x, y + length] = (int)groundStats.Miss;
                    }
                    else
                    {
                        for (int j = -1; j <= length; ++j)
                        {
                            backEnd[x + i, y + j] = (int)groundStats.Miss;
                        }
                    }
                }
            }
            else
            {
                for (int j = -1; j <= 1; ++j)
                {
                    if (j == 0)
                    {
                        backEnd[x - 1, y] = (int)groundStats.Miss;
                        backEnd[x + length, y] = (int)groundStats.Miss;
                    }
                    else
                    {
                        for (int i = -1; i <= length; ++i)
                        {
                            backEnd[x + i, y + j] = (int)groundStats.Miss;
                        }
                    }
                }
            }

        }
        public void checkForLife(int x, int y)
        {
            if (ships[x, y].getHp() == 0)
                kill(ships[x, y].getCoordX(), ships[x, y].getCoordY(), ships[x, y].getLength());
        }
        
    }
}
