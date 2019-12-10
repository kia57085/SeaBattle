using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    class Ship
    {
        static int _shipCount1 = 4;
        static int _shipCount2 = 3;
        static int _shipCount3 = 2;
        static int _shipCount4 = 1;
        int _hp;
        int _length;
        bool _rotation;
        int[] _coord = new int[2];
        public Ship(int length, bool rotation)
        {
            _length = length;
            _hp = length;
            _rotation = rotation;
            createShip(length);
        }
        public Ship(string reset)
        {
            resetShipsCount();
        }
        void createShip(int length)
        {
            if (length == 1)
            {
                _shipCount1--;
                
            }
            else if (length == 2)
            {
                _shipCount2--;
               
            }
            else if (length == 3)
            {
                _shipCount3--;
               
            }
            else if (length == 4)
            {
                _shipCount4--;
               
            }
        }
        public int getCoordX()
        {
            return _coord[0];
        }
        public int getCoordY()
        {
            return _coord[1];
        }
        public int getLength()
        {
            return _length;
        }
        public int getHp()
        {
            return _hp;
        }
        public  void setCoord(int x, int y)
        {
            _coord[0] = x;
            _coord[1] = y;
        }
        public  void shoot()
        {
            --_hp;
        }
        public  int getShipCount(int length)
        {
            int shipCount = 0;
            if (length == 1)
            {
                shipCount = _shipCount1;
            }
            else if (length == 2)
            {
                shipCount = _shipCount2;
            }
            else if (length == 3)
            {
                shipCount = _shipCount3;
            }
            else if (length == 4)
            {
                shipCount = _shipCount4;
            }
            return shipCount;
        }
        
        public  bool getRotation()
        {
            return _rotation;
        }

        public void destroy(int length)
        {
            if (length == 1)
            {
                _shipCount1++;
            }
            else if (length == 2)
            {
                _shipCount2++;
            }
            else if (length == 3)
            {
                _shipCount3++;
            }
            else if (length == 4)
            {
                _shipCount4++;
            }
        }
        public void resetShipsCount()
        {
            _shipCount1 = 4;
            _shipCount2 = 3;
            _shipCount3 = 2;
            _shipCount4 = 1;
        }
    }
   

}
