using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace aoc
{

    static class Day5
    {
        private struct Movement
        {
            public Movement(int amount, int from, int to)
            {
                this.amount = amount;
                this.from = from;
                this.to = to;
            }

            public int amount;
            public int from;
            public int to;
        }

        public static void Part1()
        {
            var allLines = Input.AsLines(5, false);
            var split = Array.IndexOf(allLines, "");

            var stacksInput = allLines.Take(split - 1).Reverse().ToList();
            string stacksLayout = allLines[split - 1];
            var movementsInput = allLines.Skip(split + 1).Take(allLines.Length - split - 1).ToList();

            var indices = stacksLayout.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var stackCount = indices.Length;

            List<string> stacks = new List<string>();

            for (int i = 0; i < stackCount; ++i)
            {
                stacks.Add("");
            }

            foreach (var line in stacksInput)
            {
                for (int s = 0; s < stackCount; ++s)
                {
                    var index = 4 * s + 1;
                    if (line.Length > index && line[index] != ' ')
                    {
                        stacks[s] += line[index];
                    }
                }
            }

            List<Movement> movements = new List<Movement>();

            foreach(var line in movementsInput)
            {
                var lineParts = line.Split(' ');
                Movement m = new Movement();
                m.amount = int.Parse(lineParts[1]);
                m.from = int.Parse(lineParts[3]) - 1; // -1 to make them 0 indexed
                m.to = int.Parse(lineParts[5]) - 1; // -1 to make them 0 indexed
                movements.Add(m);
            }

            foreach (var m in movements)
            {
                string toMove = string.Concat(stacks[m.from].TakeLast(m.amount).Reverse());
                stacks[m.to] += toMove;
                stacks[m.from] = stacks[m.from].Remove(stacks[m.from].Length - m.amount, m.amount);
            }

            string result = "";

            foreach (var s in stacks)
            {
                result += s.Last();
            }
            Console.WriteLine(result);
        }

        public static void Part2()
        {
            var allLines = Input.AsLines(5, false);
            var split = Array.IndexOf(allLines, "");

            var stacksInput = allLines.Take(split - 1).Reverse().ToList();
            string stacksLayout = allLines[split - 1];
            var movementsInput = allLines.Skip(split + 1).Take(allLines.Length - split - 1).ToList();

            var indices = stacksLayout.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var stackCount = indices.Length;

            List<string> stacks = new List<string>();

            for (int i = 0; i < stackCount; ++i)
            {
                stacks.Add("");
            }

            foreach (var line in stacksInput)
            {
                for (int s = 0; s < stackCount; ++s)
                {
                    var index = 4 * s + 1;
                    if (line.Length > index && line[index] != ' ')
                    {
                        stacks[s] += line[index];
                    }
                }
            }

            List<Movement> movements = new List<Movement>();

            foreach (var line in movementsInput)
            {
                var lineParts = line.Split(' ');
                Movement m = new Movement();
                m.amount = int.Parse(lineParts[1]);
                m.from = int.Parse(lineParts[3]) - 1; // -1 to make them 0 indexed
                m.to = int.Parse(lineParts[5]) - 1; // -1 to make them 0 indexed
                movements.Add(m);
            }

            foreach (var m in movements)
            {
                string toMove = string.Concat(stacks[m.from].TakeLast(m.amount));
                stacks[m.to] += toMove;
                stacks[m.from] = stacks[m.from].Remove(stacks[m.from].Length - m.amount, m.amount);
            }

            string result = "";

            foreach (var s in stacks)
            {
                result += s.Last();
            }
            Console.WriteLine(result);
        }
    }
}
