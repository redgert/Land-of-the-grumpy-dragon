using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Dragon : Monster, IItem
    {
        public Dragon(int weight, string itemName) : base(200, 50, "Grumpy Dragon")
        {
            Weight = weight;
            ItemName = itemName;
        }

    }
}
