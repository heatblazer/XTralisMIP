
namespace XTralisCommunication
{
    public interface IConnection
    {
        bool Send(byte[] data);
        int Recieve(out byte[] data, int count, out string optinfo);

        bool IsConnected();
    }
}
