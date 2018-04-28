using System.Linq;

namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;

	public class Stage:IStage
    {
	    private List<ISet> sets;
	    private List<ISong> songs;
	    private List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => (IReadOnlyCollection<ISet>) this.sets;
        public IReadOnlyCollection<ISong> Songs => (IReadOnlyCollection<ISong>) this.songs;
        public IReadOnlyCollection<IPerformer> Performers => (IReadOnlyCollection<IPerformer>) this.performers;
 

	    public IPerformer GetPerformer(string name)
	    {
	        IPerformer performer = this.performers.FirstOrDefault(p => p.Name == name);
	        return performer;
	    }

	    public ISong GetSong(string name)
	    {
	        ISong song = this.songs.FirstOrDefault(s => s.Name == name);
	        return song;
	    }

	    public ISet GetSet(string name)
	    {
	        ISet set = this.sets.FirstOrDefault(s => s.Name == name);
	        return set;
	    }

	    public void AddPerformer(IPerformer performer)
	    {
	        this.performers.Add(performer);
	    }

	    public void AddSong(ISong song)
	    {
	        this.songs.Add(song);
	    }

	    public void AddSet(ISet set)
	    {
	        this.sets.Add(set);
	    }

	    public bool HasPerformer(string name)
	    {
	        return this.performers.Any(p => p.Name == name);
	    }

	    public bool HasSong(string name)
	    {
	        return this.songs.Any(s => s.Name == name);
        }

	    public bool HasSet(string name)
	    {
	        return this.sets.Any(s => s.Name == name);
        }
	}
}
