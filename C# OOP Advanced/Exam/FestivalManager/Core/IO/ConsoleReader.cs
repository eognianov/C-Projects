﻿using System;
using System.IO;
using FestivalManager.Core.IO.Contracts;

namespace FestivalManager.Core.IO
{
	using System.IO;

	public class ConsoleReader:IReader
    { 
		public string ReadLine()
		{
		    return Console.ReadLine();
		}
	}
}