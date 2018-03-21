using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models
{
    public abstract class Item
    {
        public int Weight { get; private set; }

        public virtual string Name { get; }

        protected Item(int weight)
        {
            this.Weight = weight;
        }

        public abstract void AffectCharacter(Character character);
    }
}
