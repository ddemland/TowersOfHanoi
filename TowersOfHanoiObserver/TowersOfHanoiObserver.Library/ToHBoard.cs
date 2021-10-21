using System;
using System.Collections.Generic;

namespace TowersOfHanoiObserver.Library
{
    public class ToHBoard
    {
        public event DisplayHandler Display;
        public delegate void DisplayHandler(ToHBoard board);

        public List<ToHPeg> Pegs { get; private init; }

        public static void Run()
        {
            var gameUI = new ToHUI();
            var tohGame = new ToHBoard
            {
                Pegs = new List<ToHPeg>()
            };
            gameUI.Subscribe(tohGame);
            tohGame.Start(tohGame);
        }

        public void Start(ToHBoard board)
        {
            const int MaxDisks = 3;
            const int MaxBoard = 3;
            board.CreateBoard(MaxBoard);
            board.InitStartPeg(0, MaxDisks);
            board.SolveTowersConsoleOutput(MaxDisks, 1, 3, 2);
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
            if (diskNum <= 0)
            {
                return;
            }

            SolveTowersConsoleOutput(diskNum - 1, startPeg, tempPeg, endPeg);
            Pegs[startPeg - 1].PopDisk();
            Pegs[endPeg - 1].PushDisk(diskNum);

            Display(this);
            SolveTowersConsoleOutput(diskNum - 1, tempPeg, endPeg, startPeg);
        }

        public void SolveTowers(int diskNum, int startPeg, int endPeg, int tempPeg)
        {
            if (diskNum != 1)
            {
                SolveTowers(diskNum - 1, startPeg, tempPeg, endPeg);
            }
        }
    }
}
