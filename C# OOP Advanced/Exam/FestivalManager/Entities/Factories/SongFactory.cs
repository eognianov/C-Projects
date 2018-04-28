using System.Linq;
using System.Reflection;

namespace FestivalManager.Entities.Factories
{
	using System;
	using Contracts;
	using Entities.Contracts;

	public class SongFactory : ISongFactory
	{
		public ISong CreateSong(string name, TimeSpan duration)
		{

		    Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == "Song");

            TimeSpan songDuration = new TimeSpan(0, duration.Minutes, duration.Seconds);


            
		    ISong song = (ISong)Activator.CreateInstance(type, name, songDuration);

		    return song;
            
		}
	}
}