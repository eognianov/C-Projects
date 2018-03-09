using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputData = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Reverse();
            Stack<string> calculation = new Stack<string>(inputData);
            while (calculation.Count>1)
            {
                var leftOperand = int.Parse(calculation.Pop());
                var operation = calculation.Pop();
                var rightOperand = int.Parse(calculation.Pop());
                switch (operation)
                {
                    case "+":
                        calculation.Push((leftOperand+rightOperand).ToString());
                        break;
                    case "-":
                        calculation.Push((leftOperand - rightOperand).ToString());
                        break;
                }

            }
            Console.WriteLine(calculation.Pop());
        }
    }
}
