using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode24
{
    internal class Day04() : DayBase("04")
    {
        public override string SolvePart1()
        {
            int xmasCount = 0;
            string[] lines = base.GetInputLines();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'X')
                    {
                        // check horizontally
                        if (j + 3 < line.Length) 
                        {
                            if (IsXmas([line[j], line[j + 1], line[j + 2], line[j + 3]])) xmasCount++;
                        }

                        // check horizontally backwards
                        if (j - 3 >= 0)
                        {
                            if (IsXmas([line[j], line[j - 1], line[j - 2], line[j - 3]])) xmasCount++;
                        }

                        // check vertically
                        if (i + 3 < lines.Length)
                        {
                            if (IsXmas([lines[i][j], lines[i + 1][j], lines[i + 2][j], lines[i + 3][j]])) xmasCount++;
                        }

                        // check vertically backwards
                        if (i - 3 >= 0)
                        {
                            if (IsXmas([lines[i][j], lines[i - 1][j], lines[i - 2][j], lines[i - 3][j]])) xmasCount++;
                        }

                        // check diagonal bottom-right
                        if (j + 3 < line.Length && i + 3 < lines.Length)
                        {
                            if (IsXmas([lines[i][j], lines[i + 1][j + 1], lines[i + 2][j + 2], lines[i + 3][j + 3]])) xmasCount++;
                        }

                        // check diagonal bottom-left
                        if (j - 3 >= 0 && i + 3 < lines.Length)
                        {
                            if (IsXmas([lines[i][j], lines[i + 1][j - 1], lines[i + 2][j - 2], lines[i + 3][j - 3]])) xmasCount++;
                        }

                        // check diagonal top-right
                        if (j + 3 < line.Length && i - 3 >= 0)
                        {
                            if (IsXmas([lines[i][j], lines[i - 1][j + 1], lines[i - 2][j + 2], lines[i - 3][j + 3]])) xmasCount++;
                        }

                        // check diagonal top-left
                        if (j - 3 >= 0 && i - 3 >= 0)
                        {
                            if (IsXmas([lines[i][j], lines[i - 1][j - 1], lines[i - 2][j - 2], lines[i - 3][j - 3]])) xmasCount++;
                        }
                    }
                }
            }

            return xmasCount.ToString();
        }

        public override string SolvePart2()
        {
            int masInXCount = 0;
            string[] lines = base.GetInputLines();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'A')
                    {
                        // If it can make an X
                        if (i + 1 < lines.Length && i - 1 >= 0 && j + 1 < line.Length && j - 1 >= 0)
                        {
                            // Checking for X
                                          // A
                                           // X
                            if (lines[i - 1][j - 1] == 'M' && lines[i + 1][j + 1] == 'S' || lines[i - 1][j - 1] == 'S' && lines[i + 1][j + 1] == 'M')
                            {
                                // Checking for X
                                //             A
                                //            X
                                if (lines[i - 1][j + 1] == 'M' && lines[i + 1][j - 1] == 'S' || lines[i - 1][j + 1] == 'S' && lines[i + 1][j - 1] == 'M')
                                {
                                    masInXCount++;
                                }
                            }
                        }
                    }
                }
            }

            return masInXCount.ToString();
        }

        private bool IsXmas(char[] chars)
        {
            if (chars.Length != 4) return false;
            if (chars[0] == 'X' && chars[1] == 'M' && chars[2] == 'A' && chars[3] == 'S') return true;
            if (chars[3] == 'X' && chars[2] == 'M' && chars[1] == 'A' && chars[0] == 'S') return true;
            return false;
        }
    }
}
