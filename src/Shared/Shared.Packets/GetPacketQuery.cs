using MediatR;
using Shared.Packets.Client;
using Shared.Packets.Server;

namespace Shared.Packets;
public record GetPacketQuery(short PacketId, bool IsServer) : IRequest<Packet>;
public record GetPacketQueryHandler(IEnumerable<Packet> Packets) : IRequestHandler<GetPacketQuery, Packet>
{
    public Task<Packet> Handle(GetPacketQuery request, CancellationToken cancellationToken)
    {
        var packetType = request.IsServer ? typeof(ServerPacket) : typeof(ClientPacket);
        return Task.FromResult(Packets.Single(x => x.GetType() == packetType && x.Index == request.PacketId));
    }
}
