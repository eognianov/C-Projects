using System;
using System.Collections.Generic;
using System.Text;


public class PriceCalculator
{
    public decimal Price { get; set; }

    public void Calculte(decimal pricePerDay, int numberOfDays, string season, string discountStr)
    {
        int addPerSeason = AddPerSeaon(season);
        int discountPercentege = DiscountPersentage(discountStr);
        decimal price = pricePerDay * numberOfDays * addPerSeason;
        decimal discount = price * discountPercentege / 100;
        this.Price = price - discount;
    }

    private int DiscountPersentage(string discount)
    {
        switch (discount)
        {
            case "VIP":
                return 20;
            case "SecondVisit":
                return 10;
            default:
                return 0;
        }
    }

    private int AddPerSeaon(string season)
    {
        switch (season)
        {
            case "Autumn":
                return 1;
                break;
            case "Sprint":
                return 2;
                break;
            case "Winter":
                return 3;
                break;
            case "Summer":
                return 4;
                break;
            default:
                return 0;
                break;
        }
    }

    public override string ToString()
    {
        return $"{Price:F2}";
    }
}

