
namespace XTralisCommunication
{
    // masks for Alarms in various models
    // for convinienace the codes might be doubled 
    public static class Constants
    {        

        public enum ModelsNumber
        {
            IR853,
            IR863,
            IR873,
            IR883,
            IR854,
            IR864,
            IR86C,
            IR851,
            IR85B,
            IR856,
            IR857,
            IR858,
            IR859,
            IR866,
            IR867,
            IR868,
            Unknown,
            Size = Unknown
        }
        

        public enum AlarmCodes
        {
            GeneralAlarm,
            GeneralWarningOverAllChannels,
            AlarmInfrared,
            AlarmLeft,
            AlarmShortRange,
            AlarmNearLeftRange,
            AlarmRight,
            AlarmMediumRange,
            AlarmLongRange,
            AlarmNearCenterRange,
            AlarmNearRightRange,
            AlarmDicertionalRightToLeft,
            AlarmDicertionalLeftToRight,
            WarningShortRange, 
            AlarmFarLeftRange,
            LeftIntrusion, 
            WarningMediumRange,
            AlarmFarCetnerRange,
            RightIntrusion,
            WarningLongRange,
            AlarmFarRightRange,
            SingleAlarmMaster,
            SignleAlarmSlave1,
            SingleAlarmSlave2,
            AlarmInHeadHWord,
            CoverVandalismAntiMasking,
            AlarmRejection,
            HardwareInfromation,
            PowerFailure,
            CreepZoneCh1,
            CreepZoneCh2,
            PulseCount, 
            PulseCountNear,
            PulseCountFar,
            CoverOpen,
            Alignment,
            TamperBraket,
            AntiMasking,
            Unknown, // conviniance 
            Size = Unknown
        }

        public enum AlarmCommands
        {
            CmdGetAlmHeadL = 0x90,
            CmdGetAlmHeadH = 0x92,
            CmdGetAlmInfoBitC = 0x93,
            CmdGetData = 0xAB
        }

        public enum AlarmLengths
        {
            CmdCheck = 5,
            CmdChkAckn = CmdCheck,
            CmdGetCfg = 5,
            CmdGetCfgAckn = CmdGetCfg + 0x10,
            CmdGetAlm = 5,
            CmdGetAlmAkn = CmdGetAlm + 4,
            CmdGetAlm2 = 5,
            CmdGetAlm2Ackn = CmdGetAlm2 + 2,
            CmdGetAlmBitInfo = 6,
            CmdGetAlmBitInfoAckn = 2 + CmdGetAlmBitInfo,
            OtherAlarms = 5,
            OtherAlarmsAkn = 4 + OtherAlarms,
            CmdGetDat = 6,
            CmdGetDatAckn = 5 + 0x0D,
            CmdGetDat2Ackn = 5 + 0x12,
            CmdGetData3Ackn = 5 + 0x12
        }


        //CmdGetAlm bit masks to be parsed   
        public static class AlarmHeadLWord
        {
            public static class LowByte
            {
                public const byte GeneralAlarm = 0x01;
                public const byte GeneralWarningOverAllChannels = 0x02;
                public const byte AlarmInfrared = 0x03; // e45, e45h, e18... etc.
                public const byte AlarmLeft = 0x03; // pro e45d, pro e-45dh
                public const byte AlarmShortRange = 0x03; // pro e 100, 100h, 400h
                public const byte AlarmNearLeftRange = 0x03; // pro e51, e85, e85h
                public const byte AlarmRight = 0x04; // e45, e45h
                public const byte AlarmMediumRange = 0x04; // e 100, e100h, e400h
                public const byte AlarmNearCenterRange = 0x04; //51, 85, 85h
                public const byte AlarmDirectionalLtoR = 0x05; // e45d, e45dh
                public const byte AlarmLongRange = 0x05; // e100, e100h, e 400h
                public const byte AlarmNearRightRange = 0x05; // e51, e85, e85h
                public const byte AlarmDirectionalRtoL = 0x06; // e45, e45d
                public const byte WarningShortRange = 0x06;
                public const byte AlarmFarLeftRange = 0x06;
                public const byte LeftIntrusion = 0x07;
                public const byte WarningMediumRange = 0x07;
                public const byte AlarmFarCenter = 0x07;
                public const byte RightIntrusion = 0x08;
                public const byte WaringLongRange = 0x08;
                public const byte AlarmFarRightRange = 0x08;
            }

            public static class HighByte
            {
                public const byte SingleAlarmMaster = 0x09; // only PRO - E detectors 
                public const byte SingleAlarmSlave1 = 0x0A; // only pro -e
                public const byte SingleAlarmSlave2 = 0x0B; // only pro-e
                public const byte AlarmInHeadHWord = 0x0C;
                public const byte CoverVandalismAntiMasking = 0x0D; // all
                public const byte AlarmRejection = 0x0E; // all
                public const byte HardwareInformation = 0x0F; // all
                public const byte PowerFailure = 0x10;
            }
        } // AlarmHeadLWord


        public static class AlarmHeadHWord
        {
            public static class LowByte
            {
                public const byte CreepZoneCh1 = 0x01; // all devices
                public const byte CreepZoneCh2 = 0x02; // all devices
                // from 3 to 8 are reserved and not used (as in documentation )
            }

            public static class HighByte
            {
                public const byte PulseCount = 0x09; // PRO E-45 / PRO E-45H PRO E-18 / PRO E-18H / PRO E-18W PRO E-18WH / PRO E-30 / PRO E-40 
                public const byte PulseCountNear = 0x09; // pro e51, pro e 85, pro e 85h
                public const byte PulsCountFar  = 0x0A; // pro e51, pro e85 pro e 85h

            }

        } // alarmhword

        public static class InfoBitCWord
        {
            public static class LowByte
            {
                public const byte CoverOpen = 0x01; // all
                public const byte Alignment = 0x02; // all
                public const byte TamperBraket = 0x04; // all
                // bit 3 and from 5 to 8 are unused as in documentation
            }

            public static class HighByte
            {
                public const byte AntiMasking = 0x09; // all
                // all other are unued
            }
        } // InfoBitCWrod
    }
}



//IR 853  	PRO E-45 	Curtain medium range / 50m range
//IR 863  	PRO E-45H Curtain medium range / H / 60m range
//IR 873 	PRO E-45D 	Curtain medium range directional / 50m range
//IR 883 	PRO E-45DH Curtain medium range directional / H / 60m range

//IR 854  	PRO E-100 	Curtain long range  / 120m range
//IR 864  	PRO E-100H Curtain long range / H / 150m range
//IR 86C PRO E-400H Curtain long range / H / 220m range

//IR 851  	PRO E-30 	Volumetric 50°  / 30m range
//IR 85B PRO E-51 	Volumetric 26°  /  50m range
//IR 856  	PRO E-85 	Volumetric 17°  /  60m range
//IR 857  	PRO E-18W Volumetric 90°   /  21m range
//IR 858  	PRO E-18 	Volumetric 50°  /  24m range
//IR 859  	PRO E-40 	Volumetric 15°  /  40m range
//IR 866  	PRO E-85H Volumetric 17°  / H /  75m range
//IR 867  	PRO E-18WH Volumetric 90° / H / 27m range
//IR 868  	PRO E-18H Volumetric 50° / H / 30m range
