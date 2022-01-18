using System;

namespace XTralisCommunication.Devices
{
    public class IR857 : XModel
    {

        public IR857(DeviceInfo info, int id)
            : base(info, id)
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
