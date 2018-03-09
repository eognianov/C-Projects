using System;
using System.Collections.Generic;
using System.Text;


public class PriceCalculator
{
    private decimal pricePerNight;
    private int nights;
    private Season season;
    private Discount discount;
    public PriceCalculator(string commnad)
    {
        var splitCommand = commnad.Split();
        pricePerNight = decimal.Parse(splitCommand[0]);
        nights = int.Parse(splitCommand[1]);
        season = Enum.Parse<Season>(splitCommand[2]);
        discount = Discount.None;
        if (splitCommand.Length > 3)
        {
            discount = Enum.Parse<Discount>(splitCommand[3]);
        }
    }
    public string CalculatePrice()
    {
        var tempTotal = pricePerNight * nights * (int) season;

        var discountPercentage = ((decimal) 100 - (int) discount) / 100;

        var totalPrice = tempTotal * discountPercentage;
        return $"{totalPrice:F2}";
    }
}

