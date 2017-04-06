using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    abstract class Item : GameObject, IItem
    {
        public Item(string name, int weight, string itemName) : base(name, 'I')
        {          
            Weight = weight;
            ItemName = itemName;
        }

        public int Weight { get; set; }
        public string ItemName { get; set; }
        public abstract void GetItemPower(Creature creature);
    }
}
