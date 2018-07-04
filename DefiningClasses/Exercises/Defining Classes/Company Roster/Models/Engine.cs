namespace Company_Roster.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private Dictionary<string, List<Employee>> departments;

        public Engine()
        {
            this.departments = new Dictionary<string, List<Employee>>();
        }

        public void Run()
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var args = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var name = args[0];
                var salary = double.Parse(args[1]);
                var position = args[2];
                var department = args[3];
                var employee = CreateEmployee(args, name, salary, position, department);

                if (!departments.ContainsKey(department))
                {
                    departments.Add(department, new List<Employee>());
                }

                this.departments[department].Add(employee);
            }

            Print();
        }

        private void Print()
        {
            var result = this.departments
                            .OrderByDescending(x => x.Value
                            .Average(y => y.Salary))
                            .FirstOrDefault();

            Console.WriteLine($"Highest Average Salary: {result.Key}");
            foreach (var employee in result.Value.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine(employee);
            }
        }

        private Employee CreateEmployee(string[] args, string name, double salary, string position, string department)
        {
            var employee = new Employee(name, salary, position, department);

            if (args.Length == 5)
            {
                var val = 0;
                if (int.TryParse(args[4], out val))
                {
                    employee.Age = val;
                }
                else
                {
                    employee.Email = args[4];
                }
            }
            else if (args.Length == 6)
            {
                employee.Email = args[4];
                employee.Age = int.Parse(args[5]);
            }

            return employee;
        }
    }
}
