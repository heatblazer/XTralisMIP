using System;

namespace XTralisCommunication
{
    public class TcpSocket : IConnection, IDisposable
    {
        public bool IsConnected()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int Recieve(out byte[] data, int count, out string optinfo)
        {
            throw new NotImplementedException();
        }

        public bool Send(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
