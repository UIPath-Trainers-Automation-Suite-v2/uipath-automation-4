using LibGit2Sharp;
using System;

namespace ConsoleApp1
{
    public class ReturnChangesInWorkingDirectory
    {
        public void ReturnCWD(string filePath)
        {
            Console.WriteLine("Return changes in working directory...");
            using (var repo = new Repository(filePath))
            {
                foreach (TreeEntryChanges c in repo.Diff.Compare<TreeChanges>())
                {
                    Console.WriteLine(c);
                }
            }
        }
    }
}
