using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostFrequentNumber
{
    class Program
    {
        static void Main(string[] args)
        {

            var input = File.ReadAllText("input.txt").Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            var number = 0;
            var occurence = new int[65535];
            var minJ = 0;
            var arrNum = new List<int>();
            var occurencies = 0;

            for (int i = 0; i < input.Length; i++)
            {
                occurence[input[i]]++;
            }

            var max = occurence.Max();
            for (int i = 0; i < occurence.Length; i++)
            {
                if (max == occurence[i])
                {
                    number = i;
                    occurencies++;

                }
            }
            File.WriteAllText("output.txt","");
            if (occurencies > 1)
            {
                for (int j = 0; j < input.Length; j++)
                {

                    if (input[j] == number)
                    {
                        if (j < minJ)
                        {
                            minJ = j;
                        }


                    }
                }
                File.AppendAllText("output.txt",input[minJ].ToString());
                //Console.WriteLine(input[minJ]);
            }

            else File.AppendAllText("output.txt",number.ToString());
                //Console.WriteLine(number);


        }
    }
}