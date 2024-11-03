using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Enemy
    {
        public string name;
        public int hp;
        public int maxhp;
        public Weapon weapon;
        public int pointsaward;
        public Enemy(string n, int h, int mh, int p)
        {
            name = n;
            hp = h;
            maxhp = mh;
            pointsaward = p;
        }
    }
}
