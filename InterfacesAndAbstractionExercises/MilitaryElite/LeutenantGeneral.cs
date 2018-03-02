using System;
using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral:Private, ILeutantGeneral
{
    public LeutenantGeneral(int id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName, salary)
    {
        privates = new List<ISoldier>();
    }

    private ICollection<ISoldier> privates;

    public IReadOnlyCollection<ISoldier> Privates => (IReadOnlyCollection<ISoldier>) this.privates;

    public void AddPrivate(ISoldier soldier)
    {
        this.privates.Add(soldier);
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine(base.ToString());
        builder.AppendLine($"{nameof(this.Privates)}: ");
        foreach (var @private in Privates)
        {
            builder.AppendLine($"  {@private.ToString()}");
        }

        string result = builder.ToString().TrimEnd();
        return result;
    }
}
