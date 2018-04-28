using System;
using FestivalManager.Core.IO.Contracts;

namespace FestivalManager.Core.IO
{
	public class ConsoleWriter:IWriter
	{
	    public void WriteLine(string message)
	    {
	        Console.WriteLine(message);

	    }

	    public void Write(string message)
	    {
	        Console.Write(message);

	    }
    }
}