using System;
using System.Net;
using System.Net.Sockets;
using static TestingServer.PacketTransportBase;


namespace TestingServer
{
    //THIS IS A TEMP REFERENCE SO I CAN KEEP TRACK OF THESE
    public static class RefVars
    {
        public static IPAddress ip = IPAddress.Parse("127.0.0.1");
        public static int portIn = 3912;
    }
    internal class Program
    {
        static TcpListener? listener;
        static ServerSetup setup;
        static List<Client> users;
        //so i dont have to manually type it ever again
        static void Main(string[] args)
        {
            //some basic code, then creating a place to lsiten from
            Console.WriteLine("Hello, World!");
            //why do i do this? so i can set up stuff at rtuntime lol
            Console.Write("Enter the Global Password ");
            string password;
            string? input = Console.ReadLine();
            if (input != null)
            {
                password = input;
                setup = new ServerSetup(RefVars.ip, RefVars.portIn, password);
            }
            else
            {
                setup = new ServerSetup(RefVars.ip, RefVars.portIn);
            }
            
            listener = new(setup.ServerIP, setup.Port);
            users = new();
            listener.Start();

            
            while (true)
            {
                //this literally just listens for them.
                var client = listener.AcceptTcpClient();
                Console.WriteLine("client connected");
                users.Add(new Client(client));
                //if we need to broadcast the connection, do it here
            }
        }

        static void BroadcastConnection()
        {
            foreach (Client client in users)
            {
                foreach (Client internalUser in users)
                {
                    var broadcastPacket = new PacketBuilder();
                    broadcastPacket.WriteOpCode(OpcodeToByte(OpCode.Handshake));
                    broadcastPacket.WriteString(internalUser.UserName);
                    broadcastPacket.WriteString(internalUser.UserName.ToString());
                    client.ClientSocket.Client.Send(broadcastPacket.GetPacketBytes());
                }
            }
        }

        
    }

    public class ClientServer
    {
        TcpClient client;
        public PacketReader reader;
        public event Action ConnectedEvent;

        public ClientServer()
        {
            client = new TcpClient();
            ConnectedEvent += UserConnected;
        }

        public void ConnectToServer(string userName)
        {
            if(!client.Connected)
            {
                client.Connect(RefVars.ip, RefVars.portIn);
                reader = new(client.GetStream());
                //im using the username for now to get a better grasp on sending messages
                if(!string.IsNullOrEmpty(userName))
                {
                    var connectedPacket = new PacketBuilder();
                    connectedPacket.WriteOpCode(OpcodeToByte(OpCode.Handshake));
                    connectedPacket.WriteString(userName);
                    client.Client.Send(connectedPacket.GetPacketBytes());
                }
                ReadPackets();
            }
        }
        public void UserConnected()
        {
            //in the tutorial, he calls to add this client to a collection of users. this isnt needed here:)
        }
        public void ReadPackets()
        {//i feellike this could be better lol
            Task.Run(() =>
            {
                while (true)
                {
                    OpCode opcode = (OpCode)reader.ReadByte();
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


    internal class ServerSetup
    {
        public ServerSetup(IPAddress serverIP, int port, string globalPassword = "default", int maxChunkSize = 32)
        {
            ServerIP = serverIP;
            Port = port;
            GlobalPassword = globalPassword;
            MaxChunkSize = maxChunkSize;
        }
        public ServerSetup(int port, string globalPassword = "default", int maxChunkSize = 32)
        {
            ServerIP = IPAddress.Parse("127.0.0.1");
            Port = port;
            GlobalPassword = globalPassword;
            MaxChunkSize = maxChunkSize;
        }

        public IPAddress ServerIP { get; }
        public int Port { get; }
        public string GlobalPassword { get; }
        public int MaxChunkSize { get; }

    }
}
