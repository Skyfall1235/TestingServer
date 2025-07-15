namespace TestingServer.NET.InternalData
{
    public interface IPacketTransportBase
    {
        public enum OpCode : byte
        {
            // Connection
            Handshake = 0x01,//for like, ensuring that the client and server are oth running compatible versions
            Acknowledge = 0x02,
            Ping = 0x03,
            Pong = 0x04,
            Disconnect = 0x05,

            // Auth
            Login = 0x10,
            LoginResponse = 0x11,
            Logout = 0x12,
            Register = 0x13,//creating a new user

            // Commands
            ExecuteCommand = 0x20,
            CommandResult = 0x21,
            QueryData = 0x22,
            DataResponse = 0x23,

            // Messaging
            Subscribe = 0x30,
            Unsubscribe = 0x31,
            PublishMessage = 0x32,
            ReceiveMessage = 0x33,

            // File transfer
            UploadStart = 0x40,
            UploadChunk = 0x41,//for transaferrring a peice of a file. SEND CHUNKS BECAUSE TOO MUCH MEMORY WILL CRASH THE SERVER
            UploadComplete = 0x42,
            DownloadRequest = 0x43,
            DownloadChunk = 0x44,

            // Errors
            Error = 0xFE,
            Unknown = 0xFF
        }
        public static byte OpcodeToByte(OpCode opcode)
        {
            return (byte)opcode;
        }
        public static OpCode byteToOpCode(byte incomingOpcode)
        {
            // Check if the byte matches any defined OpCode value
            if (Enum.IsDefined(typeof(OpCode), incomingOpcode))
            {
                return (OpCode)incomingOpcode;
            }
            else
            {
                Console.WriteLine($"[Warning] Unknown opcode received: 0x{incomingOpcode:X2}");
                return OpCode.Unknown; // Fallback for invalid/undefined opcodes
            }
        }
    }
}
