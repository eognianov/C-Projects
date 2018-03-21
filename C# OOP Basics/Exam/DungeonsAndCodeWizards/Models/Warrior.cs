using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models
{
    public class Warrior : Character, IAttackable
    {
        public Warrior(string name, Faction faction) : base(name, 40, new Satchel(), faction)
        {
            this.BaseHealth = 100;
            this.BaseArmor = 50;

            this.Health = 100;
            this.Armor = 50;

            this.Name = name;

        }

        public void Attack(Character character)
        {
            if (!this.IsAlive && !character.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.MustBeAlive);
            }

            if (this==character)
            {
                throw new InvalidOperationException(ErrorMessages.SelfAttack);
            }

            if (this.Faction==character.Faction)
            {
                throw new ArgumentException(ErrorMessages.FreindlyFire);
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
