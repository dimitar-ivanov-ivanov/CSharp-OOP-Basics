namespace Define_A_Class_Person.Models
{
    public class Person
    {
        private string name;
        private int age;

        public Person() { }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }
    }
}
