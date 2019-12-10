using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeaBattle
{
    public class BackEnd
    {
        const int size = 10;
        bool rotation = false;
        groundStats[,] backEnd = new groundStats[size, size];
        Ship[,] ships = new Ship[size, size];
        FrontEnd frontEnd = new FrontEnd();
        public enum groundStats
        {
            Miss,
            Sea,
            Shooted,
            Ship
        }
        public BackEnd()
        {
            Fill();
        }
        public int getSizeOfGround()
        {
            return size;
        }
        public void Fill()
        {
            for (int i = 0; i != size; ++i)
            {
                for (int j = 0; j != size; ++j)
                {
                    backEnd[i, j] = groundStats.Sea;
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
            if (getValueOfGround(x, y) == groundStats.Miss)
            {
                frontEnd.missClick();
            }
            else if (getValueOfGround(x, y) == groundStats.Sea)
            {
                setValueOfGround(x, y, groundStats.Miss);
                Players.getInstance().changeTurn();
            }
            else if (getValueOfGround(x, y) == groundStats.Shooted)
            {
                frontEnd.missClick();
            }
            else if (getValueOfGround(x, y) == groundStats.Ship)
            {
                setValueOfGround(x, y, groundStats.Shooted);
                
                ships[x, y].shoot();
                Players.getInstance().shoot();
                checkForLife(x, y);

            }
            
        }
        public void install(int x, int y, int length)
        {
            
                ships[x, y] = new Ship(length, rotation);
                ships[x, y].setCoord(x, y);
            
        }
        public void place(int x, int y, int length)
        {
            if (ships[x, y] == null)
            {
                if (rotation == false)
                {
                    while (length + y > size)
                    {
                        --y;
                    }
                    if (checkForNeighbour(x, y, length) == false)
                    {
                        install(x, y, length);
                        for (int i = 0; i != length; ++i)
                        {
                            setValueOfGround(x, y + i, groundStats.Ship);
                            ships[x, y + i] = ships[x, y];
                        }
                    }
                    else
                    {
                        frontEnd.missClick();
                    }
                }
                else
                {
                    while (length + x > size)
                    {
                        --x;
                    }
                    if (checkForNeighbour(x, y, length) == false)
                    {
                        install(x, y, length);
                        for (int i = 0; i != length; ++i)
                        {
                            setValueOfGround(x + i, y, groundStats.Ship);
                            ships[x + i, y] = ships[x, y];
                        }
                    }
                    else
                    {
                        frontEnd.missClick();
                    }
                }
            }
            else frontEnd.missClick();
            checkForShipCount(x, y);

        }
        public void destroy(int x0, int y0)
        {
            if (ships[x0, y0] != null)
            {
                int x = ships[x0, y0].getCoordX();
                int y = ships[x0, y0].getCoordY();
                int length = ships[x, y].getLength();
            
                if (ships[x,y].getRotation() == false)
                {
                    ships[x, y].destroy(length);
                    for (int i = 0; i != length; ++i)
                    {
                        
                        backEnd[x, y + i] = groundStats.Sea;
                        ships[x, y + i] = null;
                    }
                }
                else
                {
                    ships[x, y].destroy(length);
                    for (int i = 0; i != length; ++i)
                    {
                        backEnd[x + i, y] = groundStats.Sea;
                        ships[x + i, y] = null;
                    }
                }
            }
        }
        public groundStats getValueOfGround(int x, int y)
        {
            return backEnd[x, y];
        }
        public void setValueOfGround(int x, int y, groundStats value)
        {
            backEnd[x, y] = value;
        }
        public void kill(int x0, int y0, int length)
        {
            int x = ships[x0, y0].getCoordX();
            int y = ships[x0, y0].getCoordY();

            if (ships[x,y].getRotation() == false)
            {
                for (int i = -1; i <= 1; ++i)
                {
                    for (int j = -1; j <= length; ++j)
                    {
                        if (x + i >= 0 && x + i < size && y + j >= 0 && y + j < size)
                        {
                            if(backEnd[x + i, y + j] == groundStats.Miss || backEnd[x + i, y + j] == groundStats.Sea)
                            {
                                backEnd[x + i, y + j] = groundStats.Miss;
                               
                                
                            }
                        }
                    }
                }
            }
            else
            {
                for (int j = -1; j <= 1; ++j)
                {
                    for (int i = -1; i <= length; ++i)
                    {
                        if (x + i >= 0 && x + i < size && y + j >= 0 && y + j < size)
                        {
                            if (backEnd[x + i, y + j] == groundStats.Miss || backEnd[x + i, y + j] == groundStats.Sea)
                            {
                                backEnd[x + i, y + j] = groundStats.Miss;
                                
                            }
                        }
                    }
                }
            }
            if(Players.getInstance().getHp1() == 0)
            {
                frontEnd.win();
            }
            else if(Players.getInstance().getHp2() == 0)
            {
                frontEnd.win();
            }
        }
        public void checkForLife(int x, int y)
        {
            if (ships[x, y].getHp() == 0)
            {
                
                kill(ships[x, y].getCoordX(), ships[x, y].getCoordY(), ships[x, y].getLength());
            }
        }
        public bool checkForNeighbour(int x, int y, int length)
        {
            bool neighbour = false;

            if(rotation == false)
            {
                for(int i = -1; i <= 1; ++i)
                {
                    for(int j = -1; j <= length; ++j)
                    {
                        if (x + i >= 0 && x + i < size && y + j >= 0 && y + j < size)
                        {
                            if (backEnd[x + i, y + j] == groundStats.Ship)
                            {
                                neighbour = true;
                            }
                        }
                    }
                }
            }
            else
            {
                for(int j = -1; j <= 1; ++j)
                {
                    for(int i = -1; i <= length; ++i)
                    {
                        if (x + i >= 0 && x + i < size && y + j >= 0 && y + j < size)
                        {
                            if (backEnd[x + i, y + j] == groundStats.Ship)
                            {
                                neighbour = true;
                            }
                        }
                    }
                }
            }
            return neighbour;
        }
        public void checkForShipCount(int x, int y)
        {
            if (ships[x, y] != null)
            {
                int length = ships[x, y].getLength();
                int count = ships[x, y].getShipCount(length);
                if (count < 0)
                {
                    frontEnd.outOfCountShip();
                    destroy(x, y);
                }
            }
        }
      
    }
}
