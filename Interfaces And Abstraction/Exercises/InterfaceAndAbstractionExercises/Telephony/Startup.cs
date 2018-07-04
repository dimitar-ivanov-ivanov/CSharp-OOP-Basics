namespace Telephony
{
    using System;
    using Telephony.Models;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Execute();
        }

        private static void Execute()
        {
            var smartPhone = new Smartphone();
            var phones = Console.ReadLine().Split(' ');
            var websites = Console.ReadLine().Split(' ');

            foreach (var phone in phones)
            {
                Console.WriteLine(smartPhone.Call(phone));
            }

            foreach (var website in websites)
            {
                Console.WriteLine(smartPhone.Browse(website));
            }
        }
    }
}
