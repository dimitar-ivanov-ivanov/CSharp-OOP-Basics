using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;
    private string type;

    public Nation(string type)
    {
        this.type = type;
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public void AddBender(Bender bender)
    {
        this.benders.Add(bender);
    }

    public void AddMonument(Monument monument)
    {
        this.monuments.Add(monument);
    }

    public void Clear()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    public double TotalPower()
    {
        var totalBenderPower = this.benders.Sum(x => x.GetTotalPower());
        var totalMonumentPower = this.monuments.Sum(x => x.GetTotalPower());

        var enchanedPower = totalBenderPower / 100 * totalMonumentPower;

        return totalBenderPower + enchanedPower;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{type} Nation");

        if(this.benders.Count == 0)
        {
            builder.AppendLine("Benders: None");
        }
        else
        {
            builder.AppendLine("Benders:");
            foreach (var bender in this.benders)
            {
                builder.AppendLine($"###{bender}");
            }
        }

        if(this.monuments.Count == 0)
        {
            builder.AppendLine("Monuments: None");
        }
        else
        {
            builder.AppendLine("Monuments:");
            foreach (var monument in this.monuments)
            {
                builder.AppendLine($"###{monument}");
            }
        }

        return builder.ToString().TrimEnd();
    }
}