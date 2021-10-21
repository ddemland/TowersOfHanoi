
using System.Collections.Generic;

namespace TowersOfHanoiOO.Library
{
    public class ToHPeg
    {
        public List<int> Disks { get; set; }

        public ToHPeg()
        {
            Disks = new List<int>();
        }

        public void ClearPeg()
        {
            Disks.Clear();
        }

        public void PushDisk(int diskNum)
        {
            Disks.Add(diskNum);
        }

        public void PopDisk()
        {
            if (Disks.Count == 0)
            {
                return;
            }

            Disks.RemoveAt(0);
        }
    }
}
