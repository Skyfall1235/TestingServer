using System.Net.Sockets;

namespace TestingServer.NET.InternalData.Depricated
{
    public class ClientUID
    {
        public string? UserName { get; set; }
        public Guid UID { get; set; }
        public TcpClient ClientSocket { get; set; }
        PacketReader m_reader;
        public ClientUID(TcpClient client)
        {
            ClientSocket = client;
            UID = Guid.NewGuid();
            m_reader = new(ClientSocket.GetStream());
            var opCode = m_reader.ReadByte();
            //if we dont recognise the code, dump it immediately
            bool ValidateOpCode = IPacketTransportBase.ByteToOpCode(opCode) != IPacketTransportBase.OpCode.Unknown;
            if (!ValidateOpCode)
            {
                client.Close();//closes the connection imemdiately
            }
            //for now, this is how it would be done for strings.
            UserName = m_reader.ReadMessage();

            Console.WriteLine($"{DateTime.Now}: user connected with the username {UserName}");
        }
    }
}
