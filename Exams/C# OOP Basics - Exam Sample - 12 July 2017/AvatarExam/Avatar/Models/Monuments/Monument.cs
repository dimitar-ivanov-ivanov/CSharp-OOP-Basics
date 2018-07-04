public abstract class Monument
{
    protected Monument(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public abstract int GetTotalPower();
}
