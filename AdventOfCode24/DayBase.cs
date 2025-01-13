using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode24
{
    public abstract class DayBase
    {
        private string Day { get; }

        public string InputPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Inputs/Day{Day}.txt");
        public string[] GetInputLines() => File.ReadAllLines(InputPath);

        /// <summary>
        /// dd format, '01' for day 1 for example.
        /// </summary>
        /// <param name="day"></param>
        public DayBase(string day)
        {
            this.Day = day;
        }

        public abstract string SolvePart1();
        public abstract string SolvePart2();
    }
}
