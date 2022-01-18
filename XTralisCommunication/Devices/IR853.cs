using System;
using System.Linq;
using System.Text;
using System.Threading;
using static XTralisCommunication.Constants;

namespace XTralisCommunication.Devices
{
    // TEST DEVICE!!!
    public sealed class IR853 : XModel
    {
        object locker = new object();
        byte[] backBuffer;
        private static int CmdLen = (int)AlarmLengths.CmdGetDatAckn; 

        public IR853(DeviceInfo info, int id)
           : base(info, id)
        {
            backBuffer = new byte[CmdLen]; // todo 
        }
        
        public override void CmdGetData()
        {
            byte[] res;
            int readlen = CmdLen;
            if (Utils.Write(_connection, ComGenerator.CmdGetDat(ID, 0x00)))
            {
                int cnt  = Utils.Read(_connection, out res, readlen);
                if (res != null)
                {
                    lock(locker)
                    {
                        Array.Copy(res, backBuffer, readlen);
                    }
                }
            }
        }

        public override void Update()
        {
            int len = CmdLen;
            byte[] tmp = new byte[len];
            lock(locker)
            {
                Array.Copy(backBuffer, tmp, len);
            }
            IvzLogger.Instance.Log($"Device ID: {ID}: Data: {Utils.PrettyPrintData(tmp, len)}\r\n");
        }    
    }
}


