using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using TestingServer.NET.InternalData;
using TestingServer.NET.IO;
using static TestingServer.NET.InternalData.IPacketTransportBase;

//TO DO
/*
 * -create unit tests?
 * -test connections, test responsiveness
 * -add more op code handling
 * -potnetialyl learn how to store stuff to a database?
 * -
 * -
 * -
 */
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
        static ServerSetup? m_setup;
        static LoginHandler loginHandler = new LoginHandler();
        public static readonly ConcurrentDictionary<string, ClientUID> ConnectedClients = new();
        //so i dont have to manually type it ever again
        static async Task Main(string[] args)
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
                m_setup = new ServerSetup(RefVars.ip, RefVars.portIn, password);
            }
            else
            {
                m_setup = new ServerSetup(RefVars.ip, RefVars.portIn);
            }

            loginHandler.LoadFromFile();
            listener = new(m_setup.ServerIP, m_setup.Port);
            listener.Start();

            using var cts = new CancellationTokenSource();

            // Start server heartbeat
            var heartbeatTask = HeartbeatAsync(TimeSpan.FromSeconds(10), cts.Token);


            await AcceptClientsAsync();//begins asyncronously running accepting of clients

            // Cancel the heartbeat and wait for it to finish
            cts.Cancel();
            await heartbeatTask;
        }


        static async Task AcceptClientsAsync()
        {
            while (true)
            {
                var client = await listener!.AcceptTcpClientAsync();
                Console.WriteLine("Client connected");

                ClientUID newClientUID = new(client);

                ConnectedClients.TryAdd(newClientUID.UID.ToString(), newClientUID);

                // Handle client connection on a new task
                _ = HandleClientAsync(newClientUID);
            }
        }

        public static async Task HandleClientAsync(ClientUID clientId)
        {
            //we need to itialize the opcode handler instance
            OpCodeHandler handler = new(ref loginHandler);
            NetworkStream stream = clientId.ClientSocket.GetStream();
            PacketReader reader = new PacketReader(stream);//since the reader contains the packet info, we pass it along :)

            // 1. Read opcode (1 byte)
            int opCode = stream.ReadByte();
            OpCode sentCode = (OpCode)opCode;

            //search our dictionary for the stuff we want to serve/do, and then run it if its found :)
            if (handler.OpcodeHandlers.TryGetValue(sentCode, out var variableHandler))
            {
                await variableHandler(clientId, reader);
            }
            else
            {
                Console.WriteLine($"Unknown opcode from {clientId.UID}: {sentCode}");
                //disconnect the client
                await handler.HandleUnknown(clientId, reader);
            }
        }

        public static async Task HeartbeatAsync(TimeSpan interval, CancellationToken token)
        {
            int tick = 0;

            while (!token.IsCancellationRequested)
            {
                Console.WriteLine($"[Heartbeat] Server is alive. Tick: {++tick} — {DateTime.Now:T}");
                await Task.Delay(interval, token);
            }

            Console.WriteLine("[Heartbeat] Shutting down heartbeat.");
        }
    }
}


//NetworkStream stream = tcpClient.GetStream();
//PacketReader reader = new PacketReader(stream); // your custom reader

//try
//{
//    while (true)
//    {
//        // 1. Read opcode (1 byte)
//        int opCode = stream.ReadByte();
//        OpCode sentCode = (OpCode)opCode;

//        //now we handle switching
//        switch (sentCode)
//        {




//            case OpCode.Logout:
//                Console.WriteLine($"Logout from {clientId.UID}");
//                CleanUpClientSocket();
//                return;

//            // Add more opcodes as needed
//            case OpCode.Unknown:
//            default:
//                
//                return;
//        }
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"Error with {clientId.UID}: {ex.Message}");
//}
//finally
//{
//    CleanUpClientSocket();
//}


//        }