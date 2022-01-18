using System;
using System.Linq;
using System.Text;
using System.Threading;

namespace XTralisCommunication
{

    class Program
    {

        static void Main(string[] args)
        {

            XTralisApp app = new XTralisApp();
            app.Start();
            for (; ; )
            {
            }            
        }
        
    }
}
