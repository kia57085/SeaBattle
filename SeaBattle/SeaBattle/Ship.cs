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
        abstract public int getShipCount();
        abstract public void setCoord(int x, int y);
        abstract public void HelloFrom();
        abstract public bool getRotation();
        abstract public void setRotation(bool rotation);

        abstract public void shoot();
        protected int _allHp = 20;
        protected int _allShipCount = 10;



    }
    class ship : Ship
    {
        int _hp;
        int _length;
        bool _rotation;
        int[] _coord = new int[2];
        static int _shipCount;
        public ship(int length, bool rotation)
        {
            _length = length;
            _shipCount = 5 - length;
            _hp = length;
            _rotation = rotation;
            _allShipCount--;
            _shipCount--;
            Console.WriteLine("Hello from ship1!");
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
        public override int getShipCount()
        {
            return _shipCount;
        }
        public override int getAllShipCount()
        {
            return _allShipCount;
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


    }

}
