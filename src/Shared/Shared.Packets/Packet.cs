namespace Shared.Packets
{
    public abstract class Packet
    {
        public static bool IsServer;
        public virtual bool Observable => true;
        public abstract short Index { get; }

        public abstract void ReadPacket(BinaryReader reader);
        public abstract void WritePacket(BinaryWriter writer);
        public IEnumerable<byte> GetPacketBytes()
        {
            if (Index < 0) return Enumerable.Empty<byte>();
            byte[] data;
            using (var stream = new MemoryStream())
            {
                stream.SetLength(2);
                stream.Seek(2, SeekOrigin.Begin);
                using (var writer = new BinaryWriter(stream))
                {
                    writer.Write(Index);
                    WritePacket(writer);
                    stream.Seek(0, SeekOrigin.Begin);
                    writer.Write((short)stream.Length);
                    stream.Seek(0, SeekOrigin.Begin);

                    data = new byte[stream.Length]; 
                    stream.Read(data, 0, data.Length);
                }
            }
            return data;
        }
    }

}
