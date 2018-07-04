﻿namespace Birthday_Celebrations.Models
{
    using Birthday_Celebrations.Contracts;

    public class Robot : IRobot
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            this.Id = id;
            this.Model = model;
        }

        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }

        public string Id
        {
            get { return this.id; }
            private set { this.id = value; }
        }
    }
}
