using System;

namespace MyNumerics
{
    public class IntegerUtil
    {
        public static long doubleInt2Long(int a1, int a2)
        {
            long b = a2;
            b = b << 32;
            b = b | (uint)a1;
            return b;
        }

        public static int[] long2doubleInt(long a)
        {
            int a1 = (int)(a & uint.MaxValue);
            int a2 = (int)(a >> 32);
            return new int[] { a1, a2 };
        }
    }
}
