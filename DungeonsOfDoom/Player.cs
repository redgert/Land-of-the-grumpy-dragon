using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Player : Creature
    {
        public Player(int health, int x, int y, string name) : base(health, 30, name, 'P')
        {
            X = x;
            Y = y;
            Backpack = new List<IItem>();
            MaxWeight = 40;

        }

        public int X { get; set; }
        public int Y { get; set; }
        public List<IItem> Backpack { get; }
        public int MaxWeight { get; }
    }
}
