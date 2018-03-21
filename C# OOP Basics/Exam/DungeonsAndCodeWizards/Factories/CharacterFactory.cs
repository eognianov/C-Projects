using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models;

namespace DungeonsAndCodeWizards.Factories
{
    public class CharacterFactory
    {

        public Character CreateCharacter(string[] charArgs)
        {
            string factionStr = charArgs[0];
            string type = charArgs[1];
            string name = charArgs[2];

            bool isFactionValid = Enum.TryParse(typeof(Faction), factionStr, out object factionResult);

            if (!isFactionValid)
            {
                throw new ArgumentException(string.Format(ErrorMessages.InvalidFactiont, factionStr));
            }

            Faction faction = (Faction)factionResult;

            Character character = null;

            

            if (type == "Warrior")
            {
                character =  new Warrior(name, faction);
                return character;
            }
            else if (type == "Cleric")
            {
                character =  new Cleric(name, faction);
                return character;
            }
            
            throw new ArgumentException(string.Format(ErrorMessages.InvalidCharacter, type));
            
        }
    }
}
