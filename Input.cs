using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace aoc
{
    static class Input
    {
        public static bool UseTestData { get; set; } = false;

        public static string AsString(int day)
        {
            string dayString = $"Day-{day:00}";
            string fileName = UseTestData ? "test_input.txt" : "input.txt";
            return File.ReadAllText(Path.Combine(dayString, fileName));
        }

        public static string[] AsLines(int day, bool removeEmptyLines)
        {
            var options = removeEmptyLines ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None;
            return AsString(day).Split('\n', options);
        }
    }

}
