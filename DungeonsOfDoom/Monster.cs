using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Monster : Creature, IItem
    {
        public Monster(int health, int strength, string name) : base(health, strength, name, 'M')
        {

        }

        public string ItemName
        {
            get;

            set;
        }

        public int Weight
        {
            get; set;
        }

        public void GetItemPower(Creature creature)
        {
           //TODO
        }
    }
}
