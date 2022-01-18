using System;

namespace XTralisCommunication.Devices
{
    public class IR85B : XModel
    {
      
        public IR85B(DeviceInfo info, int id)
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
