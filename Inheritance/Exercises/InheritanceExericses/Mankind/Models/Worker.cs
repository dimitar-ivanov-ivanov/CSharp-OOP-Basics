namespace Mankind.Models
{
    using System;

    public class Worker : Human
    {
        private double weeklySalary;
        private int workingHours;
        private double salaryPerHour;

        private const int MinWeeklySalary = 10;
        private const int MinWorkingHours = 1;
        private const int MaxWorkingHours = 12;

        public Worker(string firstName, string lastName, double weeklySalary, int workingHours)
            : base(firstName, lastName)
        {
            this.WeeklySalary = weeklySalary;
            this.WorkingHours = workingHours;
            this.salaryPerHour = this.weeklySalary / (workingHours * 5);
        }

        public double WeeklySalary
        {
            get { return this.weeklySalary; }
            set
            {
                if (value <= MinWeeklySalary)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                this.weeklySalary = value;
            }
        }

        public int WorkingHours
        {
            get { return this.workingHours; }
            set
            {
                if (value >= MinWorkingHours &&
                   value <= MaxWorkingHours)
                {
                    this.workingHours = value;
                }
                else
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
            }
        }

        public override string ToString()
        {
            return base.ToString()
                + $"\nWeek Salary: {this.WeeklySalary:f2}"
                + $"\nHours per day: {this.workingHours:f2}"
                + $"\nSalary per hour: {this.salaryPerHour:f2}";
        }
    }
}