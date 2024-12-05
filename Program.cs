using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Mastermind");
            var game = new Game();

            bool readyToStart = false;
            while (!readyToStart)
            {
                foreach (var opt in Option.GetAllOrdered())
                {
                    Console.WriteLine($"Enter {opt.Key} to {opt.Description}");
                }
                var cmd = Console.ReadKey();
                if (IsKeyEqual(cmd.KeyChar, Option.Quit.Key)) return;
                if (IsKeyEqual(cmd.KeyChar, Option.Help.Key))
                {
                    game.PrintRules();
                };
                readyToStart = IsKeyEqual(cmd.KeyChar, Option.Start.Key);
            }

            bool keepPlaying = true;
            while (keepPlaying)
            {
                bool isWinner = game.Play();
                string nextGameMessage = isWinner ?
                                            "You won!" :
                                            "You exceeded maximum number of attempts.";
                Console.WriteLine($"{Environment.NewLine}{nextGameMessage}");
                Console.WriteLine($"Press any key to {Option.Start.Description}, ({Option.Quit.Key}) to {Option.Quit.Description}");

                keepPlaying = !IsKeyEqual(Console.ReadKey().KeyChar, Option.Quit.Key);
            }
        }

        private static bool IsKeyEqual(char keyChar, string value)
        {
            return value.Equals(keyChar.ToString(), StringComparison.OrdinalIgnoreCase);
        }
    
    }
}
