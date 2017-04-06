using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utils
{
    public class TextUtils
    {
        public static void AnimateText(string text, int delay)
        {
            foreach (var c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
        }
    }
}
