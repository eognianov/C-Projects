using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndCodeWizards
{
    public static class ErrorMessages
    {
        public static string MustBeAlive = "Must be alive to perform this action!";

        public static string BagIsFull = "Bag is full!";

        public static string BasIsEmpty = "Bag is empty!";

        public static string NotSuchItem = "No item with name {0} in bag!";

        public static string InvalidName = "Name cannot be null or whitespace!";

        public static string SelfAttack = "Cannot attack self!";

        public static string FreindlyFire = "Friendly fire! Both characters are from {faction} faction!";

        public static string HealError = "Cannot heal enemy character!";

        public static string InvalidFactiont = "Invalid faction \"{0}\"!";

        public static string InvalidCharacter = "Invalid character type \"{0}\"!";

        public static string InvalidItem = "Invalid item type \"{0}\"!";

        public static string CharacterNotExist = "Character {0} not found!";

        public static string EmptyPool = "No items left in pool!";

        public static string CanNotAttack = "{0} cannot attack!";

        public static string CanNotHeal = "{0} cannot heal!";

        public static string ParametarError = "Parameter Error: {0}";

        public static string OperationError = "Invalid Operation: {0}";

        public static string PoolIsEmpty = "No items left in pool!";
    }
}
