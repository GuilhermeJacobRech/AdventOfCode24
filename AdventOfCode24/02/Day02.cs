using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode24._02
{
    public class Day02() : DayBase("02")
    {
        public void Solve()
        {
            // Read lines of input.txt
            var inputLines = File.ReadLines(base.InputPath);

            //var ansP1 = SolvePart1(inputLines.ToArray());
            var ansP2 = SolvePart2(inputLines.ToArray());
            //Console.WriteLine(ansP1);
            Console.WriteLine(ansP2);
        }

        private static int SolvePart1(string[] reports)
        {
            int safeCount = 0;
            foreach (var report in reports)
            {
                // Get list of levels in report
                var levels = report.Split(' ');

                if (isReportValid(levels)) safeCount++;
            }
            return safeCount;
        }

        private static int SolvePart2(string[] reports)
        {
            int safeCount = 0;
            foreach (var report in reports)
            {
                // Get list of levels in report
                var levels = report.Split(' ');

                if (isReportValid(levels))
                {
                    safeCount++;
                    continue;
                }
                else
                {
                    for (int i = 0; i < levels.Length; i++)
                    {
                        // Create newReport excluding the element at index i
                        string[] newReport = levels.Where((_, index) => index != i).ToArray();

                        if (isReportValid(newReport))
                        {
                            safeCount++;
                            break;
                        }
                    }
                }
                
            }
            return safeCount;
        }

        private static bool isReportValid(string[] levels)
        {
            bool isIncreasing = true;
            bool isSafe = true;

            // For each level in report
            for (int i = 0; i < levels.Length - 1; i++)
            {
                int currentNum = int.Parse(levels[i]);
                int nextNum = int.Parse(levels[i + 1]);

                // Check if report is increasing or decreasing
                if (i == 0)
                {
                    if (currentNum > nextNum)
                    {
                        isIncreasing = false;
                    }
                }

                if (Math.Abs(currentNum - nextNum) < 1) isSafe = false;
                if (Math.Abs(currentNum - nextNum) > 3) isSafe = false;
                if (isIncreasing && currentNum > nextNum) isSafe = false;
                if (!isIncreasing && currentNum < nextNum) isSafe = false;
            }

            return isSafe;
        }
    }
}
