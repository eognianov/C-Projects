using System;

public abstract class Subordinate:ISubordinate
{
    protected Subordinate(string name, string action, int hitPoints)
    {
        this.Name = name;
        this.Action = action;
        this.HitPoints = hitPoints;

        this.isAlive = true;
    }
    public string Name { get; }

    public bool isAlive { get; private set; }

    public int HitPoints { get; private set; }

    public event SubordinateDeathEventHandler deathEvent;

    public void TakeDamege()
    {
        this.HitPoints--;
        if (this.HitPoints <= 0)
        {
            this.Die();
        }
    }

    public void Die()
    {
        this.isAlive = false;
        if (this.deathEvent != null)
        {
            this.deathEvent.Invoke(this);
        }
    }

    public string Action { get; }

    public virtual void ReactToAttack()
    {
        if (this.isAlive)
        {
            Console.WriteLine($"{this.GetType().Name} {this.Name} is {this.Action}");
        }
    }
}

