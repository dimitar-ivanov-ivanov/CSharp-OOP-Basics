namespace Hotel_Reservation
{
    using Hotel_Reservation.Enums;
    using Hotel_Reservation.Models;
    using System;
    using System.Globalization;
    using System.Threading;

    public class Startup
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Execute();
        }

        private static void Execute()
        {
            var args = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var pricePerDay = double.Parse(args[0]);
            var numberOfDays = int.Parse(args[1]);
            var season = (Season)Enum.Parse(typeof(Season), args[2]);
            PriceCalculator priceCalculator = null;

            if (args.Length == 3)
            {
                priceCalculator = new PriceCalculator(pricePerDay, numberOfDays, season);
            }
            else
            {
                var discount = (DiscountType)Enum.Parse(typeof(DiscountType), args[3]);
                priceCalculator = new PriceCalculator(pricePerDay, numberOfDays, season, discount);
            }

            Console.WriteLine($"{priceCalculator.GetTotalHolidayPrice():f2}");
        }
    }
}
