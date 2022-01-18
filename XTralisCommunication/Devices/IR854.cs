using System;
using System.Linq;
using System.Text;
using System.Threading;
using static XTralisCommunication.Constants;

namespace XTralisCommunication.Devices
{
    public class IR854 : XModel
    {

        object locker = new object();
        byte[] backBuffer;
        private static readonly int CmdLen = (int)AlarmLengths.CmdGetDat2Ackn;

        public IR854(DeviceInfo info, int id)
            : base(info, id)
        {
            backBuffer = new byte[CmdLen+5]; // todo 
        }

        public override void CmdGetData()
        {
            byte[] res;
            int readlen = CmdLen;
            if (Utils.Write(_connection, ComGenerator.CmdGetDat(ID, 0x00)))
            {
                int cnt = Utils.Read(_connection, out res, readlen);
                if (res != null)
                {
                    lock (locker)
                    {
                        Array.Copy(res, backBuffer, cnt);
                    }
                }
            }
        }

        public override void Update()
        {
            byte[] tmp = new byte[CmdLen];
            lock (locker)
            {
                Array.Copy(backBuffer, tmp, CmdLen);
            }

            IvzLogger.Instance.Log($"Device ID: {ID}: Data: { Utils.PrettyPrintData(tmp, CmdLen)}\r\n");
        }

     


    }
}
