using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    interface IItem
    {
        int Weight { get; set; }
        string ItemName { get; set; }
        void GetItemPower(Creature creature);
    }
}
