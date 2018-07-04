namespace DungeonsAndCodeWizards.Core
{
    using DungeonsAndCodeWizards.Constants;
    using DungeonsAndCodeWizards.Models.Characters;
    using DungeonsAndCodeWizards.Models.Items;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DungeonMaster
    {
        private List<Character> characters;
        private List<Item> items;
        private CharacterFactory characterFactory;
        private ItemFactory itemFactory;

        public DungeonMaster()
        {
            this.items = new List<Item>();
            this.characters = new List<Character>();
            this.characterFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            var factionName = args[0];
            var characterType = args[1];
            var name = args[2];

            var character = this.characterFactory.CreateCharacter(factionName, characterType, name);

            this.characters.Add(character);

            return string.Format(OutputMessages.JoinedParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            var itemName = args[0];
            var item = this.itemFactory.CreateItem(itemName);
            this.items.Add(item);
            return string.Format(OutputMessages.AddItem, itemName);
        }

        public string PickUpItem(string[] args)
        {
            var characterName = args[0];
            var character = FindCharacter(characterName);
            var item = this.items.LastOrDefault();

            if (item == null)
            {
                throw new InvalidOperationException(OutputMessages.NoItemsLeft);
            }

            character.ReceiveItem(item);

            return string.Format(OutputMessages.PickUpItem, characterName, item.GetType().Name);
        }

        private Character FindCharacter(string characterName)
        {
            var character = this.characters.FirstOrDefault(x => x.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(OutputMessages.CharacterNotFound, characterName));
            }

            return character;
        }

        public string UseItem(string[] args)
        {
            var characterName = args[0];
            var itemName = args[1];

            var character = FindCharacter(characterName);
            var item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return string.Format(OutputMessages.UsedItem, characterName, itemName);
        }

        public string UseItemOn(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = FindCharacter(giverName);
            var receiver = FindCharacter(receiverName);
            var item = giver.Bag.GetItem(itemName);

            giver.UseItemOn(item, receiver);

            return string.Format(OutputMessages.UsedItemOn, giverName, itemName, receiverName);
        }

        public string GiveCharacterItem(string[] args)
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giver = FindCharacter(giverName);
            var receiver = FindCharacter(receiverName);
            var item = giver.Bag.GetItem(itemName);

            giver.GiveCharacterItem(item, receiver);

            return string.Format(OutputMessages.GaveItem, giverName, receiverName, itemName);
        }

        public string GetStats()
        {
            var builder = new StringBuilder();

            var ordered = this.characters
                            .OrderByDescending(x => x.IsAlive)
                            .ThenByDescending(x => x.Health);

            foreach (var character in ordered)
            {
                builder.AppendLine(character.ToString());
            }

            return builder.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            var attackerName = args[0];
            var receiverName = args[1];

            var attacker = FindCharacter(attackerName);
            var receiver = FindCharacter(receiverName);

            attacker.ActivateAbility("Attack", receiver);

            var res = string.Format(OutputMessages.AttackCharacter, attackerName,
                 receiverName, attacker.AbilityPoints, receiverName, receiver.Health,
                 receiver.BaseHealth, receiver.Armor, receiver.BaseArmor);

            if (!receiver.IsAlive)
            {
                res += "\n" + string.Format(OutputMessages.ReceiverDead, receiverName);
            }

            return res;
        }

        public string Heal(string[] args)
        {
            var healerName = args[0];
            var receiverName = args[1];

            var healer = FindCharacter(healerName);
            var receiver = FindCharacter(receiverName);

            return string.Format(OutputMessages.HealCharacter,
                healer.Name, receiver.Name, healer.AbilityPoints, receiver.Name,
                receiver.Health);
        }

        public string EndTurn(string[] args)
        {
            throw new NotImplementedException();
        }

        public bool IsGameOver()
        {
            throw new NotImplementedException();
        }
    }
}
