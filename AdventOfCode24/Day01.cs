using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode24
{
    internal class Day01() : DayBase("01")
    {
        public override string SolvePart1()
        {
            var (leftColumn, rightColumn) = ExtractColumns(base.GetInputLines());

            Array.Sort(leftColumn);
            Array.Sort(rightColumn);

            // Calculate distance
            int distance = 0;
            for (int j = 0; j < rightColumn.Length; j++)
            {
                distance += Math.Abs(leftColumn[j] - rightColumn[j]);
            }

            return distance.ToString();
        }

        public override string SolvePart2()
        {
            var (leftColumn, rightColumn) = ExtractColumns(base.GetInputLines());

            // Number:Appearances in right list
            Dictionary<int, int> dict = new();

            // Count how many appearances each number in the right list has
            for (int i = 0; i < rightColumn.Length; i++)
            {
                if (dict.TryGetValue(rightColumn[i], out _))
                {
                    dict[rightColumn[i]]++;
                }
                else
                {
                    dict[rightColumn[i]] = 1;
                }
            }

            // Calculate similarity score
            int similarityScore = 0;
            for (int j = 0; j < leftColumn.Length; j++)
            {
                if (dict.TryGetValue(leftColumn[j], out int appearances))
                {
                    similarityScore += leftColumn[j] * appearances;
                }
            }

            return similarityScore.ToString();
        }

        private static (int[] leftColumn, int[] rightColumn) ExtractColumns(string[] input)
        {
            var linesCount = input.Length;

            int[] leftColumn = new int[linesCount];
            int[] rightColumn = new int[linesCount];

            // Fill both arrays with its correspondent numbers
            int i = 0;
            foreach (var line in input)
            {
                var nums = line.Split("   ");

                int leftNum = int.Parse(nums[0]);
                int rightNum = int.Parse(nums[1]);

                leftColumn[i] = leftNum;
                rightColumn[i] = rightNum;

                i++;
            }

            return (leftColumn, rightColumn);
        }
    }
}
