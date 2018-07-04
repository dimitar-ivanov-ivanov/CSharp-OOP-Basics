namespace Military_Elite.Contracts
{
    using Military_Elite.Enums;

    public interface IMission
    {
        string CodeName { get; }

        MissionState State { get; }

        void CompleteMission();
    }
}
