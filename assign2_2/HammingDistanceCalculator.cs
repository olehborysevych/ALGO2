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
            string s = Convert.ToString(x, 2);
            return s.AsEnumerable<char>().Count(ch => ch == '1');
        }

        public static int Flip(int value, int pos)
        {
            return value ^ (0x01 << pos);
        }
    }
}
