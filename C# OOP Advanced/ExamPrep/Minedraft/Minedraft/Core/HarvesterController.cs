using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class HarvesterController : IHarvesterController
{
    private string mode;
    private IEnergyRepository energyRepository;
    private IList<IHarvester> harvesters;
    private IHarvesterFactory harvesterFactory;

    public HarvesterController(IEnergyRepository energyRepository, IHarvesterFactory harvesterFactory)
    {
        this.mode = Constants.DefaultMode;
        this.energyRepository = energyRepository;
        this.harvesters = new List<IHarvester>();
        this.harvesterFactory = harvesterFactory;

    }
    public string Register(IList<string> args)
    {
        IHarvester harvester = this.harvesterFactory.GenerateHarvester(args);
        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration, harvester.GetType().Name);
    }

    public string Produce()
    {
        double neededEnergy = 0;
        foreach (var harvester in this.harvesters)
        {
            if (this.mode == "Full")
            {
                neededEnergy += harvester.EnergyRequirement;
            }
            else if (this.mode == "Half")
            {
                neededEnergy += harvester.EnergyRequirement * 50 / 100;
            }
            else if (this.mode == "Energy")
            {
                neededEnergy += harvester.EnergyRequirement * 20 / 100;
            }
        }

        //check if we can mine
        double minedOres = 0;
        if (this.energyRepository.TakeEnergy(neededEnergy))
        {
            foreach (var harvester in this.harvesters)
            {
                minedOres += harvester.Produce();
            }
        }

        //take the mode in mind
        if (this.mode == "Energy")
        {
            minedOres = minedOres * 20 / 100;
        }
        else if (this.mode == "Half")
        {
            minedOres = minedOres * 50 / 100;
        }

        this.OreProduced += minedOres;

        
        return string.Format(Constants.OreOutputToday, minedOres);
    }

    public IReadOnlyCollection<IEntity> Entities => (IReadOnlyCollection<IHarvester>)this.harvesters;

    public double OreProduced { get; private set; }

    public string ChangeMode(string mode)
    {
        
        this.mode = mode;

        List<IHarvester> reminder = new List<IHarvester>();

        foreach (var harvester in harvesters)
        {
            try
            {
                harvester.Broke();
            }
            catch (Exception ex)
            {
                reminder.Add(harvester);
            }
        }

        foreach (var harvester in reminder)
        {
            this.harvesters.Remove(harvester);
        }

        return string.Format(Constants.ModeChange, mode);
    }
}

