using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode24
{
    public class Day02() : DayBase("02")
    {
        public override string SolvePart1()
        {
            var reports = base.GetInputLines();
            int safeCount = 0;

            foreach (var report in reports)
            {
                var levels = report.Split(' ');

                if (IsReportValid(levels)) safeCount++;
            }

            return safeCount.ToString();
        }

        public override string SolvePart2()
        {
            var reports = base.GetInputLines();
            int safeCount = 0;
            foreach (var report in reports)
            {
                // Get list of levels in report
                var levels = report.Split(' ');

                if (IsReportValid(levels))
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

                        if (IsReportValid(newReport))
                        {
                            safeCount++;
                            break;
                        }
                    }
                }

            }
            return safeCount.ToString();
        }

        private static bool IsReportValid(string[] levels)
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
