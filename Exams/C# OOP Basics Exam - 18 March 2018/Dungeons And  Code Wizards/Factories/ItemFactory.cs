using DungeonsAndCodeWizards.Constants;
using DungeonsAndCodeWizards.Models.Items;
using System;

public class ItemFactory
{
    public Item CreateItem(string name)
    {
        switch (name)
        {
            case "HealthPotion":
                return new HealthPotion();
            case "PoisonPotion":
                return new PoisonPotion();
            case "ArmorRepairKit":
                return new ArmorRepairKit();
            default:
                break;
        }

        throw new ArgumentException(string.Format(OutputMessages.InvalidItem, name));
    }
}