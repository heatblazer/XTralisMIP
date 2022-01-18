using System;

namespace XTralisCommunication.Devices
{
    public class IR864 : XModel
    {
       
        public IR864(DeviceInfo info, int id)
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
