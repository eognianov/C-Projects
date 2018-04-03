using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    [SoftUniAttribute("Ventsi")]
    public class StartUp
    {
        
        
        [SoftUniAttribute("Gosho")]
        public static void Main(string[] args)
        {
            Spy spy = new Spy();
            //Task1(spy);

            //Task2(spy);


            //Task3(spy);


            //Task4(spy);

            
            Tracker.PrintMethodsByAuthor();
        }

        

        private static void Task4(Spy spy)
        {
            var result = spy.CollectGettersAndSetters("Hacker");
            Console.WriteLine(result);
        }

        private static void Task3(Spy spy)
        {
            var result = spy.RevealPrivateMethods("Hacker");
            Console.WriteLine(result);
        }

        private static void Task2(Spy spy)
        {
            var result = spy.AnalyzeAcessModifiers("Hacker");
            Console.WriteLine(result);
        }

        private static void Task1(Spy spy)
        {
            var result = spy.StealFieldInfo("Hacker", "username", "password");
            System.Console.WriteLine(result);
        }
    }
}
