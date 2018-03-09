using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        long input = long.Parse(Console.ReadLine());
        string[] safe = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var bag = new Dictionary<string, Dictionary<string, long>>();
        long gold = 0;
        long gems = 0;
        long cash = 0;

        for (int i = 0; i < safe.Length; i += 2)
        {
            string name = safe[i];
            long quantity = long.Parse(safe[i + 1]);

            string kvoE = string.Empty;

            if (name.Length == 3)
            {
                kvoE = "Cash";
            }
            else if (name.ToLower().EndsWith("gem"))
            {
                kvoE = "Gem";
            }
            else if (name.ToLower() == "gold")
            {
                kvoE = "Gold";
            }

            if (kvoE == "")
            {
                continue;
            }
            else if (input < bag.Values.Select(x => x.Values.Sum()).Sum() + quantity)
            {
                continue;
            }

            switch (kvoE)
            {
                case "Gem":
                    if (!bag.ContainsKey(kvoE))
                    {
                        if (bag.ContainsKey("Gold"))
                        {
                            if (quantity > bag["Gold"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (bag[kvoE].Values.Sum() + quantity > bag["Gold"].Values.Sum())
                    {
                        continue;
                    }
                    break;
                case "Cash":
                    if (!bag.ContainsKey(kvoE))
                    {
                        if (bag.ContainsKey("Gem"))
                        {
                            if (quantity > bag["Gem"].Values.Sum())
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (bag[kvoE].Values.Sum() + quantity > bag["Gem"].Values.Sum())
                    {
                        continue;
                    }
                    break;
            }

            if (!bag.ContainsKey(kvoE))
            {
                bag[kvoE] = new Dictionary<string, long>();
            }

            if (!bag[kvoE].ContainsKey(name))
            {
                bag[kvoE][name] = 0;
            }

            bag[kvoE][name] += quantity;
            if (kvoE == "Gold")
            {
                gold += quantity;
            }
            else if (kvoE == "Gem")
            {
                gems += quantity;
            }
            else if (kvoE == "Cash")
            {
                cash += quantity;
            }
        }

        foreach (var x in bag)
        {
            Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
            foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
            {
                Console.WriteLine($"##{item2.Key} - {item2.Value}");
            }
        }
    }
}

