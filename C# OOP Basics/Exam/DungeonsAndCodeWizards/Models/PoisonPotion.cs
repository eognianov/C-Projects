using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models
{
    public class PoisonPotion:Item
    {
        public PoisonPotion() : base(5)
        {
        }

        public override string Name => "PoisonPotion";


        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.MustBeAlive);
            }

            character.Health -= 20;

            if (character.Health<0)
            {
                character.IsAlive = false;
            }
        }
    }
}
