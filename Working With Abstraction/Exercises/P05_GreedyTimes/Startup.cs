namespace P05_GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main(string[] args)
        {
            long capacity = long.Parse(Console.ReadLine());
            string[] itemQuantity = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();

            for (int i = 0; i < itemQuantity.Length; i += 2)
            {
                string name = itemQuantity[i];
                long quantity = long.Parse(itemQuantity[i + 1]);

                string itemType = GetItemType(name);
                long currentWeight = bag.Values.Select(x => x.Values.Sum()).Sum();

                if (itemType == "invalid type" || capacity < currentWeight + quantity)
                {
                    continue;
                }

                if (!bag.ContainsKey(itemType))
                {
                    bag[itemType] = new Dictionary<string, long>();
                }

                if (!bag[itemType].ContainsKey(name))
                {
                    bag[itemType][name] = 0;
                }

                if (itemType != "Gold")
                {
                    string nextType = itemType == "Gem" ? "Gold" : "Gem";

                    if (!bag.ContainsKey(nextType))
                    {
                        bag.Add(nextType, new Dictionary<string, long>());
                    }

                    long currentTypeNewQuantity = bag[itemType].Values.Sum() + quantity;
                    long nextTypeQuantity = bag[nextType].Values.Sum();

                    if (currentTypeNewQuantity > nextTypeQuantity)
                    {
                        bag[itemType].Remove(name);
                        continue;
                    }
                }

                bag[itemType][name] += quantity;
            }

            Print(bag);
        }

        private static string GetItemType(string name)
        {
            if (name.Length == 3)
            {
                return "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                return "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                return "Gold";
            }

            return "invalid type";
        }

        private static void Print(Dictionary<string, Dictionary<string, long>> bag)
        {
            var typesToPrint = bag.Where(x => x.Value.Count > 0)
                .OrderByDescending(x => x.Value.Sum(y => y.Value));

            foreach (var itemType in typesToPrint)
            {
                Console.WriteLine($"<{itemType.Key}> ${itemType.Value.Values.Sum()}");

                var itemsToPrint = itemType.Value
                    .OrderByDescending(y => y.Key).ThenBy(y => y.Value);

                foreach (var item in itemsToPrint)
                {
                    Console.WriteLine($"##{item.Key} - {item.Value}");
                }
            }
        }
    }
}