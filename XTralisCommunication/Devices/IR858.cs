using System;

namespace XTralisCommunication.Devices
{
    public class IR858 : XModel
    {

        public IR858(DeviceInfo info, int id)
            : base(info, id)
        {
        }

        public override void CmdGetData()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
