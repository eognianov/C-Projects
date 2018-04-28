using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FestivalManager.Core.IO;
using FestivalManager.Entities;
using FestivalManager.Entities.Contracts;

namespace FestivalManager.Core
{
	using System.Reflection;
	using Contracts;
	using Controllers;
	using Controllers.Contracts;
	using IO.Contracts;

	public class Engine : IEngine
	{
	    private IReader reader = new ConsoleReader();
	    private IWriter writter = new ConsoleWriter();
	    private IFestivalController festivalController;
	    private ISetController setController;

        //IStage stage = new Stage();

	    public Engine(IFestivalController festivalController, ISetController setController)
	    {
	        this.festivalController = festivalController;
	        this.setController = setController;
	    }

		
		//public void Запали()
		//{
		//	while (Convert.ToBoolean(0x1B206 ^ 0b11011001000000111)) 
		//	{
		//		var input = chetach.ReadLine();

		//		if (input == "END")
		//			break;

		//		try
		//		{
		//			string.Intern(input);

		//			var result = this.DoCommand(input);
		//			this.pisach.WriteLine(result);
		//		}
		//		catch (Exception ex) 
		//		{
		//			this.pisach.WriteLine("ERROR: " + ex.Message);
		//		}
		//	}

		//	var end = this.festivalController.Report();

		//	this.pisach.WriteLine("Results:");
		//	this.pisach.WriteLine(end);
		//}

		//public string DoCommand(string input)
		//{
		//	var chasti = input.Split(" ".ToCharArray().First());

		//	var purvoto = chasti.First();
		//	var parametri = chasti.Skip(1).ToArray();

		//	if (purvoto == "LetsRock")
		//	{
		//		var setovete = this.setController.PerformSets();
		//		return setovete;
		//	}

		//	var festivalcontrolfunction = this.festivalController.GetType()
		//		.GetMethods()
		//		.FirstOrDefault(x => x.Name == purvoto);

		//	string a;

		//	try
		//	{
		//		a = (string)festivalcontrolfunction.Invoke(this.festivalController, new object[] { parametri });
		//	}
		//	catch (TargetInvocationException up)
		//	{
		//		throw up; // ha ha
		//	}

		//	return a;
		//}

	    public void Run()
	    {
	        while (true)
            {
                var input = reader.ReadLine();

                if (input == "END")
                    break;

                try
                {
                    var result = this.ProcessCommand(input);
                    this.writter.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writter.WriteLine("ERROR: " + ex.Message);
                }
            }

            var end = this.festivalController.ProduceReport();

            this.writter.WriteLine("Results:");
            this.writter.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            string commandName = input.Split().First();
            string[] commandArgs = null;
            try
            {
                switch (commandName)
                {
                    
                    case "RegisterSet":
                        commandArgs = input.Split().Skip(1).ToArray();
                        return this.festivalController.RegisterSet(commandArgs);
                    case "SignUpPerformer":
                        commandArgs = input.Split().Skip(1).ToArray();
                        return this.festivalController.SignUpPerformer(commandArgs);
                    case "RegisterSong":
                        commandArgs = input.Split().Skip(1).ToArray();
                        return this.festivalController.RegisterSong(commandArgs);
                    case "AddSongToSet":
                        commandArgs = input.Split().Skip(1).ToArray();
                        return this.festivalController.AddSongToSet(commandArgs);
                    case "AddPerformerToSet":
                        commandArgs = input.Split().Skip(1).ToArray();
                        return this.festivalController.AddPerformerToSet(commandArgs);
                    case "RepairInstruments":
                        return this.festivalController.RepairInstruments(null);
                    case "LetsRock":
                        return this.setController.PerformSets();

                    default:
                        throw new ArgumentException("Invalid command");
                }
            }
            catch (Exception e)
            {
              throw new Exception(e.Message);
            }
        }
	}
}