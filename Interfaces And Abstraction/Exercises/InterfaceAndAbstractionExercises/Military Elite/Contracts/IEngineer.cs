namespace Military_Elite.Contracts
{
    using System.Collections.Generic;

    public interface IEngineer : ISpecialisedSoldier
    {
        IList<IRepair> Repairs { get; }
    }
}
