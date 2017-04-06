using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utils;

namespace DungeonsOfDoom
{
    abstract class Creature : GameObject
    {
        public Creature(int health, int strength, string name, char icon) : base(name, icon)
        {
            Health = health;
            Strength = strength;
        }

        public virtual int Attack(Creature opponent)
        {
            
            int attackDmg = Strength;
            if (!(this.Strength < 1))
            {
                attackDmg = RandomUtils.GetRandom(0, Strength + 1);
                //Thread.Sleep(rnd.Next(50,201));
            }
            else
            {
                attackDmg = 1;
            }
            return attackDmg;
        }

        public int Health { get; set; }
        public int Strength { get; set; }
    }
}
