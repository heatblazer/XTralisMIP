using System.Text;
using System.Threading;

namespace XTralisCommunication
{
    public static class Utils
    {
        public enum States
        {
            State1,
            State2,
            State3
        }

        public static bool Write(IConnection conn, byte[] data, int timeout = 50)
        {
            bool res = false;
            try
            {
                if (conn.Send(data))
                {
                    res = true;
                }
            }
            catch
            {
                res = false;
            }
            Thread.Sleep(timeout);

            return res;
        }

        public static int Read(IConnection conn, out byte[] read, int readcnt, int timeout=50)
        {
            int cnt = 0;
            byte[] res = read = null;
            string info; // debug level info probably if needed 
            try
            {
                cnt = conn.Recieve(out res, readcnt, out info);
                if (res != null && cnt == readcnt)
                {
                    read = res;
                    IvzLogger.Instance.Log($"Otional info: {info}\r\n");
                }
            }
            catch
            {
                read = null; 
            }
            Thread.Sleep(timeout);
            return cnt;
        }

        public static States HandleAlarmResponse(byte low, byte high, out string info)
        {
            States ret = States.State1;
            info = null;
            StringBuilder sb = new StringBuilder();
            if (Bits.GetBoolStatusOfBitN(low, 0))
                sb.Append("[General alarm (Relay)]");
            if (Bits.GetBoolStatusOfBitN(low, 1))
                sb.Append("[General warning over all channels]");

            if (Bits.GetBoolStatusOfBitN(low, 2))
                sb.Append("[Alarm short range]");
            if (Bits.GetBoolStatusOfBitN(low, 3))
                sb.Append("[Alarm medium range]");
            if (Bits.GetBoolStatusOfBitN(low, 4))
                sb.Append("[Alarm long range]");
            if (Bits.GetBoolStatusOfBitN(low, 5))
                sb.Append("[Warning short range]");
            if (Bits.GetBoolStatusOfBitN(low, 6))
                sb.Append("[Warning medium range]");
            if (Bits.GetBoolStatusOfBitN(low, 7))
                sb.Append("[Warning long range]");

            if (Bits.GetBoolStatusOfBitN(high, 3))
            {
                sb.Append("[Alarm in HeadH Word!]");
                ret = States.State2;
            }
            else if (Bits.GetBoolStatusOfBitN(high, 4))
            {
                sb.Append("[Cover/Vandalism/AntiMasking]");
                ret = States.State3;
            }

            info = sb.ToString();
            return ret;
        }

        public static States HandleAlarmResponse2(byte low, byte high, out string info)
        {
            States ret = States.State1;
            StringBuilder sb = new StringBuilder();
            info = null;
            if (Bits.GetBoolStatusOfBitN(low, 0))
            {
                sb.Append("[Creep Zone Ch1]");
            }
            if (Bits.GetBoolStatusOfBitN(low, 1))
            {
                sb.Append("[Creep Zone Ch2]");
            }

            info = sb.ToString();
            return ret;
        }

        public static States HandleAlarmResponse3(byte low, byte high, out string info)
        {
            States s = States.State1;
            StringBuilder sb = new StringBuilder();
            info = null;
            if (Bits.GetBoolStatusOfBitN(low, 0))
                sb.Append("[Cover Open]");
            if (Bits.GetBoolStatusOfBitN(low, 1))
                sb.Append("[Alignment]");
            if (Bits.GetBoolStatusOfBitN(low, 3))
                sb.Append("[Tamper Braket]");

            if (Bits.GetBoolStatusOfBitN(high, 0))
                sb.Append("[Anti-Masking]");
            info = sb.ToString();
            return s;
        }


        public static string PrettyPrintData(byte[] data, int len)
        {
            if (len <= 0 || data == null)
                return string.Empty;

            StringBuilder sb = new StringBuilder();
            for(int i=0; i < len; ++i)
            {
                sb.Append($"[{data[i]}]");
            }
            return sb.ToString();
        }
    }
}
