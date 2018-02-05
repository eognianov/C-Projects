using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Queue<string> firstPlayer = new Queue<string>(input);
            input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            Queue<string> secondPlayer = new Queue<string>(input);
            int turns = 0;
            while (turns< 1000000 && firstPlayer.Count>0 && secondPlayer.Count>0)
            {
                int firstPlayerPoints = int.Parse(firstPlayer.Peek().Substring(0, firstPlayer.Peek().Length-1));
                int secondPlayerPoints = int.Parse(secondPlayer.Peek().Substring(0, secondPlayer.Peek().Length-1));
                List<string> flop = new List<string>();
                flop.Add(firstPlayer.Dequeue());
                flop.Add(secondPlayer.Dequeue());

                if (firstPlayerPoints > secondPlayerPoints)
                {
                    flop.OrderByDescending(x=>x).ToList().ForEach(x=>firstPlayer.Enqueue(x));
                }else if (firstPlayerPoints < secondPlayerPoints)
                {
                    flop.OrderByDescending(x => x).ToList().ForEach(x => secondPlayer.Enqueue(x));
                }
                else
                {
                    
                    flop.Add(firstPlayer.Dequeue());
                    flop.Add(secondPlayer.Dequeue());
                    PlayDraw(firstPlayer, secondPlayer,flop);
                }

                turns++;
            }
            if (firstPlayer.Count == secondPlayer.Count)
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
            else if (firstPlayer.Count > secondPlayer.Count)
            {
                Console.WriteLine($"First player wins after {turns} turns");
            }
            else
            {
                Console.WriteLine($"Second player wins after {turns} turns");
            }
            
        }

        private static void PlayDraw(Queue<string> firstPlayer, Queue<string> secondPlayer, List<string> flop)
        {
            
            int firstSum = 0;
            int secondSum = 0;
            
            for (int i = 0; i < Math.Min(3, Math.Min(firstPlayer.Count,secondPlayer.Count)); i++)
            {
                int letter = firstPlayer.Peek().ToUpper().ToCharArray().Last() - 64;
                firstSum += letter;
                flop.Add(firstPlayer.Dequeue());
                letter = secondPlayer.Peek().ToUpper().ToCharArray().Last() - 64;
                secondSum += letter;
                flop.Add(secondPlayer.Dequeue());
            }
            if (firstSum > secondSum)
            {
                
                firstPlayer.Enqueue(flop.OrderByDescending(x => x).ToString());
            }
            else if (firstSum < secondSum)
            {
                
                secondPlayer.Enqueue(flop.OrderByDescending(x=>x).ToString());
                
            }
            else
            {
                if(firstPlayer.Count!=0 && secondPlayer.Count != 0)
                    PlayDraw(firstPlayer,secondPlayer,flop);
            }
        }
    }
}
