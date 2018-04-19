public class LastArmyMain
{
    static void Main()
    {
        Engine engine = new Engine(new ConsoleReader(), new ConsoleWriter());

        engine.Run();
    }
}
