namespace Speed_Racing.Models
{
    using System;

    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private int distanceTravelled;

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.model = model;
            this.fuelAmount = fuelAmount;
            this.fuelConsumption = fuelConsumption;
        }

        public string Model { get => model; set => model = value; }

        public double FuelAmount { get => fuelAmount; private set => fuelAmount = value; }

        public double FuelConsumption { get => fuelConsumption; private set => fuelConsumption = value; }

        public void Drive(int kilometersToTravel)
        {
            var fuelNeeded = kilometersToTravel * this.FuelConsumption;
            if(fuelNeeded > this.FuelAmount)
            {
                throw new ArgumentException("Insufficient fuel for the drive");
            }

            this.distanceTravelled += kilometersToTravel;
            this.FuelAmount -= fuelNeeded;
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.distanceTravelled}";
        }
    }
}
