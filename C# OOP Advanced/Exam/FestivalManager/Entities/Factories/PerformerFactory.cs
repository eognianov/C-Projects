using System;
using System.Linq;
using System.Reflection;

namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;

	public class PerformerFactory : IPerformerFactory
	{
		public IPerformer CreatePerformer(string name, int age)
		{
		    Type type = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(t => t.Name == "Performer");


		    IPerformer performer = (IPerformer)Activator.CreateInstance(type, name, age);

			return performer;
		}
	}
}