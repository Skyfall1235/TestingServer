using System.Net.Sockets;
using System.Text;
namespace TestingServer.NET.InternalData
{
    /// <summary>
    /// A utility class for building packets to send over a network stream.
    /// Handles writing opcodes, strings, raw bytes, and sending formatted packets to a TCP client.
    /// </summary>
    public class PacketBuilder : IPacketTransportBase
    {
        internal MemoryStream stream;

        /// <summary>
        /// Initializes a new instance of the <see cref="PacketBuilder"/> class.
        /// </summary>
        public PacketBuilder()
        {
            stream = new MemoryStream();
        }

        /// <summary>
        /// Writes a single opcode byte to the packet.
        /// </summary>
        /// <param name="opCode">The opcode to write.</param>
        public void WriteOpCode(byte opCode)
        {
            stream.WriteByte(opCode);
        }

        /// <summary>
        /// Writes a string to the packet with a 4-byte length prefix.
        /// The string is encoded using ASCII encoding.
        /// </summary>
        /// <param name="message">The string message to write.</param>
        public void WriteString(string message)
        {
            var msgLength = message.Length;
            stream.Write(BitConverter.GetBytes(msgLength), 0, 4);
            stream.Write(Encoding.ASCII.GetBytes(message), 0, msgLength);
        }

        /// <summary>
        /// Returns the full packet data as a byte array.
        /// </summary>
        /// <returns>A byte array representing the packet contents.</returns>
        public byte[] GetPacketBytes()
        {
            return stream.ToArray();
        }

        /// <summary>
        /// Writes a raw byte array to the packet.
        /// </summary>
        /// <param name="bytes">The byte array to write.</param>
        public void WriteBytes(byte[] bytes)
        {
            stream.Write(bytes, 0, bytes.Length);
        }

        /// <summary>
        /// Constructs and sends a packet consisting of an opcode and a string message to a TCP client.
        /// The packet format is: [Opcode (1 byte)][Payload Length (4 bytes)][Payload (message string with length prefix)].
        /// </summary>
        /// <param name="client">The TCP client to send the packet to.</param>
        /// <param name="opCode">The opcode to send.</param>
        /// <param name="message">The string message to include in the payload.</param>
        public void SendOpCodeAndMessage(TcpClient client, byte opCode, string message)
        {
            // Create a payload builder just for the message (can include more fields)
            var payloadBuilder = new PacketBuilder();
            payloadBuilder.WriteString(message);
            byte[] payloadBytes = payloadBuilder.GetPacketBytes();

            // Create the full message
            var finalPacket = new PacketBuilder();
            finalPacket.WriteOpCode(opCode);                  // 1 byte
            finalPacket.WriteBytes(BitConverter.GetBytes(payloadBytes.Length)); // 4 bytes: payload length
            finalPacket.WriteBytes(payloadBytes);             // Payload

            client.Client.Send(finalPacket.GetPacketBytes()); // Send full message
        }
    }
}
