using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    class Players
    {
        private static Players instance;
        bool[] _turn = new bool[2];
        int _hp1 = 20;
        int _hp2 = 20;
        FrontEnd frontEnd = new FrontEnd();
        private Players() 
        {
            _turn[0] = true;
        }
        public static Players getInstance()
        {
            if(instance == null)
            {
                instance = new Players();
            }
            return instance;
        }
        public void shoot()
        {
            if(getTurn1() == true)
            {
                --_hp2;
                
            }
            else
            {
                --_hp1;
                
            }
        }
        public int getHp1()
        {
            return _hp1;
        }
        public int getHp2()
        {
            return _hp2;
        }
        public bool getTurn1()
        {
            return _turn[0];
        }
        public bool getTurn2()
        {
            return _turn[1];
        }
        public void changeTurn()
        {
            if(_turn[0] == true)
            {
                _turn[0] = false;
                _turn[1] = true;
            }
            else
            {
                _turn[0] = true;
                _turn[1] = false;
            }
            frontEnd.messageTurn();
        }
        public string win()
        {
            string winner = null;
            if (_hp1 == 0)
            {
                winner = "Игрок2";
            }
            else if (_hp2 == 0) 
            {
                winner = "Игрок1";
            }
            return winner;
        }

    }
}
