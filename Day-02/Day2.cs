using System;
using System.Collections.Generic;


namespace aoc
{
    static class Day2
    {
        private static int ScoreForRound(char opponentsMove, char myMove)
        {
            if (opponentsMove == 'A') // Opponent chooses Rock
            {
                if (myMove == 'X') return 1 + 3; // Rock, Draw
                else if (myMove == 'Y') return 2 + 6; // Paper, Win
                else if (myMove == 'Z') return 3 + 0; // Scissors, Lose
            }
            else if (opponentsMove == 'B') // Opponent chooses Paper
            {
                if (myMove == 'X') return 1 + 0; // Rock, Lose
                else if (myMove == 'Y') return 2 + 3; // Paper, Draw
                else if (myMove == 'Z') return 3 + 6; // Scissors, Win
            }
            else if (opponentsMove == 'C') // Opponent chooses Sciccors
            {
                if (myMove == 'X') return 1 + 6; // Rock, Win
                else if (myMove == 'Y') return 2 + 0; // Paper, Lose
                else if (myMove == 'Z') return 3 + 3; // Scissors, Draw
            }
            throw new ArgumentException($"Invalid move: {opponentsMove} vs {myMove}");
        }

        public static void Part1()
        {
            string[] lines = Properties.Resources.input_day2.Split('\n', StringSplitOptions.RemoveEmptyEntries);

            int points = 0;

            foreach (var line in lines)
            {
                points += ScoreForRound(line[0], line[2]);
            }

            Console.WriteLine($"{points}");
        }

        public static void Part2()
        {
        }
    }
}
