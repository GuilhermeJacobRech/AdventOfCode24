using System.Reflection;

namespace AdventOfCode24
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Day03 day = new();
            var p1 = day.SolvePart1();
            var p2 = day.SolvePart2();

            Console.WriteLine($"P1: {p1}");
            Console.WriteLine($"P2: {p2}");
        }
    }
}
