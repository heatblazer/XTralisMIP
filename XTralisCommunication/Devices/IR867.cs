using System;

namespace XTralisCommunication.Devices
{
    public class IR867 : XModel
    {

        public IR867(DeviceInfo info, int id)
            : base(info, id)
        { }

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
