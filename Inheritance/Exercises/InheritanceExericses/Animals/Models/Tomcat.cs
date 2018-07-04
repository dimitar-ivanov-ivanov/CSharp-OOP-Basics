namespace Animals.Models
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gender = "Male") 
            : base(name, age, gender)
        {
        }

        public new string ProduceSound()
        {
           return "Give me one million b***h";
        }
    }
}
