using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace aoc
{
    static class Day7
    {
        class Dir
        {
            public readonly string name;
            public readonly Dir parent;
            public readonly Dictionary<string, Dir> children;
            public readonly Dictionary<string, int> files;

            public Dir(string name, Dir parent)
            {
                this.name = name;
                this.parent = parent;
                this.children = new Dictionary<string, Dir>();
                this.files = new Dictionary<string, int>();
            }

            public Dir GetOrCreateChild(string name)
            {
                if (!children.ContainsKey(name))
                {
                    var child = new Dir(name, this);
                    children.Add(name, child);
                    return child;
                }
                return children[name];
            }

            public void AddFile(string name, int size)
            {
                files.Add(name, size);
            }

            public int GetSize(bool recursive)
            {
                int size = 0;
                foreach (var (n, s) in files)
                {
                    size += s;
                }
                if (recursive)
                {
                    foreach (var (n, c) in children)
                    {
                        size += c.GetSize(recursive);
                    }
                }
                return size;
            }

        }

        private static void GetDirectoriesSmallerThan(Dir dir, int maxSize, List<Dir> result)
        {
            if (dir.GetSize(true) <= maxSize)
            {
                result.Add(dir);
            }
            foreach (var (n, c) in dir.children)
            {
                GetDirectoriesSmallerThan(c, maxSize, result);
            }
        }

        private static Dir ParseDirectories(string[] input)
        {
            Dir root = new Dir("", null);
            Dir current = root;

            foreach (var line in input)
            {
                if (line == "$ cd /")
                {
                    current = root;
                }
                else if (line == "$ cd ..")
                {
                    current = current.parent;
                }
                else if (line.StartsWith("$ cd "))
                {
                    var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                    current = current.GetOrCreateChild(parts[2]);
                }
                else if (line.StartsWith("$ ls"))
                {

                }
                else if (line.StartsWith("dir "))
                {

                }
                else
                {
                    var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                    current.AddFile(parts[1], int.Parse(parts[0]));
                }
            }
            return root;
        }

        public static void Part1()
        {
            var input = Input.AsLines(7, true);
            var root = ParseDirectories(input);

            List<Dir> dirs = new List<Dir>();
            GetDirectoriesSmallerThan(root, 100000, dirs);

            int total = 0;

            foreach (Dir dir in dirs)
            {
                total += dir.GetSize(true);
            }

            Console.WriteLine(total);
        }

        private static void FlattenDirectories(Dir dir, List<Dir> result)
        {
            result.Add(dir);
            foreach (var (_, child) in dir.children)
            {
                FlattenDirectories(child, result);
            }
        }

        public static void Part2()
        {
            var input = Input.AsLines(7, true);
            var root = ParseDirectories(input);
            var rootSize = root.GetSize(true);
            var freeSpace = 70000000 - rootSize;
            var spaceRequired = 30000000 - freeSpace;

            List<Dir> flattenedList = new List<Dir>();
            FlattenDirectories(root, flattenedList);
            flattenedList.Sort((lhs, rhs) => lhs.GetSize(true).CompareTo(rhs.GetSize(true)));

            foreach(var dir in flattenedList)
            {
                if (dir.GetSize(true) >= spaceRequired)
                {
                    Console.WriteLine(dir.GetSize(true));
                    break;
                }
            }
        }
    }
}
