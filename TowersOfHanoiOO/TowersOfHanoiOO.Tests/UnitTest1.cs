using NUnit.Framework;
using TowersOfHanoiOO.Library;

namespace TowersOfHanoiOO.Tests
{
    public class Tests
    {
        [Test]
        public void TestPeg()
        {
            var peg = new ToHPeg();
            Assert.AreEqual(0, peg.Disks.Count);
            peg.PopDisk();
            Assert.AreEqual(0, peg.Disks.Count);

            peg.PushDisk(2);
            Assert.AreEqual(1, peg.Disks.Count);
            Assert.AreEqual(2, peg.Disks[0]);

            peg.PushDisk(1);
            Assert.AreEqual(2, peg.Disks.Count);
            Assert.AreEqual(2, peg.Disks[0]);
            Assert.AreEqual(1, peg.Disks[1]);

            peg.PopDisk();
            Assert.AreEqual(1, peg.Disks.Count);
            Assert.AreEqual(1, peg.Disks[0]);

            peg.ClearPeg();
            Assert.AreEqual(0, peg.Disks.Count);
        }

        [Test]
        public void TestBoard()
        {
            var board = new ToHBoard();
            Assert.AreEqual(0, board.Pegs.Count);

            board.CreateBoard(3);
            Assert.AreEqual(3, board.Pegs.Count);
            Assert.AreEqual(0, board.Pegs[0].Disks.Count);
            Assert.AreEqual(0, board.Pegs[1].Disks.Count);
            Assert.AreEqual(0, board.Pegs[2].Disks.Count);

            board.InitStartPeg(0, 3);
            Assert.AreEqual(3, board.Pegs[0].Disks.Count);
            Assert.AreEqual(0, board.Pegs[1].Disks.Count);
            Assert.AreEqual(0, board.Pegs[2].Disks.Count);
            Assert.AreEqual(1, board.Pegs[0].Disks[0]);
            Assert.AreEqual(2, board.Pegs[0].Disks[1]);
            Assert.AreEqual(3, board.Pegs[0].Disks[2]);
        }
    }
}