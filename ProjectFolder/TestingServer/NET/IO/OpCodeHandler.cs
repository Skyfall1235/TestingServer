using System.Collections.Concurrent;
using TestingServer.NET.InternalData.Depricated;
using static TestingServer.NET.InternalData.Depricated.IPacketTransportBase;

namespace TestingServer.NET.IO
{
    internal class OpCodeHandler
    {
        LoginHandler loginHandle { get; set; }
        ConcurrentDictionary<string, ClientUID> connectedClients = Program.ConnectedClients;
        // Define a handler delegate
        public delegate Task PacketHandlerDelegate(ClientUID client, PacketReader reader);

        // A global mapping of opcodes to handlers
        public readonly Dictionary<OpCode, PacketHandlerDelegate> OpcodeHandlers;

        public OpCodeHandler(ref LoginHandler loginHandle)
        {
            this.loginHandle = loginHandle;

            OpcodeHandlers = new()
            {
                { OpCode.Ping, HandlePing },
                { OpCode.Login, HandleLogin },
                { OpCode.Register, HandleRegister },
                // ... add more here

         // Connection
                //{ OpCode.Handshake, HandleHandshake },
                //{ OpCode.Acknowledge, HandleAcknowledge },
                { OpCode.Ping, HandlePing },
                //{ OpCode.Pong, HandlePong },
                //{ OpCode.Disconnect, HandleDisconnect },

        // Auth
                { OpCode.Login, HandleLogin },
                //{ OpCode.LoginResponse, HandleLoginResponse },
                { OpCode.Logout, HandleLogout },
                { OpCode.Register, HandleRegister },

        // Commands
                //{ OpCode.ExecuteCommand, HandleExecuteCommand },
                //{ OpCode.CommandResult, HandleCommandResult },
                //{ OpCode.QueryData, HandleQueryData },
                //{ OpCode.DataResponse, HandleDataResponse },

        // Messaging
                //{ OpCode.Subscribe, HandleSubscribe },
                //{ OpCode.Unsubscribe, HandleUnsubscribe },
                //{ OpCode.PublishMessage, HandlePublishMessage },
                //{ OpCode.ReceiveMessage, HandleReceiveMessage },

        // File Transfer
                //{ OpCode.UploadStart, HandleUploadStart },
                //{ OpCode.UploadChunk, HandleUploadChunk },
                //{ OpCode.UploadComplete, HandleUploadComplete },
                //{ OpCode.DownloadRequest, HandleDownloadRequest },
                //{ OpCode.DownloadChunk, HandleDownloadChunk },

        // Errors
                //{ OpCode.Error, HandleError },
                { OpCode.Unknown, HandleUnknown }
            };
        }

        public async Task HandlePing(ClientUID client, PacketReader reader)
        {
            Console.WriteLine($"Received ping from {client.UID}");

            var pong = new PacketBuilder();
            pong.WriteOpCode((byte)OpCode.Pong);
            await client.ClientSocket.GetStream().WriteAsync(pong.GetPacketBytes());
        }

        public async Task HandleLogin(ClientUID client, PacketReader reader)
        {
            //read the incoming info for the username n password
            string username = reader.ReadMessage();
            string password = reader.ReadMessage();

            //check to see ifthe database already has the user
            bool valid = await loginHandle.ValidateCredentialsAsync(username, password);

            //construct the response and send it
            var response = new PacketBuilder();
            response.WriteOpCode((byte)OpCode.LoginResponse);
            response.WriteString(valid ? "OK" : "FAIL");

            if (valid)
            {
                client.UserName = username;
            }
        }

        public Task HandleLogout(ClientUID client, PacketReader reader)
        {
            Console.WriteLine($"Logout from {client.UID}");
            CleanUpClientSocket(client);
            return Task.CompletedTask;
        }

        public async Task HandleRegister(ClientUID client, PacketReader reader)
        {
            string username = reader.ReadMessage();
            string password = reader.ReadMessage();

            //come back later and fix this
            bool success = true;

            var response = new PacketBuilder();
            response.WriteOpCode((byte)OpCode.LoginResponse);
            response.WriteString(success ? "REGISTERED" : "USERNAME_TAKEN");
            await client.ClientSocket.GetStream().WriteAsync(response.GetPacketBytes());
        }

        public async Task HandleUnknown(ClientUID client, PacketReader reader)
        {
            Console.WriteLine($"Received unknown or invalid opcode from {client.UID}. Disconnecting client.");

            // Optionally send an error packet to client before disconnecting
            var errorPacket = new PacketBuilder();
            errorPacket.WriteOpCode((byte)OpCode.Error);
            errorPacket.WriteString("Invalid opcode received. Disconnecting.");
            await client.ClientSocket.GetStream().WriteAsync(errorPacket.GetPacketBytes(), 0, errorPacket.GetPacketBytes().Length);

            // Cleanup and close connection
            CleanUpClientSocket(client);
        }

        void CleanUpClientSocket(ClientUID client)
        {
            // Cleanup
            client.ClientSocket.Close();
            connectedClients.TryRemove(client.UID.ToString(), out _);
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