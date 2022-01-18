using System;

namespace XTralisCommunication.Devices
{
    public class Unknown : XModel
    {
        // this class is for convinience 
        public Unknown(DeviceInfo info, int id)
            : base(null, -1)
        {
        }

        public override void CmdGetData()
        {
            throw new NotImplementedException();
        }

        public override DeviceInfo GetInfo()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
