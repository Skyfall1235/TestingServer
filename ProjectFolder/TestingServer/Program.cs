using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TestingServer.NET.InternalData.Depricated;
using TestingServer.NET.IO;
using static TestingServer.NET.InternalData.Depricated.IPacketTransportBase;

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
        static TcpListener? serverListener;
        static ServerSetup? m_setup;
        static LoginHandler loginHandler = new LoginHandler();
        public static readonly ConcurrentDictionary<string, ClientUID> ConnectedClients = new();
        //so i dont have to manually type it ever again
        static async Task Main()
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

            //now i set up the server
            serverListener = new(m_setup.ServerIP, m_setup.Port);
            serverListener.Start();

            //main loop
            Console.WriteLine("Now Accepting Clients");
            while (true)
            {
                TcpClient client = await serverListener!.AcceptTcpClientAsync();

                var thread = new Thread(() =>  { HandleClientAsync(client); });
                thread.Start();
            }
        }

        private static async Task HandleClientAsync(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            string? message;
            try
            {
                while (true)
                {
                    //read the message from the client
                    byte[] buffer = new byte[1024];
                    int byteRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (byteRead == 0) break; //client disconnected

                    message = Encoding.UTF8.GetString(buffer, 0, byteRead);

                    //basic response we can remove later
                    byte[] response = Encoding.UTF8.GetBytes($"server: {message}");
                    await stream.WriteAsync(response, 0, response.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.ToString());
            }
            finally
            {
                client.Close();
                Console.WriteLine("client disconnected");
            }           
        }


        static async Task AcceptClientsAsync()
        {
            while (true)
            {
                var client = await serverListener!.AcceptTcpClientAsync();
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


