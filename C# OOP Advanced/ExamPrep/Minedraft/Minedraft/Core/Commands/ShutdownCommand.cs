using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    private IHarvesterController harvesterController;
    private IProviderController providerController;

    public ShutdownCommand(IList<string> args, IHarvesterController harvesterController, IProviderController providerController) : base(args)
    {
        this.harvesterController = harvesterController;
        this.providerController = providerController;
    }

    public override string Execute()
    {
        var sb = new StringBuilder();
        sb.AppendLine(Constants.SystemShutDown);
        sb.AppendLine(string.Format(Constants.TotalEnergyStored, this.providerController.TotalEnergyProduced));
        sb.Append(string.Format(Constants.TotalOreProduced, this.harvesterController.OreProduced));

        return sb.ToString();
    }
}

