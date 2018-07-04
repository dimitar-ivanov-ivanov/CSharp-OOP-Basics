namespace Military_Elite.Models
{
    using Military_Elite.Contracts;
    using Military_Elite.Enums;

    public class Mission : IMission
    {
        private string codeName;
        private MissionState state;

        public Mission(string codeName,MissionState missionState)
        {
            this.codeName = codeName;
            this.state = missionState;
        }

        public MissionState State
        {
            get { return this.state; }
            private set { this.state = value; }
        }

        public string CodeName
        {
            get { return this.codeName; }
            private set { this.codeName = value; }
        }

        public void CompleteMission()
        {
            this.State = MissionState.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.codeName} State: {this.state}";
        }
    }
}
