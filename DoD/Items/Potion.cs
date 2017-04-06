using DoD.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoD.Items
{
    public class Potion : Item
    {
        public Potion(string name, int weight, int health, string itemName) : base(name, weight, itemName)
        {
            Health = health;
        }

        public int Health { get; }

        public override void GetItemPower(Creature creature)
        {
            creature.Health += Health;
        }
    }
}
