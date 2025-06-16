using System.Net.Sockets;
using System.Text;
namespace TestingServer
{
    public class PacketBuilder : PacketTransportBase
    {
        internal MemoryStream stream;
        public PacketBuilder()
        {
            stream = new MemoryStream();
        }
        public void WriteOpCode(byte opCode)
        {
            stream.WriteByte(opCode);
        }
        public void WriteString(string message)
        {
            var msgLength = message.Length;
            stream.Write(BitConverter.GetBytes(msgLength));
            stream.Write(Encoding.ASCII.GetBytes(message));
        }
        public byte[] GetPacketBytes()
        {
            return stream.ToArray();
        }
        public void SendOpCodeAndMessage(TcpClient client, byte opCode, string message, PacketBuilder builder)
        {
            builder.WriteOpCode(opCode);
            builder.WriteString(message);
            client.Client.Send(builder.GetPacketBytes());
        }
    }
}
