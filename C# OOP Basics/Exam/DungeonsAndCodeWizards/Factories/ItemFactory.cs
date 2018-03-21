using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DungeonsAndCodeWizards.Models;

namespace DungeonsAndCodeWizards.Factories
{
    public class ItemFactory
    {
        public Item CreateItem(string type)
        {
            Item item = null;

            if (type=="ArmorRepairKit")
            {
                item =  new ArmorRepairKit();
                return item;
            }

            else if (type=="HealthPotions")
            {
                item =  new HealthPotion();
                return item;
            }

            else if (type == "PosionPotion")
            {
                item =  new PoisonPotion();
                return item;
            }

            
                throw new ArgumentException(string.Format(ErrorMessages.InvalidItem, type));
            
        }
    }
}
