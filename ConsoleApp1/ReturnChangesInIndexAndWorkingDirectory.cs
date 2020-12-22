using LibGit2Sharp;
using System;

namespace ConsoleApp1
{
    public class ReturnChangesInIndexAndWorkingDirectory
    {
        public void ReturnCIandWD(string filePath)
        {
            Console.WriteLine("Changes in index and working directory...");
            using (var repo = new Repository(filePath))
            {
                foreach (TreeEntryChanges c in repo.Diff.Compare<TreeChanges>(repo.Head.Tip.Tree,
                                                              DiffTargets.Index | DiffTargets.WorkingDirectory))
                {
                    Console.WriteLine(c);
                }
            }
        }
    }
}
