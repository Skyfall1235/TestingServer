using System.Net.Sockets;
using System.Text;
namespace TestingServer.NET.InternalData.Depricated
{
    public class PacketReader : BinaryReader, IPacketTransportBase
    {
        private readonly NetworkStream m_stream;
        public PacketReader(NetworkStream networkStream) : base(networkStream)
        {
            m_stream = networkStream;
        }
        public byte ReadOpCode()
        {
            return ReadByte();
        }
        public string ReadMessage()
        {
            int length = ReadInt32();
            byte[] messageBuffer = new byte[length];

            int totalRead = 0;
            while (totalRead < length)//looping is better because the byte stream lenth may be none or may be too long to hnadle in one go
            {
                int bytesRead = m_stream.Read(messageBuffer, totalRead, length - totalRead);
                if (bytesRead == 0)
                {
                    throw new IOException("Unexpected end of stream while reading message.");
                }
                totalRead += bytesRead;
            }
            //if we need to swap encoding to UTF-8, swap this line
            //return Encoding.UTF8.GetString(messageBuffer);
            return Encoding.ASCII.GetString(messageBuffer);
        }
    }
}
