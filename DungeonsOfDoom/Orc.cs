using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Orc : Monster
    {

        public Orc(int weight, string itemName) : base(50, 10, "Orc")
        {
            Weight = weight;
            ItemName = itemName;

        }


        public override int Attack(Creature opponent)
        {
            int attackDmg = Strength;
            if ((opponent.Strength / 2) >= this.Strength)
            {
                attackDmg = -1;
                return attackDmg;

            }

            return base.Attack(opponent);
        }

        
    }
}
