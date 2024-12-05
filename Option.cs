using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public sealed class Option
    {
        public static Option Start = new Option("S", "Start a new game", 1);
        public static Option Help = new Option("H", "Read the rules", 2);
        public static Option Quit = new Option("Q", "Quit the game", 3);

        public string Key;
        public string Description;
        public int Order;

        public Option(string key, string description, int order)
        {
            this.Key = key;
            this.Description = description;
            this.Order = order;
        }

        public static IEnumerable<Option> GetAllOrdered()
        {
            return new[] { Start, Help, Quit }.OrderBy(o => o.Order);
        }
    }
}