using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign2_2
{
    public static class HammingDistanceCalculator
    {

        public static int CalculateDistance(int first, int second)
        {
            int x = first | second;
            int dist = 0;  
            /////////
            while (x != 0)
            {
                if ((x & 0x01) == 1)
                {
                    dist++;
                }
                x = x >> 1;
            }
            /////////////
            //string s = Convert.ToString(x, 2);
            //return s.AsEnumerable<char>().Count(ch => ch == '1');
            return dist;
        }

        public static int Flip(int value, int pos)
        {
            return value ^ (0x01 << pos);
        }
    }
}
