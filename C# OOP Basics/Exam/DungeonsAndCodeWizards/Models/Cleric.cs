using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models
{
    public class Cleric:Character,IHealable
    {
        public Cleric(string name, Faction faction) : base(name,40, new Backpack(), faction)
        {
            this.Health = 50;
            this.Armor = 25;

            this.BaseHealth = 50;
            this.BaseArmor = 25;
        }

        

        public override double RestHealMultiplier => 0.5;

        public void Heal(Character character)
        {
            if (!this.IsAlive && !character.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.MustBeAlive);
            }

            if (this.Faction != character.Faction)
            {
                throw new InvalidOperationException(ErrorMessages.HealError);
            }

            character.Health += this.AbilityPoints;
            if (character.Health>character.BaseHealth)
            {
                character.Health = character.BaseHealth;
            }
        }

        
    }
}
