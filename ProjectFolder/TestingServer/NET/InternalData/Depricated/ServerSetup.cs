using System.Net;


namespace TestingServer.NET.InternalData.Depricated
{
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
