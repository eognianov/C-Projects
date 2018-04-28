using System.Collections;
using System.Collections.Generic;
using FestivalManager.Entities.Factories;
using FestivalManager.Entities.Factories.Contracts;

namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";
        private const string TimeFormatLong = "{0:2D}:{1:2D}";
        private const string TimeFormatThreeDimensional = "{0:3D}:{1:3D}";


        private ISetFactory setFactory = new SetFactory();
        private IPerformerFactory performerFactory = new PerformerFactory();
        private IInstrumentFactory instumentFactory = new InstrumentFactory();
        private ISongFactory songFactory = new SongFactory();

        private readonly IStage stage;

        public FestivalController(IStage stage)
        {
            this.stage = stage;
        }

        public string ProduceReport()
        {
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            result += ($"Festival length: {totalFestivalLength.Minutes:D2}:{totalFestivalLength.Seconds:D2}") + "\n";

            foreach (var set in this.stage.Sets)
            {
                result += ($"--{set.Name} ({set.ActualDuration.Minutes:D2}:{set.ActualDuration.Seconds:D2}):") + "\n";

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                    result += ("--No songs played") + "\n";
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
                    }
                }
            }

            return result.ToString().TrimEnd();
        }

        public string RegisterSet(string[] args)
        {
            string name = args[0];
            string type = args[1];

            ISet set = setFactory.CreateSet(name, type);
            this.stage.AddSet(set);

            return $"Registered {type} set";
        }

        public string SignUpPerformer(string[] args)
        {
            string name = args[0];
            int age = int.Parse(args[1]);

            IPerformer performer = performerFactory.CreatePerformer(name, age);

            IList<IInstrument> performerInstumets = new List<IInstrument>();

            if (args.Length>2)
            {
                foreach (var typeInstrument in args.Skip(2).ToList())
                {
                    IInstrument instrument = instumentFactory.CreateInstrument(typeInstrument);
                    performer.AddInstrument(instrument);
                }
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";

        }

        public string RegisterSong(string[] args)
        {
            string name = args[0];
            int[] timeSpanArgs = args[1].Split(':').Select(int.Parse).ToArray();



            TimeSpan songDuration = new TimeSpan(0, timeSpanArgs[0], timeSpanArgs[1]);

            ISong song = songFactory.CreateSong(name, songDuration);

            this.stage.AddSong(song);

            return $"Registered song {name} ({songDuration:mm\\:ss})";

        }

        public string AddSongToSet(string[] args)
        {
            string songName = args[0];
            string setName = args[1];

            ISet set = this.stage.Sets.FirstOrDefault(s => s.Name == setName);
            if (set==null)
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            ISong song = this.stage.Songs.FirstOrDefault(t => t.Name == songName);

            if (song==null)
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            set.AddSong(song);

            return $"Added {songName} ({song.Duration:mm\\:ss}) to {setName}";
        }

        public string AddPerformerToSet(string[] args)
        {
            string performerName = args[0];
            string setName = args[1];

            IPerformer performer = this.stage.Performers.FirstOrDefault(p => p.Name == performerName);

            if (performer==null)
            {
                throw new InvalidOperationException("Invalid performer provided");
            }

            ISet set = this.stage.Sets.FirstOrDefault(s => s.Name == setName);

            if (set==null)
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            set.AddPerformer(performer);

            return $"Added {performerName} to {setName}";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                        .SelectMany(p => p.Instruments)
                        .Where(i => i.Wear <= 100 || i.IsBroken)
                        .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }
    }
    //	private readonly IStage stage;

	//	public FestivalController(IStage stage)
	//	{
	//		this.stage = stage;
	//	}

	//	public string Report()
	//	{
	//		var result = string.Empty;

	//		var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

	//		result += ($"Festival length: {FormatTime(totalFestivalLength)}") + "\n";

	//		foreach (var set in this.stage.Sets)
	//		{
	//			result += ($"--{set.Name} ({FormatTime(set.ActualDuration)}):") + "\n";

	//			var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
	//			foreach (var performer in performersOrderedDescendingByAge)
	//			{
	//				var instruments = string.Join(", ", performer.Instruments
	//					.OrderByDescending(i => i.Wear));

	//				result += ($"---{performer.Name} ({instruments})") + "\n";
	//			}

	//			if (!set.Songs.Any())
	//				result += ("--No songs played") + "\n";
	//			else
	//			{
	//				result += ("--Songs played:") + "\n";
	//				foreach (var song in set.Songs)
	//				{
	//					result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
	//				}
	//			}
	//		}

	//		return result.ToString();
	//	}

	//	public string RegisterSet(string[] args)
	//	{
	//		throw new NotImplementedException(); // оф...
	//	}

	//	public string SignUpPerformer(string[] args)
	//	{
	//		var name = args[0];
	//		var age = int.Prase(args[1]);

	//		var instrumenti = args.Skip(2).ToArray();

	//		var instrumenti2 = instrumenti
	//			.Select(i => this.instrumentFactory.CreateInstrument(i))
	//			.ToArray();

	//		var performer = this.performerFactory.CreatePerformer(name, age);

	//		foreach (var instrument in instrumenti2)
	//		{
	//			performer.AddInstrument(instrument);
	//		}

	//		this.stage.AddPerformer(performer);

	//		return $"Registered performer {performer.Name}";
	//	}

	//	public string RegisterSong(string[] args)
	//	{
	//		// TODO: scheduled for next month

	//		return $"Registered song {song}";
	//	}

	//	public string SongRegistration(string[] args)
	//	{
	//		var songName = args[0];
	//		var setName = args[1];

	//		if (!this.stage.HasSet(setName))
	//		{
	//			throw new InvalidOperationException("Invalid set provided");
	//		}

	//		if (!this.stage.HasSong(songName))
	//		{
	//			throw new InvalidOperationException("Invalid song provided");
	//		}

	//		var set = this.stage.GetSet(setName);
	//		var song = this.stage.GetSong(songName);

	//		set.AddSong(song);

	//		return $"Added {song} to {set.Name}";
	//	}

	//	public string AddPerformerToSet(string[] args)
	//	{
	//		return PerformerRegistration(args);
	//	}

	//	public string PerformerRegistration(string[] args)
	//	{
	//		var performerName = args[0];
	//		var setName = args[1];

	//		if (!this.stage.HasPerformer(performerName))
	//		{
	//			throw new InvalidOperationException("Invalid performer provided");
	//		}

	//		if (!this.stage.HasSet(setName))
	//		{
	//			throw new InvalidOperationException("Invalid set provided");
	//		}

	//		AddPerformerToSet(args);

	//		var performer = this.stage.GetPerformer(performerName);
	//		var set = this.stage.GetSet(setName);

	//		set.AddPerformer(performer);

	//		return $"Added {performer.Name} to {set.Name}";
	//	}

	//	public string RepairInstruments(string[] args)
	//	{
	//		var instrumentsToRepair = this.stage.Performers
	//			.SelectMany(p => p.Instruments)
	//			.Where(i => i.Wear <= 100)
	//			.ToArray();

	//		foreach (var instrument in instrumentsToRepair)
	//		{
	//			instrument.Repair();
	//		}

	//		return $"Repaired {instrumentsToRepair.Length} instruments";
	//	}
	//}
}