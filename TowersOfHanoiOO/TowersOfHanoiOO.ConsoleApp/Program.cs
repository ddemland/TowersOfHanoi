
using TowersOfHanoiOO.Library;

namespace TowersOfHanoiOO.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
          {
            const int maxDisks = 3;
            const int maxBoard = 3;
            var board = new ToHBoard();
            board.CreateBoard(maxBoard);
            board.InitStartPeg(0, maxDisks);
            board.SolveTowersConsoleOutput(maxDisks, 1, 3, 2);
        }
    }
}
