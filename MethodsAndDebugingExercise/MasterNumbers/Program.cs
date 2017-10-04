using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterNumbers
{
    class Program
    {
        static bool isNumberPalindrome(int number)
        {
            //********too much memory usage
            //string reverseNumberString = number.ToString();
            //string reverseNumberStringTemp = "";
            //for (int i = reverseNumberString.Length - 1; i >= 0; i--)
            //{
            //    reverseNumberStringTemp+=reverseNumberString[i];
            //}
            //int reversedNumber = int.Parse(reverseNumberStringTemp);
            //if (number == reversedNumber)
            //{
            //    return true;
            //}
            //return false;
            string n = number.ToString();
                for (int i = 0; i < n.Length / 2; i++)
                {
                    if (n[i] != n[n.Length - 1 - i]) { return false; }
                }
                return true;
        }

        static bool isSumOfDigitsIsDevisibleBySeven(int number)
        {
            int sum = 0;
            int lastDigitOfNumber = 0;
            while (number > 0)
            {
                lastDigitOfNumber = number % 10;
                sum += lastDigitOfNumber;
                number /= 10;
            }
            if (sum % 7 == 0)
            {
                return true;
            }
            return false;
        }

        static bool IsOneEvenDigit(int number)
        {
            
            while (number > 0)
            {
                
                if (number % 10  % 2 == 0)
                {
                    
                    return true;
                }
                number /= 10;
            }
            return false;
        }

        static bool isMasterNumber(int number)
        {
            if (isNumberPalindrome(number) && isSumOfDigitsIsDevisibleBySeven(number) && IsOneEvenDigit(number))
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                if (isMasterNumber(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
