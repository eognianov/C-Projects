public abstract class Ammunition:IAmmunition
{
    private const int WearLevelMultiplier = 100;

    public string Name => this.GetType().Name;

    public abstract double Weight { get; }

    public double WearLevel { get; private set; }

    protected Ammunition()
    {
        WearLevel = Weight * WearLevelMultiplier;
    }

    public void DecreaseWearLevel(double wearAmount)
    {
        WearLevel -= wearAmount;
    }
}