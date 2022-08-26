namespace Shared.Models.Items;

public class SealedInfo
{
    public DateTime ExpiryDate;
    public DateTime NextSealDate;

    public SealedInfo() { }

    public SealedInfo(BinaryReader reader, int version = int.MaxValue, int Customversion = int.MaxValue)
    {
        ExpiryDate = DateTime.FromBinary(reader.ReadInt64());

        if (version > 92)
        {
            NextSealDate = DateTime.FromBinary(reader.ReadInt64());
        }
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(ExpiryDate.ToBinary());
        writer.Write(NextSealDate.ToBinary());
    }
}