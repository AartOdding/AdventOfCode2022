using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace aoc
{


    static class Day4
    {
        private struct Range
        {
            public Range(int f, int l)
            {
                first = f;
                last = l;
            }

            public bool Inside(Range other)
            {
                return first >= other.first && last <= other.last;
            }

            public bool Overlaps(Range other)
            {
                return first <= other.last && last >= other.first;
            }

            public int first;
            public int last;
        }

        private static Range ReadRange(string range)
        {
            var parts = range.Split('-');
            return new Range(int.Parse(parts[0]), int.Parse(parts[1]));
        }

        public static void Part1()
        {
            var lines = Input.AsLines(4, true);
            var result = 0;

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                var a = ReadRange(parts[0]);
                var b = ReadRange(parts[1]);
                if (a.Inside(b) || b.Inside(a))
                {
                    ++result;
                }
            }

            Console.WriteLine(result);
        }

        public static void Part2()
        {
            var lines = Input.AsLines(4, true);
            var result = 0;

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                var a = ReadRange(parts[0]);
                var b = ReadRange(parts[1]);
                if (a.Overlaps(b))
                {
                    ++result;
                }
            }

            Console.WriteLine(result);
        }
    }
}
