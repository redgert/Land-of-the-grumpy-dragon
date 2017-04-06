using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoD.Creatures
{
    public class Ogre : Monster, IItem
    {
        public Ogre(int weight, string itemName) : base(60, 15, "Ogre")
        {
            Weight = weight;
            ItemName = itemName;
        }

    }
}
