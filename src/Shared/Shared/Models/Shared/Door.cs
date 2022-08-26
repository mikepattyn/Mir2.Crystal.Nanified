using Shared.Enums;
using System.Drawing;

namespace Shared.Models.Shared;

public class Door
{
    public byte index;
    public DoorState DoorState;
    public byte ImageIndex;
    public long LastTick;
    public Point Location;
}