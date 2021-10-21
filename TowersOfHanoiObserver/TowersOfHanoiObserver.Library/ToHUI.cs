using System;
using System.Threading;

namespace TowersOfHanoiObserver.Library
{
    public class ToHUI
    {
        public void Subscribe(ToHBoard m)
        {
            m.Display += DrawBoard;
        }

        public void DrawBoard(ToHBoard board) // draw board
        {
            Console.Clear();
            DrawPeg(20, board.Pegs[0].Disks.Count);
            DrawPeg(40, board.Pegs[1].Disks.Count);
            DrawPeg(60, board.Pegs[2].Disks.Count);
            Thread.Sleep(1000);
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
                y++;
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
