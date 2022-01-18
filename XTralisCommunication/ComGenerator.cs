using System.Linq;

namespace XTralisCommunication
{
    // generates various commands for XTralis devices 
    public  static class ComGenerator
    {
        // all commands start with
        //[0] - START - 0xFF (constant value)
        //[1] - ID - 0xNN  (may vary, eg.: 0x01)
        //[2] - CMD - 0xNN in hex (may vary, eg: 0x80)
        //[3] - LEN - 0xNN (may vary)
        //[4] - Parity calculation : 
        //Let Parity be 0
        //FOR(I in N-1) 
        //   Parity += I
        //Parity %= 256 

        private static int GenerateCheckSum(byte[] data, int begin, int end)
        {
            int cs = 0;
            if (data == null || data.Count() <= 0)
                return -1;

            for(int i=begin; i <= end; ++i)
            {
                cs += data[i];
            }
            cs %= 256;
            return cs;
        }


        public static byte[] CmdChk(int idx)
        {
            byte[] b = new byte[5];
            b[0] = 0xff;
            b[1] = (byte)idx;
            b[2] = 0x80;
            b[3] = 0x00;
            int cs = GenerateCheckSum(b, 0, 3);
            b[b.Count()-1] = (byte)cs;
            return b;
        }

        public static byte[] CmdGetDat(int idx, int ID=0x00)
        {
            byte[] b = new byte[6];
            b[0] = 0xff;
            b[1] = (byte)idx;
            b[2] = 0xAB;
            b[3] = 0x01;
            b[4] = (byte)ID;
            int cs = GenerateCheckSum(b, 0, 4);
            b[b.Count() - 1] = (byte)cs;
            return b;
        }

        public static byte[] CmdGetCfg(int idx)
        {
            byte[] b = new byte[5];
            b[0] = 0xff;
            b[1] = (byte)idx;
            b[2] = 0xAC;
            b[3] = 0x00;
            int cs = GenerateCheckSum(b, 0, 3);
            b[b.Count()-1] = (byte)cs;
            return b;
        }

        public static byte[] CmdGetAlm(int idx, byte almno=0x90/*0x93, 0x91, 0x92, see doc*/)
        {
            byte[] b = new byte[5];
            b[0] = 0xff;
            b[1] = (byte)idx;
            b[2] = almno;
            b[3] = 0x00;
            int cs = GenerateCheckSum(b, 0, 3);
            b[4] = (byte)cs;
            return b;
        }

        public static byte[] CmdGetAlmBitInfo(int idx, int bitno)
        {
            byte[] b = new byte[6];
            b[0] = 0xff;
            b[1] = (byte)idx;
            b[2] = 0x91;
            b[3] = 0x01;
            b[4] = (byte)bitno; /* 1- 16*/
            int cs = GenerateCheckSum(b, 0, 4);
            b[b.Count() - 1] = (byte)cs;
            return b;
        }


        // Do not implement for now!!!
        // careful now with that command!!! see the XTralis Protocol specification security!
        private static byte[] CmdSavPar(int idx, int addr, int val)
        {
            byte[] b = new byte[7];
            b[0] = 0xff;
            b[1] = (byte)idx;
            b[2] = 0xA1;
            b[3] = 0x02;
            b[4] = (byte)addr;
            b[5] = (byte)val;
            int cs = GenerateCheckSum(b, 0, 5);
            b[b.Count() - 1] = (byte)cs;
            return b;
        }

    }
}
