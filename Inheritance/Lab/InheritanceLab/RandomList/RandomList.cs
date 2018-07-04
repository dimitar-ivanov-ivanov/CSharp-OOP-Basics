namespace RandomList
{
    using System;
    using System.Collections;

    public class RandomList : ArrayList
    {
        public RandomList()
        {

        }

        public string RandomString()
        {
            var rnd = new Random();
            int element = rnd.Next(0, this.Count - 1);
            var str = this[element];
            this.Remove(str);
            return str.ToString();
        }
    }
}
