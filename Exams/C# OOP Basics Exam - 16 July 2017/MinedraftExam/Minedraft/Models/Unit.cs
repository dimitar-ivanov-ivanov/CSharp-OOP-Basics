public abstract class Unit
{
    protected Unit(string id)
    {
        Id = id;
    }

    public virtual string Type { get; }

    public string Id { get; }
}