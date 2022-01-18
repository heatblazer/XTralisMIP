using System;

namespace XTralisCommunication.Devices
{
    public class IR856 : XModel
    {

        public IR856(DeviceInfo info, int id)
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
