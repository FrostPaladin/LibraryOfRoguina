using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Weapon
    {
        public string name { get; }
        public int damage { get; }
        public int durability { get; set; }

        public Weapon(string n, int dmg, int dur)
        {
            this.name = n;
            this.damage = dmg;
            this.durability = dur;
        }
    }
}
