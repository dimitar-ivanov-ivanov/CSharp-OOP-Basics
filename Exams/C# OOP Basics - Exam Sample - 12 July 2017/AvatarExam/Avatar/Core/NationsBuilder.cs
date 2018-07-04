using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private Dictionary<string, Nation> nations;
    private StringBuilder warsRecord;
    private int count;

    public NationsBuilder()
    {
        this.warsRecord = new StringBuilder();
        this.count = 1;

        this.nations = new Dictionary<string, Nation>();
        this.nations.Add("Water", new Nation("Water"));
        this.nations.Add("Fire", new Nation("Fire"));
        this.nations.Add("Earth", new Nation("Earth"));
        this.nations.Add("Air", new Nation("Air"));
    }

    public void AssignBender(List<string> benderArgs)
    {
        var type = benderArgs[0];
        var name = benderArgs[1];
        var power = int.Parse(benderArgs[2]);
        var secondParam = double.Parse(benderArgs[3]);
        Bender bender = null;

        switch (type)
        {
            case "Earth":
                bender = new EarthBender(name, power, secondParam);
                break;
            case "Air":
                bender = new AirBender(name, power, secondParam);
                break;
            case "Fire":
                bender = new FireBender(name, power, secondParam);
                break;
            case "Water":
                bender = new WaterBender(name, power, secondParam);
                break;
            default:
                break;
        }

        this.nations[type].AddBender(bender);
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];
        var name = monumentArgs[1];
        var affinity = int.Parse(monumentArgs[2]);
        Monument monument = null;

        switch (type)
        {
            case "Air":
                monument = new AirMonument(name, affinity);
                break;
            case "Water":
                monument = new WaterMonument(name, affinity);
                break;
            case "Fire":
                monument = new FireMonument(name, affinity);
                break;
            case "Earth":
                monument = new EarthMonument(name, affinity);
                break;
            default:
                break;
        }

        nations[type].AddMonument(monument);
    }

    public string GetStatus(string nationsType)
    {
        return nations[nationsType].ToString();
    }

    public void IssueWar(string nationsType)
    {
        warsRecord.AppendLine($"War {count++} issued by {nationsType}");

        var winner = this.nations
            .OrderByDescending(x => x.Value.TotalPower())
            .FirstOrDefault();

        foreach (var nation in this.nations)
        {
            if(nation.Key != winner.Key)
            {
                nation.Value.Clear();
            }
        }
    }

    public string GetWarsRecord()
    {
        return warsRecord.ToString().TrimEnd();
    }
}
