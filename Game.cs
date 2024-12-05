﻿using System;
using System.Collections.Generic;
using System.Security.Policy;

namespace ConsoleApp1
{
    public class Game
    {
        private const int NUMBER_OF_ATTEMPTS = 10;
        
        public void PrintRules()
        {
            Console.WriteLine("");
            Console.WriteLine("Game Rules:");
            Console.WriteLine("----------");
            Console.WriteLine($" The Mastermind will generate a {AnswerSettings._LENGTH} digits in length, with each digit between the numbers 1 and 6");
            Console.WriteLine($" You will try to guess the code by inputting {AnswerSettings._LENGTH} numbers and press the Enter key");
            Console.WriteLine($" A minus(-) sign should be printed for every digit that is correct but in the wrong position,");
            Console.WriteLine($" and a plus(+) sign should be printed for every digit that is both correct and in the correct position.");
            Console.WriteLine($" All plus signs are printed first, all minus signs second, and nothing for incorrect digits.");
            Console.WriteLine("----------");
            Console.WriteLine($" You will have {NUMBER_OF_ATTEMPTS} attempts to guess the number correctly.");
            Console.WriteLine("");
            //
        }
        public bool Play()
        {
            Round gameRound = new Round(AnswerSettings.GenerateRandomAnswer());
            Console.WriteLine($"{Environment.NewLine}Type a {AnswerSettings._LENGTH} digits number");
            for (int i = 0; i < NUMBER_OF_ATTEMPTS; i++)
            {
                if (i > 0)
                {
                    Console.Write($"{Environment.NewLine}Attempt #{i + 1}: ");
                }
                string userInput = Console.ReadLine();
                bool isValid = gameRound.TryToParseInput(userInput, out int[] result);
                if (isValid)
                {
                    var isSuccess = CheckGuessOutcome(gameRound, result);
                    if (isSuccess) return true;
                }
                else
                {
                    HandleInvalidGuess();
                }
            }
            return false;
        }

        private bool CheckGuessOutcome(Round gameRound, int[] guess)
        {
            var outcome = gameRound.CheckAnswer(guess);
            if (outcome.Equals(AnswerSettings.CorrectAnswer))
            {
                Console.WriteLine("Correct answer!");
                return true;
            }
            else
            {
                Console.WriteLine(outcome);
                return false;
            }
        }

        private void HandleInvalidGuess()
        {
            Console.WriteLine("Not a valid input.");
            Console.WriteLine("Do you want to read the rules? (Y) to read, or any key to guess again.");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                PrintRules();
                Console.WriteLine("Press any key to guess again");
                Console.ReadKey();
            }            
        }
    }
}