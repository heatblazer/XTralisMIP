using System;

namespace XTralisCommunication.Devices
{
    public class IR86C : XModel
    {
       

        public IR86C(DeviceInfo info, int id)
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
