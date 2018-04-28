namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;
	using Instruments;

	public class Performer:IPerformer
	{
		private IList<IInstrument> instruments;

		public Performer(string name, int age)
		{
			this.Name = name;
			this.Age = age;

			this.instruments = new List<IInstrument>();
		}

		public string Name { get; }

		public int Age { get; }

		public IReadOnlyCollection<IInstrument> Instruments => (IReadOnlyCollection<IInstrument>)this.instruments;

		public void AddInstrument(IInstrument instrument)
		{
			this.instruments.Add(instrument);
		}

		public override string ToString()
		{
			return this.Name;
		}
	}
}
