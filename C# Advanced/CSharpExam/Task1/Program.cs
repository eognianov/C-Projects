using System;
using System.Collections.Generic;
using System.Linq;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] inputBullets = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Stack<int> bullets = new Stack<int>(inputBullets);
            int[] inputLocks = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Queue<int> locks = new Queue<int>(inputLocks);
            int prize = int.Parse(Console.ReadLine());
            int shotsCounter = 0;
            int bulletsTotal = bullets.Count;

            while (bullets.Count!=0 && locks.Count!=0)
            {
                shotsCounter++;
                
                if (bullets.Pop() <= locks.Peek())
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }
                
                if (shotsCounter == barrelSize && bullets.Count !=0)
                {
                    shotsCounter = 0;
                    Console.WriteLine("Reloading!");
                }

            }
            if (locks.Count == 0)
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${prize - ((bulletsTotal-bullets.Count) * bulletPrice)}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");   
            }

        }
    }
}
