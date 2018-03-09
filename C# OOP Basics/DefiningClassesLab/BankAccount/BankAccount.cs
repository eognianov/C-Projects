using System;
using System.Collections.Generic;
using System.Text;


public class BankAccount
{
    private int id;
    private decimal balance;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public decimal Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (balance < amount)
        {
            Console.WriteLine("Insufficient balance");
        }
        else
        {
            Balance -= amount;
        }


    }

    public override string ToString()
    {
        return $"Account ID{Id}, balance {Balance:F2}";
    }
}

