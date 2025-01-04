using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode24._01
{
    internal class Day01() : DayBase("01")
    {
        public void Solve()
        {
            // Read lines of input.txt
            var inputLines = File.ReadLines(base.InputPath);
            var linesCount = inputLines.Count();

            // Initiate arrays with size of how many lines in input.txt
            int[] leftNums = new int[linesCount];
            int[] rightNums = new int[linesCount];

            // Fill both arrays with its correspondent numbers
            int i = 0;
            foreach (var line in inputLines)
            {
                var nums = line.Split("   ");

                int leftNum = int.Parse(nums[0]);
                int rightNum = int.Parse(nums[1]);

                leftNums[i] = leftNum;
                rightNums[i] = rightNum;

                i++;
            }

            var ansP1 = SolvePart1(leftNums, rightNums);
            var ansP2 = SolvePart2(leftNums, rightNums);

            Console.WriteLine($"Day 01 Answer Part 1: {ansP1}");
            Console.WriteLine($"Day 02 Answer Part 2: {ansP2}");
        }

        private static int SolvePart1(int[] leftNums, int[] rightNums)
        {
            // Sort both arrays
            Helpers.QuickSort(leftNums, 0, leftNums.Length - 1);
            Helpers.QuickSort(rightNums, 0, rightNums.Length - 1);

            // Calculate distance
            int distance = 0;
            for (int j = 0; j < rightNums.Length; j++)
            {
                distance += Math.Abs(leftNums[j] - rightNums[j]);
            }

            return distance;
        }

        private static int SolvePart2(int[] leftNums, int[] rightNums)
        {
            // Number:Appearances in right list
            Dictionary<int, int> dict = new();

            // Count how many appearances each number in the right list has
            for (int i = 0; i < rightNums.Length; i++)
            {
                if (dict.TryGetValue(rightNums[i], out _))
                {
                    dict[rightNums[i]]++;
                }
                else
                {
                    dict[rightNums[i]] = 1;
                }
            }

            // Calculate similarity score
            int similarityScore = 0;
            for (int j = 0; j < leftNums.Length; j++)
            {
                if (dict.TryGetValue(leftNums[j], out int appearances))
                {
                    similarityScore += leftNums[j] * appearances;
                }
            }

            return similarityScore;
        }
    }
}
