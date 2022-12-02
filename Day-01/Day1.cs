using System;
using System.Collections.Generic;


namespace aoc
{
    static class Day1
    {
        public static void Part1()
        {
            string[] lines = Properties.Resources.input.Split('\n');

            int highest = 0;
            int current = 0;

            for (int i = 0; i < lines.Length; ++i)
            {
                if (lines[i] == "")
                {
                    highest = Math.Max(highest, current);
                    current = 0;
                }
                else
                {
                    current += int.Parse(lines[i]);
                }
            }

            Console.WriteLine($"The Elf carrying the most calories has {highest} calories.");
        }

        public static void Part2()
        {
            string[] lines = Properties.Resources.input.Split('\n');

            List<int> caloriesPerElf = new List<int>();

            int current = 0;

            for (int i = 0; i < lines.Length; ++i)
            {
                if (lines[i] == "")
                {
                    caloriesPerElf.Add(current);
                    current = 0;
                }
                else
                {
                    current += int.Parse(lines[i]);
                }
            }

            caloriesPerElf.Sort();

            var best3 = caloriesPerElf[caloriesPerElf.Count - 1]
                + caloriesPerElf[caloriesPerElf.Count - 2]
                + caloriesPerElf[caloriesPerElf.Count - 3];

            Console.WriteLine($"The three Elves carrying the most calories together have {best3} calories.");
        }
    }
}
