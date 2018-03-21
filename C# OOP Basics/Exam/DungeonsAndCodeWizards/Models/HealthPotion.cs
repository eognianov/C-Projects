using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models
{
    public class HealthPotion:Item
    {
        public HealthPotion() : base(5)
        {
        }

        public override string Name => "HealthPotion";


        public override void AffectCharacter(Character character)
        {
            if (!character.IsAlive)
            {
                throw new InvalidOperationException(ErrorMessages.MustBeAlive);
            }

            character.Health += 20;
        }
    }
}
