using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace aoc
{
    static class Day8
    {
        static List<List<int>> heightMap = new List<List<int>>();
        static List<List<bool>> result = new List<List<bool>>();

        static int width = 0;
        static int height = 0;

        public static void Part1()
        {
            var lines = Input.AsLines(8, true);

            foreach (var l in lines)
            {
                var h = new List<int>();
                var r = new List<bool>();

                heightMap.Add(h);
                result.Add(r);

                foreach (var c in l)
                {
                    h.Add(c - '0');
                    r.Add(false);
                }
            }

            width = heightMap[0].Count;
            height = heightMap.Count;

            for (int x = 0; x < width; ++x)
            {
                int prev = -1;

                for (int y = 0; y < height; ++y)
                {
                    int current = heightMap[y][x];
                    if (current > prev)
                    {
                        result[y][x] = true;
                        prev = current;
                    }
                }

                prev = -1;

                for (int y = height-1; y >= 0; --y)
                {
                    int current = heightMap[y][x];
                    if (current > prev)
                    {
                        result[y][x] = true;
                        prev = current;
                    }
                }
            }

            for (int y = 0; y < height; ++y)
            {
                int prev = -1;

                for (int x = 0; x < width; ++x)
                {
                    int current = heightMap[y][x];
                    if (current > prev)
                    {
                        result[y][x] = true;
                        prev = current;
                    }
                }

                prev = -1;

                for (int x = width - 1; x >= 0; --x)
                {
                    int current = heightMap[y][x];
                    if (current > prev)
                    {
                        result[y][x] = true;
                        prev = current;
                    }
                }
            }

            var trueCount = 0;

            foreach (var rl in result)
            {
                foreach (var r in rl)
                {
                    trueCount += r ? 1 : 0;
                }
            }
            Console.WriteLine(trueCount);

        }

        static int ScenicScore(int atX, int atY)
        {
            int self = heightMap[atY][atX];
            int currentDirectionScore = 0;
            int totalScore = 1;

            for (int x = atX + 1; x < width; ++x)
            {
                int curr = heightMap[atY][x];
                currentDirectionScore += 1;
                if (curr >= self) break;
            }

            totalScore *= currentDirectionScore;
            currentDirectionScore = 0;

            for (int x = atX - 1; x >= 0; --x)
            {
                int curr = heightMap[atY][x];
                currentDirectionScore += 1;
                if (curr >= self) break;
            }

            totalScore *= currentDirectionScore;
            currentDirectionScore = 0;

            for (int y = atY + 1; y < height; ++y)
            {
                int curr = heightMap[y][atX];
                currentDirectionScore += 1;
                if (curr >= self) break;
            }

            totalScore *= currentDirectionScore;
            currentDirectionScore = 0;

            for (int y = atY - 1; y >= 0; --y)
            {
                int curr = heightMap[y][atX];
                currentDirectionScore += 1;
                if (curr >= self) break;
            }

            totalScore *= currentDirectionScore;

            return totalScore;
        }

        public static void Part2()
        {
            int topScore = 0;

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    topScore = Math.Max(topScore, ScenicScore(x, y));
                }
            }

            Console.WriteLine(topScore);
        }
    }
}
