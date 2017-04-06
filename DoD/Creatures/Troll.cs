using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoD.Creatures
{
    public class Troll: Monster, IItem
    {
        public Troll(int weight, string itemName) : base(70, 20, "Troll")
        {
            Weight = weight;
            ItemName = itemName;
        }
    }
}
