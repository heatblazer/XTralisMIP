using System.Linq;
using System.Text;
using static XTralisCommunication.Constants;

namespace XTralisCommunication
{
    public  abstract  class XModel
    {
        protected class AlarmHeadL
        {
            public byte NewL, NewH;
            public byte OldL, OldH;

        }
        protected class AlarmHeadH
        {
            public byte NewL, NewH;
            public byte OldL, OldH;
        }

        protected class InfoBitCWord
        {
            public byte Low;
            public byte High;
        }

        protected AlarmHeadL _alarmHeadL;
        protected AlarmHeadH _alarmHeadH;
        protected InfoBitCWord _infoBitCWord;

        // tcp, udp or spi
        protected IConnection _connection; 

        // info, alarms, name, etc
        protected DeviceInfo _deviceInfo; 

        protected int _id;

        protected bool _connected;

        public bool Connected
        {
            get { return _connected; }
            set { _connected = value; }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        protected XModel(DeviceInfo info, int id)
        {
            _id = id;
            _deviceInfo = info;
            _connected = false;
            _alarmHeadH = new AlarmHeadH();
            _alarmHeadL = new AlarmHeadL();
            _infoBitCWord = new InfoBitCWord();
        }

        public void Connect(IConnection con)
        {
            _connection = con; 
        }

        // get device specific information 
        public  virtual DeviceInfo GetInfo()
        {
            return _deviceInfo;
        }

        // update the business logic of the device
        public abstract void  Update();

        public abstract void CmdGetData();


        public virtual void CmdGetAlm(AlarmCommands cmd)
        {
            int readlen = 5;
            if (cmd == AlarmCommands.CmdGetAlmHeadH || cmd == AlarmCommands.CmdGetAlmHeadL)
                readlen += 4;
            else if (cmd == AlarmCommands.CmdGetAlmInfoBitC)
                readlen += 2;
            else
                return; // error cmd

            if (Utils.Write(_connection, ComGenerator.CmdGetAlm(ID, (byte)cmd)))
            {
                byte[] res;
                int cnt = Utils.Read(_connection, out res, readlen);
                if (res != null && res.Count() == cnt)
                {
                    // HandleAlarmResponse(res[4], res[5], out info);
                    //   IvzLogger.Instance.Log($"Device id: {ID} : [{info}]\r\n");
                    switch (cmd)
                    {
                        case AlarmCommands.CmdGetAlmHeadL:
                            _alarmHeadL.NewL = res[4];
                            _alarmHeadL.NewH = res[5];
                            _alarmHeadL.OldL = res[6];
                            _alarmHeadL.OldH = res[7];
                            break;
                        case AlarmCommands.CmdGetAlmHeadH:
                            _alarmHeadH.NewL = res[4];
                            _alarmHeadH.NewH = res[5];
                            _alarmHeadH.OldL = res[6];
                            _alarmHeadH.OldH = res[7];
                            break;
                        case AlarmCommands.CmdGetAlmInfoBitC:
                            _infoBitCWord.Low = res[4];
                            _infoBitCWord.High = res[5];
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        public virtual  bool IsOnline()
        {
            bool ret = false;
            byte[] res = null;

            if (!_connection.IsConnected())
                return ret; 

            try
            {
                if (Utils.Write(_connection, ComGenerator.CmdChk(ID)))
                {
                    int count = 0;
                    count = Utils.Read(_connection, out res, (int)AlarmLengths.CmdChkAckn);
                    if (res != null && count == (int)AlarmLengths.CmdChkAckn)
                    {
                        IvzLogger.Instance.Log($"Device {ID} is Online!");
                        ret = true;
                    }
                }
            }
            catch
            {
                ret = false;
            }

            return ret;
        }
    }   
}
