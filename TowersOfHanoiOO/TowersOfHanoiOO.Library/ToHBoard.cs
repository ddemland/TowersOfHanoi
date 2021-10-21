using System;
using System.Collections.Generic;
using System.Threading;

namespace TowersOfHanoiOO.Library
{
    public class ToHBoard
    {
        public List<ToHPeg> Pegs { get; set; }

        public ToHBoard()
        {
            Pegs = new List<ToHPeg>();
        }

        public void CreateBoard(int numPegs)
        {
            for (var cnt = 0; cnt < numPegs; cnt ++)
            {
                Pegs.Add(new ToHPeg());
            }
        }

        public void InitStartPeg(int startPeg, int numDisks)
        {
            ClearAllPegs();
            for (var cnt = 0; cnt < numDisks; cnt ++)
            {
                Pegs[startPeg].Disks.Add(cnt + 1);
            }
        }

        public void ClearAllPegs()
        {
            foreach (var peg in Pegs)
            {
                peg.ClearPeg();
            }
        }

        public void SolveTowersConsoleOutput(int diskNum, int startPeg, int endPeg, int tempPeg)
        {
            if (diskNum > 0)
            {
                SolveTowersConsoleOutput(diskNum - 1, startPeg, tempPeg, endPeg);
                Pegs[startPeg - 1].PopDisk();
                Pegs[endPeg - 1].PushDisk(diskNum);
                Console.Clear();
                DrawPeg(20, Pegs[0].Disks.Count);
                DrawPeg(40, Pegs[1].Disks.Count);
                DrawPeg(60, Pegs[2].Disks.Count);
                Thread.Sleep(1000);
                SolveTowersConsoleOutput(diskNum - 1, tempPeg, endPeg, startPeg);
            }
        }

        public void SolveTowers(int diskNum, int startPeg, int endPeg, int tempPeg)
        {
            if (diskNum != 1)
            {
                SolveTowers(diskNum - 1, startPeg, tempPeg, endPeg);
            }
        }

        private void DrawPeg(int x, int numberOfRings = 0)
        {
            var y = 3;
            const int pegheight = 8;
            for (var i = pegheight; i >= 1; i--)
            {
                var halfRing = new string(' ', i);
                if (numberOfRings > 0)
                {
                    if (i <= numberOfRings)
                        halfRing = new string('-', numberOfRings - i + 1);

                }

                Console.SetCursorPosition(x - halfRing.Length * 2 + i + (halfRing.Contains("-") ? (-i + halfRing.Length) : 0), y);
                Console.WriteLine(halfRing + "|" + halfRing);
                y ++;
            }

            if (x < 7)
            {
                x = 7;
            }


            Console.SetCursorPosition(x - 7, y); // print the base
            Console.WriteLine("----------------");
        }
    }
}
