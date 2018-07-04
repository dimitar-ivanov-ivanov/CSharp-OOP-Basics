namespace Hotel_Reservation.Models
{
    using Hotel_Reservation.Enums;

    public class PriceCalculator
    {
        private double pricePerDay;
        private int numberOfDays;
        private Season season;
        private DiscountType discount;

        public PriceCalculator(double pricePerDay, int numberOfDays,
            Season season, DiscountType discount = DiscountType.NoDiscount)
        {
            this.pricePerDay = pricePerDay;
            this.numberOfDays = numberOfDays;
            this.season = season;
            this.discount = discount;
        }

        public double PricePerDay { get => pricePerDay; private set => pricePerDay = value; }

        public int NumberOfDays { get => numberOfDays; private set => numberOfDays = value; }

        public Season Season { get => season; private set => season = value; }

        public DiscountType Discount { get => discount; private set => discount = value; }

        public double GetTotalHolidayPrice()
        {
            var totalPrice = this.PricePerDay * this.NumberOfDays
                * (int)this.Season;

            var val = (double)this.Discount / 100;

            if (this.Discount != DiscountType.NoDiscount)
            {
                totalPrice -= totalPrice * val;
            }

            return totalPrice;
        }
    }
}
