using System;
using System.Collections.Generic;
using System.Text;
using XTralisCommunication.Devices;
using static XTralisCommunication.Constants;

namespace XTralisCommunication
{

    public class XtralisModelsManager
    {

        private readonly Dictionary<int, XModel> _devicesVer2 = new Dictionary<int, XModel>();
        public Dictionary<int, XModel> DevicesVer2
        {
            get { return _devicesVer2;  }
        }


        private readonly Dictionary<ModelsNumber, Dictionary<int, XModel> > _devices = new Dictionary<ModelsNumber, Dictionary<int, XModel> >();

        private readonly Dictionary<ModelsNumber, DeviceInfo> _models = new Dictionary<ModelsNumber, DeviceInfo>();
        public Dictionary<ModelsNumber, DeviceInfo> Models
        {
            get { return _models;  }
        }

        private XtralisModelsManager()
        {
            for(int i=0; i < (int)ModelsNumber.Size; ++i)
            {
                _devices[(ModelsNumber)i] = new Dictionary<int, XModel>();
            }
        }
        
        private static readonly XtralisModelsManager _sInstance = new XtralisModelsManager();

        public static XtralisModelsManager Instance
        {
            get { return _sInstance;  }
        }

        public XModel GetDeviceById(ModelsNumber model, int id)
        {
            XModel ret = null;
            try
            {
                ret = _devices[model][id];
            }
            catch
            {
                ret = null;
            }

            return ret;
        }

