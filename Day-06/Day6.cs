using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace aoc
{
    static class Day6
    {
        public static bool AllUnique(char[] input)
        {
            return input.ToHashSet().Count == input.Length;
        }

        public static void Part1()
        {
            string input = Input.AsString(6);

            char[] buffer = new char[4];
            int bufferPos = 0;

            for (int index = 0; index < input.Length; ++index)
            {
                buffer[bufferPos] = input[index];
                bufferPos = (bufferPos + 1) % buffer.Length;

                if (AllUnique(buffer) && index >= (buffer.Length - 1))
                {
                    Console.WriteLine(index + 1);
                    break;
                }
            }
        }

        public static void Part2()
        {
            string input = Input.AsString(6);

            char[] buffer = new char[14];
            int bufferPos = 0;

            for (int index = 0; index < input.Length; ++index)
            {
                buffer[bufferPos] = input[index];
                bufferPos = (bufferPos + 1) % buffer.Length;

                if (AllUnique(buffer) && index >= (buffer.Length - 1))
                {
                    Console.WriteLine(index + 1);
                    break;
                }
            }
        }
    }
}
