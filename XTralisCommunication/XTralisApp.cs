using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static XTralisCommunication.Constants;

namespace XTralisCommunication
{
    // wrapping up all 
    public class XTralisApp
    {
        private const int MaxDevicesPerBus = 32;

        IConnection connection = new RS485("COM5");
        

        public XTralisApp()
        {
        }

        
        //also can select different devices with different connections
        private void SetupConnections()
        {
            foreach (var kv in XtralisModelsManager.Instance.DevicesVer2)
            {
                kv.Value.Connect(connection);
            }
        }

        private void TestInfo()
        {
            foreach (var kv in XtralisModelsManager.Instance.DevicesVer2)
            {
                DeviceInfo info = kv.Value.GetInfo();
                IvzLogger.Instance.Log(info.ToString());
            }
        }


        public void Start()
        {
            CheckConnection();
            DiscoverModels();
            SetupConnections();

            for (; ; )      //todo:  rework it
            {
                // poll or event drivern??? 
                //Poll is simpler but timing may be critical, 
                // event driven more convinient - harder to implement since it may be buggy
                foreach (KeyValuePair<int, XModel> item in XtralisModelsManager.Instance.DevicesVer2)
                {
                    item.Value.IsOnline();
                    item.Value.CmdGetData();
                    (new Task(() => item.Value.Update())).Start();
                }
            }
        }

        private void DiscoverModels()
        {
            for(int i=1; i < MaxDevicesPerBus; ++i)
            {
                byte[] model = ComGenerator.CmdGetCfg(i);
                Console.WriteLine($"Request:[{model[0]}][{model[1]}][{model[2]}][{model[3]}][{model[4]}]");
                if (connection.Send(model))
                {
                    Thread.Sleep(100);
                    byte[] res = null;
                    string outinfo = null;
                    int cnt = connection.Recieve(out res, (int)AlarmLengths.CmdGetCfgAckn, out outinfo);
                    Thread.Sleep(100);
                    if (res != null)
                    {
                        XtralisModelsManager.Instance.Setup(outinfo);
                    }
                }
            }
            foreach(KeyValuePair<int, XModel> info in XtralisModelsManager.Instance.DevicesVer2)
            {
                IvzLogger.Instance.Log($"Device ID:{info.Value.ID} Info: {info.Value.GetInfo().ToString()}");
            }
        }

        private void CheckConnection()
        {
            for(int i=1; i < MaxDevicesPerBus; ++i)
            {
                byte[] checkpin = ComGenerator.CmdChk(i);
                Console.WriteLine($"Request:[{checkpin[0]}][{checkpin[1]}][{checkpin[2]}][{checkpin[3]}][{checkpin[4]}]");
                if (connection.Send(checkpin))
                {
                    Thread.Sleep(100);
                    byte[] res = null;
                    string outinfo = null;
                    int cnt = connection.Recieve(out res, (int)AlarmLengths.CmdChkAckn, out outinfo);
                    Thread.Sleep(100);
                    if (res != null)
                    {
                        Console.WriteLine($"\tResponse:[{res[0]}][{res[1]}][{res[2]}][{res[3]}][{res[4]}]");
                    }
                }
            }
        }



    }
}
