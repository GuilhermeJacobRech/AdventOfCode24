using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode24._03
{
    internal class Day03() : DayBase("03")
    {
        public void Solve()
        {
            // Read lines of input.txt
            var inputLines = File.ReadLines(base.InputPath);

            var ansP1 = SolvePart1(inputLines.ToArray());
            Console.WriteLine(ansP1);
        }

        private static int SolvePart1(string[] memorySections)
        {
            int sum = 0;
            string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
            foreach (var memorySec in memorySections)
            {
                Regex regex = new(pattern);
                var instructions = regex.Matches(memorySec);

                foreach (Match match in instructions)
                {
                    if (match.Success)
                    {
                        // First number (X)
                        string x = match.Groups[1].Value;
                        // Second number (Y)
                        string y = match.Groups[2].Value;

                        sum += int.Parse(x) * int.Parse(y);
                    }
                }
            }
            return sum;
        }

        private static int SolvePart2(string[] reports)
        {
            return 0;
        }

    }
}
