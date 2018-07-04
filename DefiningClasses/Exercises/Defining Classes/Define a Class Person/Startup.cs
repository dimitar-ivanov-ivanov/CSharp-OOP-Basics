namespace Define_A_Class_Person
{
    using Define_A_Class_Person.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var person = new Person();
            person.Name = "Pesho";
            person.Age = 20;
        }
    }
}