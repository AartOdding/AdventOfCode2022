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
                if (myMove == 'X') return 1 + 3;      // Rock, Draw
                else if (myMove == 'Y') return 2 + 6; // Paper, Win
                else if (myMove == 'Z') return 3 + 0; // Scissors, Lose
            }
            else if (opponentsMove == 'B') // Opponent chooses Paper
            {
                if (myMove == 'X') return 1 + 0;      // Rock, Lose
                else if (myMove == 'Y') return 2 + 3; // Paper, Draw
                else if (myMove == 'Z') return 3 + 6; // Scissors, Win
            }
            else if (opponentsMove == 'C') // Opponent chooses Sciccors
            {
                if (myMove == 'X') return 1 + 6;      // Rock, Win
                else if (myMove == 'Y') return 2 + 0; // Paper, Lose
                else if (myMove == 'Z') return 3 + 3; // Scissors, Draw
            }
            throw new ArgumentException($"Invalid move: {opponentsMove} vs {myMove}.");
        }

        private static int ScoreForRoundWithResult(char opponentsMove, char result)
        {
            if (opponentsMove == 'A') // Opponent chooses Rock
            {
                if (result == 'X') return 0 + 3;      // Need to lose; Pick Scissors (3 pt)
                else if (result == 'Y') return 3 + 1; // Need to draw; Pick Rock (1 pt)
                else if (result == 'Z') return 6 + 2; // Need to win; Pick Paper (2 pt)
            }
            else if (opponentsMove == 'B') // Opponent chooses Paper
            {
                if (result == 'X') return 0 + 1;      // Need to lose; Pick Rock (1 pt)
                else if (result == 'Y') return 3 + 2; // Need to draw; Pick Paper (2 pt)
                else if (result == 'Z') return 6 + 3; // Need to win; Pick Scissors (3 pt)
            }
            else if (opponentsMove == 'C') // Opponent chooses Sciccors
            {
                if (result == 'X') return 0 + 2;      // Need to lose; Pick Paper (2 pt)
                else if (result == 'Y') return 3 + 3; // Need to draw; Pick Scissors (3 pt)
                else if (result == 'Z') return 6 + 1; // Need to win; Pick Rock (1 pt)
            }
            throw new ArgumentException($"Invalid move: {opponentsMove} with desired result: {result}.");
        }

        public static void Part1()
        {
            string[] lines = Input.AsLines(2, true);

            int points = 0;

            foreach (var line in lines)
            {
                points += ScoreForRound(line[0], line[2]);
            }

            Console.WriteLine($"Following the first strategy guide will result in {points} points.");
        }

        public static void Part2()
        {
            string[] lines = Input.AsLines(2, true);

            int points = 0;

            foreach (var line in lines)
            {
                points += ScoreForRoundWithResult(line[0], line[2]);
            }

            Console.WriteLine($"Following the second strategy guide will result in {points} points.");
        }
    }
}
