using System;
using System.Linq;
using System.IO.Ports;
using System.Threading;

namespace XTralisCommunication
{

    public class RS485 : IConnection, IDisposable
    {
        public static bool NeedsFix = false;

        public delegate void doWork(object userData);

        private SerialPort _port = null;

        public SerialPort SPI
        {
            get { return _port; }
        }

        public RS485(string name="COM3", int baud=9600, int stopbits =1 , bool parity=false/*even odd for now*/, 
            int databits = 8, int rtimeout=100, int wtimeout=100)
        {

            // clamp it 
            if (stopbits < 0 || stopbits > 3)
                stopbits = 1;
            try
            {
                _port = new SerialPort(name, baud, parity ? Parity.Odd : Parity.Even, databits, StopBits.One);
                if (_port != null)
                {
                    _port.ReadTimeout = rtimeout;
                    _port.WriteTimeout = wtimeout;
                    _port.Open();
                    _port.Handshake = Handshake.None;
                    _port.DiscardInBuffer();
                    _port.DiscardOutBuffer();
                    _port.RtsEnable = true;
                    _port.DtrEnable = true;
                    }
            } catch 
            {
                // log 
            }
        }


        public bool IsConnected()
        {
            bool res = false;
            if (_port?.IsOpen??false)
                res = true;
            return res;
        }

        public bool Send(byte[] data)
        {
            bool res = true;
            try
            {
                string flush = _port.ReadExisting();
                _port.Write(data, 0, data.Count());
                if (NeedsFix)
                {
                    FixFlush();
                    Thread.Sleep(10);
                }

            }
            catch { res = false; }
            return res;
        }

        private void FixFlush(int n=5)
        {
            byte[] d = new byte[n];
            _port.Read(d, 0, n);
        }


        public int Recieve(out byte[] data, int count, out string optinfo)
        {
            if (count <= 0)
                throw new IndexOutOfRangeException("Must be positive non-null values value!!!");

            int size = -1;
            byte[] rdata = new byte[count];
            try
            {
                int n = 0, r = count;
                while (n < count)
                {
                    n += _port.Read(rdata, n, r);
                    r -= n;
                }

                optinfo = System.Text.Encoding.UTF8.GetString(rdata); ;
                data = rdata;
                if (r != 0)
                    throw new Exception("EXCEPTION IN READ!!!");

                size = n;

            } catch (Exception ex)
            {
                optinfo = string.Format("Excetion: {0}", ex.Message);
                data = null;
            }
            return size;
        }

        public void Dispose()
        {
            if (_port != null)
            {
                _port.Close();
                _port.BaseStream.Flush();
                _port.BaseStream.Close();
                _port.Dispose();
                _port = null;
            }
        }
    }
}
