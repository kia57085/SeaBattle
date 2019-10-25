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
    class ship1 : Ship
    {
        int _hp = 1;
        int _length = 1;
        bool _rotation = false;
        int[] _coord = new int[2];
        static int _shipCount = 4;
        public ship1()
        {
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
    class ship2 : Ship
    {
        int _hp = 2;
        int _length = 2;
        bool _rotation = false;
        int[] _coord = new int[2];
        static int _shipCount = 3;

        public ship2()
        {
            _allShipCount--;
            _shipCount--;
            Console.WriteLine("Hello from ship2!");
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
            Console.WriteLine("Hello from ship2!");
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
    class ship3 : Ship
    {
        int _hp = 3;
        int _length = 3;
        bool _rotation = false;
        int[] _coord = new int[2];
        static int _shipCount = 2;

        public ship3()
        {
            _allShipCount--;
            _shipCount--;
            Console.WriteLine("Hello from ship3!");
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
            Console.WriteLine("Hello from ship3!");
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
    class ship4 : Ship
    {
        int _hp = 4;
        int _length = 4;
        bool _rotation = false;
        int[] _coord = new int[2];
        static int _shipCount = 1;
        public ship4()
        {
            _shipCount--;
            _allShipCount--;
            Console.WriteLine("Hello from ship4!");
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
            Console.WriteLine("Hello from ship4!");
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
