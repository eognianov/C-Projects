
using System;

class StartUp
{
    static void Main()
    {
        var studentSystem = new StudentSystem();
        string commnad;
        while ((commnad= Console.ReadLine())!="Exit")
        {
            studentSystem.ParseCommand(commnad);
        }
    }
}

