public delegate void SubordinateDeathEventHandler(object sender);

public interface ISubordinate:INameable, IMortal
{
    event SubordinateDeathEventHandler deathEvent;
    string Action { get; }
    void ReactToAttack();
}