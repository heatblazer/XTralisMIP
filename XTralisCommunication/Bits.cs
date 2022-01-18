using System;

namespace XTralisCommunication
{
    public static class Bits
    {
        public static int BitCount(byte b)
        {
            int i = 0;
            for (i = 0; b != 0; b &= (byte)(b - 1))
                i++;
            return i;
        }

        public static bool GetBoolStatusOfBitN(byte b, int i)
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
            if (i > 7 || i < 0)
                throw new IndexOutOfRangeException("Bit range must be in 0 to 7 (0)");
            return (b & (1 << i)) != 0? true : false;
        }

        // resereved for future use
        private static void SetBitAtIndex(byte b, int n=0, bool updown=true)
        {
            if (n > 7 || n < 0)
                throw new IndexOutOfRangeException("Bit range must be in 0 to 7 (0)");
            b |= (byte)(updown ? 1 : 0 << n);
        }
    }
}
