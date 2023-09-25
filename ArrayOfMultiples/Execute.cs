using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOfMultiples
{
    public static class Execute
    {
        public static int[] ArrayOfMultiples(int num, int length)
        {
            var result = new int[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = num * (i+1);
            }
            return result;
        }
    }
}
