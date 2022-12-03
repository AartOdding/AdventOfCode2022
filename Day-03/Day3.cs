using System;
using System.Collections.Generic;
using System.Linq;


namespace aoc
{
    static class Day3
    {
        public static void Part1()
        {
            string[] lines = Input.AsLines(3, true);
            int totalScore = 0;

            foreach (var line in lines)
            {
                var length = line.Length;
                var part1 = line.Substring(0, length / 2);
                var part2 = line.Substring(length / 2, length / 2);

                var set1 = part1.ToHashSet();
                var set2 = part2.ToHashSet();

                var common = set1.Intersect(set2);
                var character = common.ToArray()[0];

                int score = 0;

                if (char.IsLower(character))
                {
                    score = (int)character - (int)'a' + 1;
                }
                else
                {
                    score = (int)character - (int)'A' + 27;
                }

                totalScore += score;
            }
            Console.WriteLine(totalScore);
        }

        public static void Part2()
        {
            string[] lines = Input.AsLines(3, true);
            int totalScore = 0;

            for (int g = 0; g < lines.Length; g += 3)
            {
                var bp1 = lines[g].ToHashSet();
                var bp2 = lines[g + 1].ToHashSet();
                var bp3 = lines[g + 2].ToHashSet();

                var common = (bp1.Intersect(bp2).Intersect(bp3)).ToArray()[0];

                int score = 0;

                if (char.IsLower(common))
                {
                    score = (int)common - (int)'a' + 1;
                }
                else
                {
                    score = (int)common - (int)'A' + 27;
                }
                
                totalScore += score;
            }
            Console.WriteLine(totalScore);
        }
    }
}
