using System;

public interface IDatetime
{
    System.DateTime Now();

    void AddDays(System.DateTime date, double daysToAdd);

    TimeSpan SubstractDays(System.DateTime date, int daysToSybstract);
}