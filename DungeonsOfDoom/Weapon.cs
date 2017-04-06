using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Weapon : Item
    {
        public Weapon(string name, int weight, int strength, string itemName) : base(name, weight, itemName)
        {
            Strength = strength;
        }

        public int Strength { get; }

        public override void GetItemPower(Creature creature)
        {
            creature.Strength += Strength;
        }
    }
}
