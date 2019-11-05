using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    abstract class Ship
    {
        abstract public int getAllHp();
        abstract public int getHp();
        abstract public int getLength();
        abstract public int getCoordX();
        abstract public int getCoordY();
        abstract public int getAllShipCount();
        abstract public int getShipCount(int length);
        abstract public void setCoord(int x, int y);
        abstract public void HelloFrom();
        abstract public bool getRotation();
        abstract public void setRotation(bool rotation);

        abstract public void shoot();
        abstract public void destroy(int length);

    }
    class ship : Ship
    {
        static int _shipCount1 = 4;
        static int _shipCount2 = 3;
        static int _shipCount3 = 2;
        static int _shipCount4 = 1;
        static int _allHp = 20;
        int _hp;
        int _length;
        bool _rotation;
        int[] _coord = new int[2];
        public ship(int length, bool rotation)
        {
            _length = length;
            _hp = length;
            _rotation = rotation;
            createShip(length);
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
        public override int getCoordX()
        {
            return _coord[0];
        }
        public override int getCoordY()
        {
            return _coord[1];
        }
        public override int getLength()
        {
            return _length;
        }
        public override int getAllHp()
        {
            return _allHp;
        }
        public override int getHp()
        {
            return _hp;
        }
        public override void setCoord(int x, int y)
        {
            _coord[0] = x;
            _coord[1] = y;
        }
        public override void shoot()
        {
            _hp--;
            _allHp--;
        }
        public override int getShipCount(int length)
        {
            int shipCount = 0;
            if (length == 1)
            {
                shipCount =_shipCount1;
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
        public override int getAllShipCount()
        {
            return _shipCount1 + _shipCount2 + _shipCount3 + _shipCount4;
        }
        public override void HelloFrom()
        {
            Console.WriteLine("Hello from ship1!");
        }
        public override bool getRotation()
        {
            return _rotation;
        }
        public override void setRotation(bool rotation)
        {
            _rotation = rotation;
        }
        public override void destroy(int length)
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


    }

}
