using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DungeonsAndCodeWizards.Factories;
using DungeonsAndCodeWizards.Models;

namespace DungeonsAndCodeWizards
{
    public class DungeonMaster
    {
        List<Character> party = new List<Character>();
        Stack<Item> pool = new Stack<Item>();

        public int lastSurvivorRounds = 0;

        

        public string JoinParty(string[] args)
        {
            string factionStr = args[0];
            string characterType = args[1];
            string name = args[2];

            bool isFactionValid = Enum.TryParse(typeof(Faction), factionStr, out object factionResult);

            if (!isFactionValid)
            {
                throw new ArgumentException(string.Format(ErrorMessages.InvalidName, factionStr));
            }

            Faction faction = (Faction)factionResult;

            Character character = null;

            switch (characterType)
            {
                case "Warrior":
                    character = new Warrior(name, faction);
                    party.Add(character);
                    return $"{character.Name} joined the party!";
                    break;
                case "Cleric":
                    character = new Cleric(name, faction);
                    party.Add(character);
                    return $"{character.Name} joined the party!";
                    break;
                default:
                    throw new ArgumentException(string.Format(ErrorMessages.InvalidCharacter, characterType));
            }


            throw new NotImplementedException();
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item = null;
            switch (itemName)
            {
                case "ArmorRepairKit":
                    item = new ArmorRepairKit();
                    pool.Push(item);
                    return $"{item.Name} added to pool.";
                case "HealthPotion":
                    item = new HealthPotion();
                    pool.Push(item);
                    return $"{item.Name} added to pool.";
                case "PoisonPotion":
                    item = new PoisonPotion();
                    pool.Push(item);
                    return $"{item.Name} added to pool.";
                default:
                    throw new ArgumentException(string.Format(ErrorMessages.InvalidItem, itemName));
            }

        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.CharacterNotExist, characterName));
            }

            if (pool.Count == 0)
            {
                throw new InvalidOperationException(ErrorMessages.EmptyPool);
            }

            character.ReceiveItem(pool.Peek());
            return $"{characterName} picked up {pool.Pop().Name}!";

            
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = party.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.CharacterNotExist, characterName));
            }

            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return $"{character.Name} used {item.Name}.";
        }

        public string UseItemOn(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = party.FirstOrDefault(c => c.Name == giverName);
            if (giver == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.InvalidCharacter, giverName));
            }

            Character receiver = party.FirstOrDefault(c => c.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.InvalidCharacter, receiverName));
            }

            Item item = giver.Bag.Items.FirstOrDefault(i => i.Name == itemName);

            if (item == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.NotSuchItem, itemName));
            }
            try
            {
                giver.UseItemOn(item, receiver);
                return $"{giver.Name} used {item.Name} on {receiver.Name}.";
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public string GiveCharacterItem(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];
            string itemName = args[2];

            Character giver = party.FirstOrDefault(c => c.Name == giverName);
            if (giver == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.InvalidCharacter, giverName));
            }

            Character receiver = party.FirstOrDefault(c => c.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.InvalidCharacter, receiverName));
            }

            Item item = giver.Bag.Items.FirstOrDefault(i => i.Name == itemName);

            if (item == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.NotSuchItem, itemName));
            }
            try
            {
                giver.GiveCharacterItem(item, receiver);
                return $"{giver.Name} gave {receiver.Name} {item.Name}.";
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public string GetStats()
        {
            StringBuilder result = new StringBuilder();

            foreach (var character in party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                result.Append(
                    $"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: ");
                if (character.IsAlive)
                {
                    result.Append("Alive");
                }
                else
                {
                    result.Append("Dead");
                }

                result.AppendLine();
            }

            return result.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];


            Character giver = party.FirstOrDefault(c => c.Name == giverName);
            if (giver == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.InvalidCharacter, giverName));
            }

            Character receiver = party.FirstOrDefault(c => c.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.InvalidCharacter, receiverName));
            }

            if (giver.GetType().Name != "Warrior")
            {
                throw new ArgumentException(string.Format(ErrorMessages.CanNotAttack, giver.Name));
            }



            Warrior attacker = (Warrior)giver;
            attacker.Attack(receiver);
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{attacker.Name} attacks {receiver.Name} for {attacker.AbilityPoints} hit points! {receiver.Name} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");

            if (!receiver.IsAlive)
            {
                result.AppendLine($"{receiver.Name} is dead!");
            }

            return result.ToString().TrimEnd();
        }

        public string Heal(string[] args)
        {
            string giverName = args[0];
            string receiverName = args[1];


            Character giver = party.FirstOrDefault(c => c.Name == giverName);
            if (giver == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.InvalidCharacter, giverName));
            }

            Character receiver = party.FirstOrDefault(c => c.Name == receiverName);
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ErrorMessages.InvalidCharacter, receiverName));
            }

            if (giver.GetType().Name != "Cleric")
            {
                throw new ArgumentException(string.Format(ErrorMessages.CanNotHeal, giver.Name));
            }



            Cleric healer = (Cleric)giver;
            healer.Heal(receiver);


            StringBuilder result = new StringBuilder();

            result.AppendLine(
                    $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");

            if (!receiver.IsAlive)
            {
                result.AppendLine($"{receiver.Name} is dead!");
            }

            return result.ToString().TrimEnd();
        }

        public string EndTurn()
        {
            StringBuilder result = new StringBuilder();
            foreach (var character in party.Where(c=>c.IsAlive==true))
            {
                double health = character.Health;
                character.Rest();
                result.AppendLine($"{character.Name} rests ({health} => {character.Health})");
            }

            int survivours = party.Count(c => c.IsAlive == true);
            if (survivours==0 || survivours == 1)
            {
                lastSurvivorRounds += 1;
                
            }

            
            return result.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            if (lastSurvivorRounds>1)
            {
                return true;
            }

            return false;
        }
    }
}