        // all available models by a documentation
        // also rework it here
        public void Setup(string s)
        {
            XModel model = null;
            byte[] bdata = Encoding.ASCII.GetBytes(s);
            int id = -1;
            string ver = string.Empty;
            byte address = 0xff; 

            try
            { 
                id = bdata[1];
            } catch
            {
                throw new IndexOutOfRangeException($"Corrupted data:{s}");
            }
            try
            {
                address = bdata[12];
                ver = System.Text.Encoding.Default.GetString(new byte[3] { bdata[9], bdata[10], bdata[11] });
            }
            catch
            {
                ver = "Unknown";
            }

            if (s.Contains("IR853"))
            {


                _models[ModelsNumber.IR853] = new DeviceInfo("PRO E-45", address, ver,
                    "Curtain medium range / 50m range");
                _models[ModelsNumber.IR853].SupportedAlarms[AlarmCodes.AlarmInfrared] = true;
                _models[ModelsNumber.IR853].SupportedAlarms[AlarmCodes.SingleAlarmMaster] = true;
                _models[ModelsNumber.IR853].SupportedAlarms[AlarmCodes.SignleAlarmSlave1] = true;
                _models[ModelsNumber.IR853].SupportedAlarms[AlarmCodes.SingleAlarmSlave2] = true;
                _models[ModelsNumber.IR853].SupportedAlarms[AlarmCodes.AlarmInHeadHWord] = true;
                _models[ModelsNumber.IR853].SupportedAlarms[AlarmCodes.PulseCount] = true;
                model = new IR853(_models[ModelsNumber.IR853], id);
                _devices[ModelsNumber.IR853][id] = model;
                _devicesVer2[id] = model;
            }
            else if (s.Contains("IR863"))
            {
                _models[ModelsNumber.IR863] = new DeviceInfo("PRO E-45H", address, ver,
                    "Curtain medium range / H / 60m range");
                _models[ModelsNumber.IR863].SupportedAlarms[AlarmCodes.AlarmInfrared] = true;
                _models[ModelsNumber.IR863].SupportedAlarms[AlarmCodes.SingleAlarmMaster] = true;
                _models[ModelsNumber.IR863].SupportedAlarms[AlarmCodes.SignleAlarmSlave1] = true;
                _models[ModelsNumber.IR863].SupportedAlarms[AlarmCodes.SingleAlarmSlave2] = true;
                _models[ModelsNumber.IR863].SupportedAlarms[AlarmCodes.AlarmInHeadHWord] = true;
                _models[ModelsNumber.IR863].SupportedAlarms[AlarmCodes.PulseCount] = true;

                model =  new IR863(_models[ModelsNumber.IR863], id);
                _devices[ModelsNumber.IR863][id] = model;
                _devicesVer2[id] = model;

            }
            else if (s.Contains("IR873"))
            {
                _models[ModelsNumber.IR873] = new DeviceInfo("PRO E-45D", address, ver,
                    "Curtain medium range directional / 50m range");
                _models[ModelsNumber.IR873].SupportedAlarms[AlarmCodes.GeneralWarningOverAllChannels] = true;
                _models[ModelsNumber.IR873].SupportedAlarms[AlarmCodes.AlarmLeft] = true;
                _models[ModelsNumber.IR873].SupportedAlarms[AlarmCodes.AlarmRight] = true;
                _models[ModelsNumber.IR873].SupportedAlarms[AlarmCodes.AlarmDicertionalLeftToRight] = true;
                _models[ModelsNumber.IR873].SupportedAlarms[AlarmCodes.AlarmDicertionalRightToLeft] = true;
                _models[ModelsNumber.IR873].SupportedAlarms[AlarmCodes.LeftIntrusion] = true;
                _models[ModelsNumber.IR873].SupportedAlarms[AlarmCodes.RightIntrusion] = true;
                _models[ModelsNumber.IR873].SupportedAlarms[AlarmCodes.SingleAlarmMaster] = true;
                _models[ModelsNumber.IR873].SupportedAlarms[AlarmCodes.SignleAlarmSlave1] = true;
                _models[ModelsNumber.IR873].SupportedAlarms[AlarmCodes.SingleAlarmSlave2] = true;
                _models[ModelsNumber.IR873].SupportedAlarms[AlarmCodes.AlarmInHeadHWord] = true;
                model = new IR873(_models[ModelsNumber.IR873], id);
                _devices[ModelsNumber.IR873][id] = model;
                _devicesVer2[id] = model;

            }
            else if (s.Contains("IR883"))
            {
                _models[ModelsNumber.IR883] = new DeviceInfo("PRO E-45DH", address, ver, "Curtain medium range directional / H / 60m range");
                _models[ModelsNumber.IR883].SupportedAlarms[AlarmCodes.GeneralWarningOverAllChannels] = true;
                _models[ModelsNumber.IR883].SupportedAlarms[AlarmCodes.AlarmLeft] = true;
                _models[ModelsNumber.IR883].SupportedAlarms[AlarmCodes.AlarmRight] = true;
                _models[ModelsNumber.IR883].SupportedAlarms[AlarmCodes.AlarmDicertionalLeftToRight] = true;
                _models[ModelsNumber.IR883].SupportedAlarms[AlarmCodes.AlarmDicertionalRightToLeft] = true;
                _models[ModelsNumber.IR883].SupportedAlarms[AlarmCodes.LeftIntrusion] = true;
                _models[ModelsNumber.IR883].SupportedAlarms[AlarmCodes.RightIntrusion] = true;
                _models[ModelsNumber.IR883].SupportedAlarms[AlarmCodes.SingleAlarmMaster] = true;
                _models[ModelsNumber.IR883].SupportedAlarms[AlarmCodes.SignleAlarmSlave1] = true;
                _models[ModelsNumber.IR883].SupportedAlarms[AlarmCodes.SingleAlarmSlave2] = true;
                _models[ModelsNumber.IR883].SupportedAlarms[AlarmCodes.AlarmInHeadHWord] = true;

                model = new IR883(_models[ModelsNumber.IR883], id);
                _devices[ModelsNumber.IR883][id] = model;
                _devicesVer2[id] = model;

            }
            else if (s.Contains("IR854"))
            {
                _models[ModelsNumber.IR854] = new DeviceInfo("PRO E-100", address, ver, "Curtain long range / 120m range");
                _models[ModelsNumber.IR854].SupportedAlarms[AlarmCodes.GeneralWarningOverAllChannels] = true;
                _models[ModelsNumber.IR854].SupportedAlarms[AlarmCodes.AlarmShortRange] = true;
                _models[ModelsNumber.IR854].SupportedAlarms[AlarmCodes.AlarmMediumRange] = true;
                _models[ModelsNumber.IR854].SupportedAlarms[AlarmCodes.AlarmLongRange] = true;
                _models[ModelsNumber.IR854].SupportedAlarms[AlarmCodes.WarningShortRange] = true;
                _models[ModelsNumber.IR854].SupportedAlarms[AlarmCodes.WarningMediumRange] = true;
                _models[ModelsNumber.IR854].SupportedAlarms[AlarmCodes.WarningLongRange] = true;
                _models[ModelsNumber.IR854].SupportedAlarms[AlarmCodes.SingleAlarmMaster] = true;
                _models[ModelsNumber.IR854].SupportedAlarms[AlarmCodes.SignleAlarmSlave1] = true;
                _models[ModelsNumber.IR854].SupportedAlarms[AlarmCodes.SingleAlarmSlave2] = true;
                _models[ModelsNumber.IR854].SupportedAlarms[AlarmCodes.AlarmInHeadHWord] = true;

                model = new IR854(_models[ModelsNumber.IR854], id);

                _devices[ModelsNumber.IR854][id] = model;
                _devicesVer2[id] = model;

            }
            else if (s.Contains("IR864"))
            {
                _models[ModelsNumber.IR864] = new DeviceInfo("PRO E-100H", address, ver, "Curtain long range / H / 150m range");
                _models[ModelsNumber.IR864].SupportedAlarms[AlarmCodes.GeneralWarningOverAllChannels] = true;
                _models[ModelsNumber.IR864].SupportedAlarms[AlarmCodes.AlarmShortRange] = true;
                _models[ModelsNumber.IR864].SupportedAlarms[AlarmCodes.AlarmMediumRange] = true;
                _models[ModelsNumber.IR864].SupportedAlarms[AlarmCodes.AlarmLongRange] = true;
                _models[ModelsNumber.IR864].SupportedAlarms[AlarmCodes.WarningShortRange] = true;
                _models[ModelsNumber.IR864].SupportedAlarms[AlarmCodes.WarningMediumRange] = true;
                _models[ModelsNumber.IR864].SupportedAlarms[AlarmCodes.WarningLongRange] = true;
                _models[ModelsNumber.IR864].SupportedAlarms[AlarmCodes.SingleAlarmMaster] = true;
                _models[ModelsNumber.IR864].SupportedAlarms[AlarmCodes.SignleAlarmSlave1] = true;
                _models[ModelsNumber.IR864].SupportedAlarms[AlarmCodes.SingleAlarmSlave2] = true;
                _models[ModelsNumber.IR864].SupportedAlarms[AlarmCodes.AlarmInHeadHWord] = true;
                model = new IR864(_models[ModelsNumber.IR864], id);
                _devices[ModelsNumber.IR864][id] = model;
                _devicesVer2[id] = model;

            }
            else if (s.Contains("IR86C"))
            {
                _models[ModelsNumber.IR86C] = new DeviceInfo("PRO E-400H", address, ver, "Curtain long range / H / 220m range");
                _models[ModelsNumber.IR86C].SupportedAlarms[AlarmCodes.GeneralWarningOverAllChannels] = true;
                _models[ModelsNumber.IR86C].SupportedAlarms[AlarmCodes.AlarmShortRange] = true;
                _models[ModelsNumber.IR86C].SupportedAlarms[AlarmCodes.AlarmMediumRange] = true;
                _models[ModelsNumber.IR86C].SupportedAlarms[AlarmCodes.AlarmLongRange] = true;
                _models[ModelsNumber.IR86C].SupportedAlarms[AlarmCodes.WarningShortRange] = true;
                _models[ModelsNumber.IR86C].SupportedAlarms[AlarmCodes.WarningMediumRange] = true;
                _models[ModelsNumber.IR86C].SupportedAlarms[AlarmCodes.WarningLongRange] = true;
                _models[ModelsNumber.IR86C].SupportedAlarms[AlarmCodes.SingleAlarmMaster] = true;
                _models[ModelsNumber.IR86C].SupportedAlarms[AlarmCodes.SignleAlarmSlave1] = true;
                _models[ModelsNumber.IR86C].SupportedAlarms[AlarmCodes.SingleAlarmSlave2] = true;
                _models[ModelsNumber.IR86C].SupportedAlarms[AlarmCodes.AlarmInHeadHWord] = true;
                model = new IR86C(_models[ModelsNumber.IR86C], id);
                _devices[ModelsNumber.IR86C][id] = model;
                _devicesVer2[id] = model;

            }
            // todo - fill later!!!
            else if (s.Contains("IR851"))
            {
                _models[ModelsNumber.IR851] = new DeviceInfo("PRO E-30", address, ver, "Volumetric 50 degrees / 30m range");
                _models[ModelsNumber.IR851].SupportedAlarms[AlarmCodes.AlarmInfrared] = true;
                _models[ModelsNumber.IR851].SupportedAlarms[AlarmCodes.SingleAlarmMaster] = true;
                _models[ModelsNumber.IR851].SupportedAlarms[AlarmCodes.SignleAlarmSlave1] = true;
                _models[ModelsNumber.IR851].SupportedAlarms[AlarmCodes.SingleAlarmSlave2] = true;
                _models[ModelsNumber.IR851].SupportedAlarms[AlarmCodes.AlarmInHeadHWord] = true;
                _models[ModelsNumber.IR851].SupportedAlarms[AlarmCodes.PulseCount] = true;
            }
            else if (s.Contains("IR85B"))
            {
                _models[ModelsNumber.IR85B] = new DeviceInfo("PRO E-51", address, ver, "Volumetric 26 degrees / 50m range");
                _models[ModelsNumber.IR85B].SupportedAlarms[AlarmCodes.GeneralWarningOverAllChannels] = true;
                _models[ModelsNumber.IR85B].SupportedAlarms[AlarmCodes.AlarmNearLeftRange] = true;
                _models[ModelsNumber.IR85B].SupportedAlarms[AlarmCodes.AlarmNearCenterRange] = true;
                _models[ModelsNumber.IR85B].SupportedAlarms[AlarmCodes.AlarmNearRightRange] = true;
                _models[ModelsNumber.IR85B].SupportedAlarms[AlarmCodes.AlarmFarLeftRange] = true;
                _models[ModelsNumber.IR85B].SupportedAlarms[AlarmCodes.AlarmFarCetnerRange] = true;
                _models[ModelsNumber.IR85B].SupportedAlarms[AlarmCodes.AlarmFarRightRange] = true;
                _models[ModelsNumber.IR85B].SupportedAlarms[AlarmCodes.PulseCountFar] = true;
                _models[ModelsNumber.IR85B].SupportedAlarms[AlarmCodes.PulseCountNear] = true;
            }
            else if (s.Contains("IR856"))
            {
                _models[ModelsNumber.IR856] = new DeviceInfo("PRO E-85", address, ver, "Volumetric 17 degrees / 60m range");
                _models[ModelsNumber.IR856].SupportedAlarms[AlarmCodes.GeneralWarningOverAllChannels] = true;
                _models[ModelsNumber.IR856].SupportedAlarms[AlarmCodes.AlarmNearLeftRange] = true;
                _models[ModelsNumber.IR856].SupportedAlarms[AlarmCodes.AlarmNearCenterRange] = true;
                _models[ModelsNumber.IR856].SupportedAlarms[AlarmCodes.AlarmNearRightRange] = true;
                _models[ModelsNumber.IR856].SupportedAlarms[AlarmCodes.AlarmFarLeftRange] = true;
                _models[ModelsNumber.IR856].SupportedAlarms[AlarmCodes.AlarmFarCetnerRange] = true;
                _models[ModelsNumber.IR856].SupportedAlarms[AlarmCodes.AlarmFarRightRange] = true;
                _models[ModelsNumber.IR856].SupportedAlarms[AlarmCodes.PulseCountFar] = true;
                _models[ModelsNumber.IR856].SupportedAlarms[AlarmCodes.PulseCountNear] = true;
            }
            else if (s.Contains("IR857"))
            {
                _models[ModelsNumber.IR857] = new DeviceInfo("PRO E-18W", address, ver, "Volumetric 90 degrees / 21m range");
                _models[ModelsNumber.IR857].SupportedAlarms[AlarmCodes.AlarmInfrared] = true;
                _models[ModelsNumber.IR857].SupportedAlarms[AlarmCodes.SingleAlarmMaster] = true;
                _models[ModelsNumber.IR857].SupportedAlarms[AlarmCodes.SignleAlarmSlave1] = true;
                _models[ModelsNumber.IR857].SupportedAlarms[AlarmCodes.SingleAlarmSlave2] = true;
                _models[ModelsNumber.IR857].SupportedAlarms[AlarmCodes.AlarmInHeadHWord] = true;
                _models[ModelsNumber.IR857].SupportedAlarms[AlarmCodes.PulseCount] = true;
            }
            else if (s.Contains("IR858"))
            {
                _models[ModelsNumber.IR858] = new DeviceInfo("PRO E-18", address, ver, "Volumetric 50 degrees / 24m range");
                _models[ModelsNumber.IR858].SupportedAlarms[AlarmCodes.AlarmInfrared] = true;
                _models[ModelsNumber.IR858].SupportedAlarms[AlarmCodes.SingleAlarmMaster] = true;
                _models[ModelsNumber.IR858].SupportedAlarms[AlarmCodes.SignleAlarmSlave1] = true;
                _models[ModelsNumber.IR858].SupportedAlarms[AlarmCodes.SingleAlarmSlave2] = true;
                _models[ModelsNumber.IR858].SupportedAlarms[AlarmCodes.AlarmInHeadHWord] = true;
                _models[ModelsNumber.IR858].SupportedAlarms[AlarmCodes.PulseCount] = true;
            }
            else if (s.Contains("IR859"))
            {
                _models[ModelsNumber.IR859] = new DeviceInfo("PRO E-40", address, ver, "Volumetric 15 degrees / 40m range");
                _models[ModelsNumber.IR859].SupportedAlarms[AlarmCodes.AlarmInfrared] = true;
                _models[ModelsNumber.IR859].SupportedAlarms[AlarmCodes.SingleAlarmMaster] = true;
                _models[ModelsNumber.IR859].SupportedAlarms[AlarmCodes.SignleAlarmSlave1] = true;
                _models[ModelsNumber.IR859].SupportedAlarms[AlarmCodes.SingleAlarmSlave2] = true;
                _models[ModelsNumber.IR859].SupportedAlarms[AlarmCodes.AlarmInHeadHWord] = true;
                _models[ModelsNumber.IR859].SupportedAlarms[AlarmCodes.PulseCount] = true;
            }
            else if (s.Contains("IR866"))
            {
                _models[ModelsNumber.IR866] = new DeviceInfo("PRO E-85H", address, ver, "Volumetric 17 degrees / H / 75m range");
                _models[ModelsNumber.IR866].SupportedAlarms[AlarmCodes.GeneralWarningOverAllChannels] = true;
                _models[ModelsNumber.IR866].SupportedAlarms[AlarmCodes.AlarmNearLeftRange] = true;
                _models[ModelsNumber.IR866].SupportedAlarms[AlarmCodes.AlarmNearCenterRange] = true;
                _models[ModelsNumber.IR866].SupportedAlarms[AlarmCodes.AlarmNearRightRange] = true;
                _models[ModelsNumber.IR866].SupportedAlarms[AlarmCodes.AlarmFarLeftRange] = true;
                _models[ModelsNumber.IR866].SupportedAlarms[AlarmCodes.AlarmFarCetnerRange] = true;
                _models[ModelsNumber.IR866].SupportedAlarms[AlarmCodes.AlarmFarRightRange] = true;
                _models[ModelsNumber.IR866].SupportedAlarms[AlarmCodes.PulseCountFar] = true;
                _models[ModelsNumber.IR866].SupportedAlarms[AlarmCodes.PulseCountNear] = true;
            }
            else if (s.Contains("IR867"))
            {
                _models[ModelsNumber.IR867] = new DeviceInfo("PRO E-18WH", address, ver, "Volumetric 90 degrees / H / 27m range");
                _models[ModelsNumber.IR867].SupportedAlarms[AlarmCodes.AlarmInfrared] = true;
                _models[ModelsNumber.IR867].SupportedAlarms[AlarmCodes.SingleAlarmMaster] = true;
                _models[ModelsNumber.IR867].SupportedAlarms[AlarmCodes.SignleAlarmSlave1] = true;
                _models[ModelsNumber.IR867].SupportedAlarms[AlarmCodes.SingleAlarmSlave2] = true;
                _models[ModelsNumber.IR867].SupportedAlarms[AlarmCodes.AlarmInHeadHWord] = true;
                _models[ModelsNumber.IR867].SupportedAlarms[AlarmCodes.PulseCount] = true;
            }
            else if (s.Contains("IR868"))
            {
                _models[ModelsNumber.IR868] = new DeviceInfo("PRO E-18H", address, ver, "Volumetric 50 degrees / H / 30m range");
                _models[ModelsNumber.IR868].SupportedAlarms[AlarmCodes.AlarmInfrared] = true;
                _models[ModelsNumber.IR868].SupportedAlarms[AlarmCodes.SingleAlarmMaster] = true;
                _models[ModelsNumber.IR868].SupportedAlarms[AlarmCodes.SignleAlarmSlave1] = true;
                _models[ModelsNumber.IR868].SupportedAlarms[AlarmCodes.SingleAlarmSlave2] = true;
                _models[ModelsNumber.IR868].SupportedAlarms[AlarmCodes.AlarmInHeadHWord] = true;
                _models[ModelsNumber.IR868].SupportedAlarms[AlarmCodes.PulseCount] = true;
            }
            else
            {
                _models[ModelsNumber.Unknown] = new DeviceInfo("Unknown", address);
                for(int i=0; i < (int)AlarmCodes.Size; ++i)
                {
                    _models[ModelsNumber.Unknown].SupportedAlarms[(AlarmCodes)i] = false;
                }
            }
        }

        // todo: remove after tests 
        public void PrintAllTest()
        {
            foreach (var kv in _models)
            {
                IvzLogger.Instance.Log(kv.Value.DetailedInfo());
            }
        }

    }

}
