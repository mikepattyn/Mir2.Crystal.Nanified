namespace Shared.Enums;

[Flags]
public enum RequiredClass : byte
{
    Warrior = 1,
    Wizard = 2,
    Taoist = 4,
    Assassin = 8,
    Archer = 16,
    WarWizTao = Warrior | Wizard | Taoist,
    None = WarWizTao | Assassin | Archer
}