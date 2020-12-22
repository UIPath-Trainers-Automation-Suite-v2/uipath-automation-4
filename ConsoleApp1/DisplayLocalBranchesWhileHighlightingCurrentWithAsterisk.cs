using LibGit2Sharp;
using System;
using System.Linq;

namespace ConsoleApp1
{
    public class DisplayLocalBranchesWhileHighlightingCurrentWithAsterisk
    {
        public void HighlightCurrentBranch(string filePath)
        {
            using (var repo = new Repository(filePath))
            {
                foreach (Branch b in repo.Branches.Where(b => !b.IsRemote))
                {
                    Console.WriteLine(string.Format("{0}{1}", b.IsCurrentRepositoryHead ? "*" : " ", b.FriendlyName));
                }
            }
        }
    }
}
