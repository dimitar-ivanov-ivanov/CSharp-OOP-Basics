namespace Telephony.Models
{
    using System.Linq;
    using Telephony.Contracts;

    public class Smartphone : IBrowseable, ICallable
    {
        public string Browse(string website)
        {
            var numbersCount = website.Count(x => char.IsDigit(x));

            if (numbersCount != 0)
            {
                return $"Invalid URL!";
            }

            return $"Browsing: {website}!";
        }

        public string Call(string phoneNumber)
        {
            var numbersCount = phoneNumber.Count(x => char.IsDigit(x));

            if (numbersCount != phoneNumber.Length)
            {
                return $"Invalid number!";
            }

            return $"Calling... {phoneNumber}";
        }
    }
}
