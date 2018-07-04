namespace Military_Elite.Contracts
{
    using Military_Elite.Enums;

    public interface ISpecialisedSoldier : IPrivate
    {
        CorpsType Corps { get; }
    }
}
