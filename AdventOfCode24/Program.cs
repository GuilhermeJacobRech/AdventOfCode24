using System.Reflection;

namespace AdventOfCode24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            _03.Day03 day03 = new();
            day03.Solve();

            string lastSevenChars = "don't()";
            bool isEnabled = true;
            if (lastSevenChars.Contains("don't()")) isEnabled = false;
            if (lastSevenChars.Contains("do()")) isEnabled = true;
            Console.WriteLine(isEnabled);
        }
        
    }
}
