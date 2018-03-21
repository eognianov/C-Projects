using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DungeonsAndCodeWizards
{
	public class StartUp
	{
		// DO NOT rename this file's namespace or class name.
		// However, you ARE allowed to use your own namespaces (or no namespaces at all if you prefer) in other classes.
		public static void Main(string[] args)
		{
			DungeonMaster dungeonMaster = new DungeonMaster();

		    string commnad = Console.ReadLine();

		    while (true)
		    {
		        if (string.IsNullOrWhiteSpace(commnad))
		        {
		            break;
		        }

		        if (dungeonMaster.IsGameOver())
		        {
		            break;
		        }
		        string[] comandArgs = commnad.Split().ToArray();

		        string commandName = comandArgs[0];

		        switch (commandName)
		        {
                    case "JoinParty":

                        try
                        {
                            Console.WriteLine(dungeonMaster.JoinParty(comandArgs.Skip(1).ToArray()));

                        }
                        catch (ArgumentException argumentException)
                        {

                            Console.WriteLine(string.Format(ErrorMessages.ParametarError, argumentException.Message));
                        }
                        catch (InvalidOperationException invOpEx)
                        {
                            Console.WriteLine(string.Format(ErrorMessages.OperationError, invOpEx.Message));
                        }
                        break;
                    case "AddItemToPool":
                        try
                        {
                            Console.WriteLine(dungeonMaster.AddItemToPool(comandArgs.Skip(1).ToArray()));

                        }
                        catch (ArgumentException argumentException)
                        {

                            Console.WriteLine(string.Format(ErrorMessages.ParametarError, argumentException.Message));
                        }
                        catch (InvalidOperationException invOpEx)
                        {
                            Console.WriteLine(string.Format(ErrorMessages.OperationError, invOpEx.Message));
                        }
                        break;

                    case "PickUpItem":
                        try
                        {
                            Console.WriteLine(dungeonMaster.PickUpItem(comandArgs.Skip(1).ToArray()));

                        }
                        catch (ArgumentException argumentException)
                        {

                            Console.WriteLine(string.Format(ErrorMessages.ParametarError, argumentException.Message));
                        }
                        catch (InvalidOperationException invOpEx)
                        {
                            Console.WriteLine(string.Format(ErrorMessages.OperationError, invOpEx.Message));
                        }
                        break;
                    case "UseItem":
                        try
                        {
                            Console.WriteLine(dungeonMaster.UseItem(comandArgs.Skip(1).ToArray()));
                        }
                        
                        catch (ArgumentException argumentException)
                        {

                            Console.WriteLine(string.Format(ErrorMessages.ParametarError, argumentException.Message));
                        }
                        catch (InvalidOperationException invOpEx)
                        {
                            Console.WriteLine(string.Format(ErrorMessages.OperationError, invOpEx.Message));
                        }
                        break;
                    case "UseItemOn":
                        try
                        {
                            Console.WriteLine(dungeonMaster.UseItemOn(comandArgs.Skip(1).ToArray()));
                        }
                        catch (ArgumentException argumentException)
                        {

                            Console.WriteLine(string.Format(ErrorMessages.ParametarError, argumentException.Message));
                        }
                        catch (InvalidOperationException invOpEx)
                        {
                            Console.WriteLine(string.Format(ErrorMessages.OperationError, invOpEx.Message));
                        }
                        break;
                    case "GiveCharacterItem":
                        try
                        {
                            Console.WriteLine(dungeonMaster.GiveCharacterItem(comandArgs.Skip(1).ToArray()));
                        }
                        catch (ArgumentException argumentException)
                        {

                            Console.WriteLine(string.Format(ErrorMessages.ParametarError, argumentException.Message));
                        }
                        catch (InvalidOperationException invOpEx)
                        {
                            Console.WriteLine(string.Format(ErrorMessages.OperationError, invOpEx.Message));
                        }
                        break;
                    case "GetStats":
                        try
                        {
                            Console.WriteLine(dungeonMaster.GetStats());
                        }
                        catch (ArgumentException argumentException)
                        {

                            Console.WriteLine(string.Format(ErrorMessages.ParametarError, argumentException.Message));
                        }
                        catch (InvalidOperationException invOpEx)
                        {
                            Console.WriteLine(string.Format(ErrorMessages.OperationError, invOpEx.Message));
                        }
                        break;
                    case "Attack":
                        try
                        {
                            Console.WriteLine(dungeonMaster.Attack(comandArgs.Skip(1).ToArray()));
                        }
                        catch (ArgumentException argumentException)
                        {

                            Console.WriteLine(string.Format(ErrorMessages.ParametarError, argumentException.Message));
                        }
                        catch (InvalidOperationException invOpEx)
                        {
                            Console.WriteLine(string.Format(ErrorMessages.OperationError, invOpEx.Message));
                        }
                        break;
                    case "Heal":
                        try
                        {
                            Console.WriteLine(dungeonMaster.Heal(comandArgs.Skip(1).ToArray()));
                        }
                        catch (ArgumentException argumentException)
                        {

                            Console.WriteLine(string.Format(ErrorMessages.ParametarError, argumentException.Message));
                        }
                        catch (InvalidOperationException invOpEx)
                        {
                            Console.WriteLine(string.Format(ErrorMessages.OperationError, invOpEx.Message));
                        }
                        break;
                    case "EndTurn":
                        try
                        {
                            Console.WriteLine(dungeonMaster.EndTurn());
                            dungeonMaster.IsGameOver();
                        }
                        catch (ArgumentException argumentException)
                        {

                            Console.WriteLine(string.Format(ErrorMessages.ParametarError, argumentException.Message));
                        }
                        catch (InvalidOperationException invOpEx)
                        {
                            Console.WriteLine(string.Format(ErrorMessages.OperationError, invOpEx.Message));
                        }

                        break;
                    
                }
                commnad = Console.ReadLine();
		    }

            Console.WriteLine("Final stats:");
		        Console.WriteLine(dungeonMaster.GetStats());
		}
	}
}