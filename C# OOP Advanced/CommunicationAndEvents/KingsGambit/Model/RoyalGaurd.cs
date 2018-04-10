using System;

public class RoyalGaurd : Subordinate
{
    public RoyalGaurd(string name) : base(name, "defending", 3)
    {
    }

    public override void ReactToAttack()
    {
        if (isAlive)
        {
            Console.WriteLine($"Royal Guard {this.Name} is {this.Action}!");
        }
    }
}

