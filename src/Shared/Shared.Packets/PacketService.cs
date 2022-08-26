using MediatR;

namespace Shared.Packets;

public class PacketService
{
    private readonly IMediator Mediator;
    public PacketService(IMediator mediator)
    {
        Mediator = mediator;
    }

    public Packet ReceiveClientPacket(byte[] rawBytes, out byte[] extra)
    {
        extra = rawBytes;

        Packet packet;

        if (rawBytes.Length < 4) return null;

        int length = (rawBytes[1] << 8) + rawBytes[0];

        if (length > rawBytes.Length || length < 2) return null;

        using (var stream = new MemoryStream(rawBytes, 2, length - 2))
        using (var reader = new BinaryReader(stream))
        {
            try
            {
                short packetId = reader.ReadInt16();
                packet = Mediator.Send(new GetPacketQuery(packetId, false)).Result;
                if (packet == null) return null;
                packet.ReadPacket(reader);
            }
            catch
            {
                return null;
            }
        }
        extra = new byte[rawBytes.Length - length];
        Buffer.BlockCopy(rawBytes, length, extra, 0, rawBytes.Length - length);
        return packet;
    }
    public Packet ReceiveServerPacket(byte[] rawBytes, out byte[] extra)
    {
        extra = rawBytes;

        Packet packet;

        if (rawBytes.Length < 4) return null;

        int length = (rawBytes[1] << 8) + rawBytes[0];

        if (length > rawBytes.Length || length < 2) return null;

        using (var stream = new MemoryStream(rawBytes, 2, length - 2))
        using (var reader = new BinaryReader(stream))
        {
            try
            {
                short packetId = reader.ReadInt16();
                packet = Mediator.Send(new GetPacketQuery(packetId, true)).Result;
                if (packet == null) return null;
                packet.ReadPacket(reader);
            }
            catch
            {
                return null;
            }
        }
        extra = new byte[rawBytes.Length - length];
        Buffer.BlockCopy(rawBytes, length, extra, 0, rawBytes.Length - length);
        return packet;
    }
}