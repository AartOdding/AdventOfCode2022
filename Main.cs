using System;
using System.Collections.Generic;
using System.IO;

namespace aoc
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sets the current directory to the root folder of the project.
            Directory.SetCurrentDirectory(Path.Combine(Directory.GetCurrentDirectory(), "../../.."));

            //Input.UseTestData = true;

            //Day1.Part1();
            //Day1.Part2();

            //Day2.Part1();
            //Day2.Part2();

            //Day3.Part1();
            //Day3.Part2();

            //Day4.Part1();
            //Day4.Part2();

            Day5.Part1();
            Day5.Part2();

        }
    }
}
