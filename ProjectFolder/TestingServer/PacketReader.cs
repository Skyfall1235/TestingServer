using System.Net.Sockets;
using System.Text;
namespace TestingServer
{
    public class PacketReader : BinaryReader, PacketTransportBase
    {
        private readonly NetworkStream m_stream;
        public PacketReader(NetworkStream networkStream) : base(networkStream)
        {
            m_stream = networkStream;
        }
        public string ReadMessage()
        {
            byte[] messageBuffer;
            var length = ReadInt32();
            messageBuffer = new byte[length];
            m_stream.Read(messageBuffer, 0, length);
            var message = Encoding.ASCII.GetString(messageBuffer);
            return message;
        }
    }
}
