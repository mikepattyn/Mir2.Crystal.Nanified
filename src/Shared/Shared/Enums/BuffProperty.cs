namespace Shared.Enums;

[Flags]
public enum BuffProperty : byte
{
    None = 0,
    RemoveOnDeath = 1,
    RemoveOnExit = 2,
    Debuff = 4,
    PauseInSafeZone = 8
}