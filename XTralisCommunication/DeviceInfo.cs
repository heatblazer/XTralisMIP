using System.Collections.Generic;
using System.Text;
using static XTralisCommunication.Constants;

namespace XTralisCommunication
{
    public class DeviceInfo
    {
        public byte DetectorAddress
        {
            get;
            private set;
        }

        public Dictionary<AlarmCodes, bool> SupportedAlarms { get; private set; }
        public string Name { get; private set; }
        public string OptionalInfo { get; private set; }
        public string Version { get; private set; }

        public DeviceInfo(string name, byte daddr, string ver = "1.82", string optinfo = "None")
        {
            DetectorAddress = daddr;
            Name = name;
            Version = ver;
            OptionalInfo = optinfo;
            SupportedAlarms = new Dictionary<AlarmCodes, bool>();
            // prepend
            for (int i = 0; i < (int)(AlarmCodes.Size); ++i)
            {
                SupportedAlarms[(AlarmCodes)i] = false;
            }

            SupportedAlarms[AlarmCodes.GeneralAlarm] = true;
            SupportedAlarms[AlarmCodes.CoverVandalismAntiMasking] = true;
            SupportedAlarms[AlarmCodes.AlarmRejection] = true;
            SupportedAlarms[AlarmCodes.HardwareInfromation] = true;
            SupportedAlarms[AlarmCodes.PowerFailure] = true;
            SupportedAlarms[AlarmCodes.CreepZoneCh1] = true;
            SupportedAlarms[AlarmCodes.CreepZoneCh2] = true;
            SupportedAlarms[AlarmCodes.CoverOpen] = true;
            SupportedAlarms[AlarmCodes.Alignment] = true;
            SupportedAlarms[AlarmCodes.TamperBraket] = true;
            SupportedAlarms[AlarmCodes.AntiMasking] = true;
        }

        private DeviceInfo(string name, Dictionary<AlarmCodes, bool> alarms, string optinfo = "None")
        {
            Name = name;
            OptionalInfo = optinfo;
            SupportedAlarms = alarms;
        }

        // to be defined better
        public string DetailedInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Model name: [{Name}]\r\n");
            sb.Append($"Model info: [{OptionalInfo}]\r\n");
            sb.Append($"Supported alarms: (view the map for now)\r\n");
            foreach (var kv in SupportedAlarms)
            {
                string yn = kv.Value ? "[Yes]" : "[No]";
                sb.Append($"Alarm: {kv.Key} - Supported : {yn} \r\n");
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {Name}\r\n");
            sb.Append($"Version: {Version}\r\n");
            sb.Append($"Address: {DetectorAddress}\r\n");
            sb.Append($"Optional info: {OptionalInfo}\r\n");
            return sb.ToString();
        }
    }
}
