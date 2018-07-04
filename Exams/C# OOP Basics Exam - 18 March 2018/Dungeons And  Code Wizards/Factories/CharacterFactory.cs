using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Enums;
using DungeonsAndCodeWizards.Models.Characters;
using System;

public class CharacterFactory
{
    public Character CreateCharacter(string factionName, string className, string name)
    {
        Faction faction = Faction.CSharp;

        if (!Enum.TryParse(factionName, out faction))
        {
            throw new ArgumentException(string.Format(OutputMessages.InvalidFaction, factionName));
        }

        switch (className)
        {
            case "Warrior":
                return new Warrior(name, faction);
            case "Cleric":
                return new Cleric(name, faction);
            default:
                break;
        }

        throw new ArgumentException(string.Format(OutputMessages.InvalidCharacter, className));
    }

}