using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utils
{
    public class RandomUtils
    {
        private static readonly Random random = new Random();

        public static int GetRandom(int start, int end)
        {
            //Thread.Sleep(50);
            return random.Next(start, end);
        }
    }
}
