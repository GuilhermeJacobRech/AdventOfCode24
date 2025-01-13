using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode24
{
    internal class Day03() : DayBase("03")
    {
        public override string SolvePart1()
        {
            var memories = base.GetInputLines();
            return CalculateInstructions(memories).ToString();
        }

        public override string SolvePart2()
        {
            var memories = base.GetInputLines();
            string[] filteredMemories = new string[memories.Length];
            int i = 0;
            bool isEnabled = true;

            foreach (var memory in memories)
            {
                string temp = "";
                string lastSevenChars = "";

                foreach (char c in memory)
                {
                    if (lastSevenChars.Contains("don't()")) isEnabled = false;
                    if (lastSevenChars.Contains("do()")) isEnabled = true;

                    if (isEnabled)
                    {
                        // Insert current char at the end the temp string
                        temp = temp.Insert(temp.Length, c.ToString());
                    }

                    if (lastSevenChars.Length > 6)
                    {
                        // Remove the char at the begining of lastSevenChars
                        lastSevenChars = lastSevenChars.Remove(0, 1);
                    }
                    // Add current char at the end of lastSevenChars
                    lastSevenChars = lastSevenChars.Insert(lastSevenChars.Length, c.ToString());

                }
                filteredMemories[i] = temp;
                i++;
            }

            return CalculateInstructions(filteredMemories).ToString();
        }

        private static int CalculateInstructions(string[] memories)
        {
            int sum = 0;
            string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
            foreach (var memory in memories)
            {
                Regex regex = new(pattern);
                MatchCollection matches = regex.Matches(memory);

                foreach (Match match in matches)
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
    }
}
