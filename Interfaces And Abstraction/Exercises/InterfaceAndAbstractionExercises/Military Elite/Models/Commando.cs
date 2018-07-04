namespace Military_Elite.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Military_Elite.Contracts;
    using Military_Elite.Enums;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private IList<IMission> missions;

        public Commando(int id, string firstName, string lastName,
            double salary, string corps, IList<string> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this.missions = GetValidMission(missions);
        }

        private IList<IMission> GetValidMission(IList<string> missions)
        {
            var list = new List<IMission>();

            for (int i = 0; i < missions.Count; i += 2)
            {
                var missionCodeName = missions[i];
                var missionState = missions[i + 1];
                MissionState state = MissionState.inProgress;

                if(Enum.TryParse(missionState,out state))
                {
                    list.Add(new Mission(missionCodeName, state));
                }
            }

            return list;
        }

        public IList<IMission> Missions
        {
            get { return this.missions; }
            private set { this.missions = value; }
        }

        public override string ToString()
        {
            var output = new StringBuilder("\n");
            output.AppendLine("Missions:");

            foreach (var mission in this.missions)
            {
                output.AppendLine("  " + mission.ToString());
            }

            output = output.Remove(output.Length - 2, 2);

            return base.ToString() + output.ToString();
        }
    }
}
