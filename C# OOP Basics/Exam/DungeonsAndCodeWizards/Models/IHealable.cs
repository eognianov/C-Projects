using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards.Models
{
    public interface IHealable
    {

        void Heal(Character character);
    }
}
