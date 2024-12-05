using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Linq;
using System.Runtime;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class Round
    {
        private readonly int[] _answer;

        public Round(int[] answer = null)
        {
            _answer = (answer ?? AnswerSettings.GenerateRandomAnswer());
            Debug.WriteLine(string.Join("-", _answer));
        }

        public string CheckAnswer(int[] guess)
        {
            if (string.Join("", guess) == string.Join("", _answer)) return AnswerSettings.CorrectAnswer;

            string[] result = new string[AnswerSettings._LENGTH];
            var answerList = _answer.AsEnumerable();
            for (int i = 0; i < AnswerSettings._LENGTH; i++)
            {
                if (guess[i] == _answer[i])
                {
                    result[i] = AnswerSettings.CorrectNumberAndPosition;
                }
                else
                {
                    result[i] = (answerList.Contains(guess[i])) ?
                                    AnswerSettings.CorrectNumberWrongPosition :
                                    AnswerSettings.WrongNumber;
                }
            }
            result = result.OrderBy(s => s).ToArray();


            
            Array.Sort(result, (x, y) =>
            {
                // Compare based on GetOrder function
                return GetOrder(x).CompareTo(GetOrder(y));
            });
            return string.Join("", result);
        }

        // Custom sorting logic (all plus signs first, all minus signs second, and nothing for incorrect digits)
        private int GetOrder(string s)
        {
            switch (s)
            {
                case "+": return 0;
                case "-": return 1;
                case " ": return 2;
                default: return 3; // Default (should never happen)
            }
        }

        public bool TryToParseInput(string guess, out int[] result)
        {
            result = new int[AnswerSettings._LENGTH];
            if (guess.Length != AnswerSettings._LENGTH) return false;

            bool isValid = false;

            string pattern = "[1-6]{" + AnswerSettings._LENGTH + "}";
            var regEx = new Regex(pattern);
            if (regEx.IsMatch(guess))
            {
                isValid = true;
                for (int i = 0; i < AnswerSettings._LENGTH; i++)
                {
                    result[i] = (int)char.GetNumericValue(guess[i]);
                }
            }
            return isValid;
        }
    }
}