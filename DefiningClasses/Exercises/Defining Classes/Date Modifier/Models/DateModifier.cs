namespace Date_Modifier.Models
{
    using System;

    public static class DateModifier
    {
        public static int  CalculateDifferenceInDays(string dateStr1,string dateStr2)
        {
            var date1 = DateTime.Parse(dateStr1);
            var date2 = DateTime.Parse(dateStr2);

            return Math.Abs((date1 - date2).Days);
        }
    }
}
