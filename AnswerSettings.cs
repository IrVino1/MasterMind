using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public static class AnswerSettings
    {
        public static readonly string CorrectAnswer = "++++";
        public static readonly string CorrectNumberAndPosition = "+";
        public static readonly string CorrectNumberWrongPosition = "-";
        public static readonly string WrongNumber = " ";
        public const int _LENGTH = 4;

        public static int[] GenerateRandomAnswer()
        {
            //An answer will consist of {_LENGTH} digits 1 - 6(1 and 6 can be included)
            var result = new int[_LENGTH];
            var rand = new Random();
            for (int i = 0; i < _LENGTH; i++)
            {
                result[i] = rand.Next(1, 7); //this will generate random number in range [1,6]  
            }
            return result;
        }

    }
}