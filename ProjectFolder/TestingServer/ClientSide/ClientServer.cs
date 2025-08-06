using System.Net.Sockets;
using TestingServer.NET.InternalData.Depricated;
using static TestingServer.NET.InternalData.Depricated.IPacketTransportBase;


namespace TestingServer.ClientSide
{
    public class ClientServer
    {
        TcpClient client;
        public PacketReader? reader;
        public event Action ConnectedEvent;

        public ClientServer()
        {
            client = new TcpClient();
            //ConnectedEvent += UserConnected;
        }

        public void ConnectToServer(string userName)
        {
            if (!client.Connected)
            {
                client.Connect(RefVars.ip, RefVars.portIn);
                reader = new(client.GetStream());
                //im using the username for now to get a better grasp on sending messages
                if (!string.IsNullOrEmpty(userName))
                {
                    var connectedPacket = new PacketBuilder();
                    connectedPacket.WriteOpCode(OpcodeToByte(OpCode.Handshake));
                    connectedPacket.WriteString(userName);
                    client.Client.Send(connectedPacket.GetPacketBytes());
                }
                ReadPackets();
            }
        }
        public void ReadPackets()
        {//i feellike this could be better lol
            Task.Run(() =>
            {
                while (true)
                {
                    OpCode opcode = (OpCode)reader!.ReadByte();
                    switch (opcode)
                    {
                        default:
                            break;
                        case OpCode.Handshake:
                            ConnectedEvent.Invoke();
                            break;
                    }
                }
            });
        }

    }
}
