using System;

namespace XTralisCommunication.Devices
{
    public class IR859 : XModel
    {

        public IR859(DeviceInfo info, int id)
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
