using LibGit2Sharp;
using System;

namespace ConsoleApp1
{
    class ReturnChangesInIndex
    {
        public void ReturnCI(string filePath)
        {
            Console.WriteLine("Return changes in index...");
            using (var repo = new Repository(filePath))
            {
                foreach (TreeEntryChanges c in repo.Diff.Compare<TreeChanges>(repo.Head.Tip.Tree,
                                                              DiffTargets.Index))
                {
                    Console.WriteLine(c);
                }
            }
        }

    }
}
