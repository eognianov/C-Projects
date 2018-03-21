using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models
{
    public abstract class Character
    {
        private string name;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.InvalidName);
                }
                this.name = value;
            }
        }

        public double BaseHealth { get;protected set; }

        public double Health { get; set; }

        public double BaseArmor { get;protected set; }

        public double Armor { get; set; }

        public double AbilityPoints { get; private set; }

        public Bag Bag { get;private set; }

        public Faction Faction { get;private set; }

        public bool IsAlive { get; set; }

        public virtual double RestHealMultiplier => 0.2;

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag, Faction faction)
        {
            
            this.Health = health;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.IsAlive = true;
            this.Bag = bag;
            this.Faction = faction;
        }

        protected Character(string name, double abilityPoints, Bag bag, Faction faction)
        {
            this.Name = name;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
            this.Faction = faction;
            this.IsAlive = true;
        }


        public void TakeDamage(double hitPoints)
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.MustBeAlive);
            }

            double hitPointsRemainig = hitPoints - this.Armor;
            this.Armor = Math.Max(0, this.Armor - hitPoints);

            if (hitPointsRemainig>0)
            {
                this.Health -= hitPointsRemainig;
            }

            if (this.Health<0)
            {
                this.Health = 0;
                this.IsAlive = false;
            }
        }

        public void Rest()
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.MustBeAlive);
            }



            this.Health += (this.BaseHealth * this.RestHealMultiplier);
            if (this.Health>this.BaseHealth)
            {
                this.Health = this.BaseHealth;
            }
        }

        public void UseItem(Item item)
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.MustBeAlive);
            }

            Item itemToUse = this.Bag.GetItem(item.Name);
            itemToUse.AffectCharacter(this);

        }

        public void UseItemOn(Item item, Character character)
        {
            if (!this.IsAlive && !character.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.MustBeAlive);
            }

            character.UseItem(Bag.GetItem(item.Name));
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (!this.IsAlive && !character.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.MustBeAlive);
            }

            character.Bag.AddItem(this.Bag.GetItem(item.Name));
        }

        public void ReceiveItem(Item item)
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.MustBeAlive);
            }
            this.Bag.AddItem(item);
        }

    }
}
