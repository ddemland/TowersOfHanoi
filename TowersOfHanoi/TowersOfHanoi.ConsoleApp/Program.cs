
using System;

namespace TowersOfHanoi.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
          {
            const int maxDisks = 3;
            SolveTowersConsoleOutput(maxDisks, 1, 3, 2);
        }

        public static void SolveTowersConsoleOutput(int diskNum, int startPeg, int endPeg, int tempPeg)
        {
            if (diskNum > 0)
            {
                SolveTowersConsoleOutput(diskNum - 1, startPeg, tempPeg, endPeg);
                Console.WriteLine($"Disc {diskNum} from {startPeg} to {endPeg}");
                SolveTowersConsoleOutput(diskNum - 1, tempPeg, endPeg, startPeg);
            }
        }
    }
}
