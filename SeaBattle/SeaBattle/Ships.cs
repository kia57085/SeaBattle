using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    abstract class Ships
    {
        protected static int fullHp = 20;
        public abstract void Shoot();
        public abstract void Kill();
        public abstract void Place(int x, int y);
        public abstract void Replace();

    }
    class Ship1 : Ships
    {

        private int _Hp = 1;
        private int _ShipCount = 4;
        private int x, y;



        /// /////////
        public override void Kill()
        {
        }

        public override void Place(int x, int y)
        {

        }

        public override void Replace()
        {
        }

        public override void Shoot()
        {
        }
    }
}
