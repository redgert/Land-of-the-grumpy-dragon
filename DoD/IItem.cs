using DoD.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoD
{
    public interface IItem
    {
        int Weight { get; set; }
        string ItemName { get; set; }
        void GetItemPower(Creature creature);
    }
}
