using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        List<Trainer> trainers = new List<Trainer>();
        string[] inputData = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        while (inputData[0] != "Tournament")
        {
            string trainer = inputData[0];
            string pokemonName = inputData[1];
            string pokemonElement = inputData[2];
            int pokemonHealth = int.Parse(inputData[3]);
            int trainerBadges = 0;

            Pokemon pokemon = new Pokemon(pokemonName,pokemonElement,pokemonHealth);
            if (trainers.Any(t=>t.Name == trainer))
            {
                trainers.FirstOrDefault(t=>t.Name==trainer).Pokemons.Add(pokemon);
            }
            else
            {
                trainers.Add(new Trainer(trainer, pokemon));
            }

            inputData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
        string command = Console.ReadLine();
        while (command != "End")
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(p=>p.Element==command))
                {
                    trainer.NumberOfBadges += 1;
                }
                else
                {
                    for (int i = 0; i < trainer.Pokemons.Count; i++)
                    {
                        trainer.Pokemons[i].Health -= 10;
                        if (trainer.Pokemons[i].Health<=0)
                        {
                            trainer.Pokemons.RemoveAt(i);
                        }
                    }
                }
            }
            command = Console.ReadLine();
        }
        foreach (var trainer in trainers.OrderByDescending(t=>t.NumberOfBadges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
        }
    }
}
