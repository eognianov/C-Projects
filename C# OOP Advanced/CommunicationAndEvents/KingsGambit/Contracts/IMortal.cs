public interface IMortal
{
    bool isAlive { get; }

    int HitPoints { get; }

    void TakeDamege();

    void Die();
}

