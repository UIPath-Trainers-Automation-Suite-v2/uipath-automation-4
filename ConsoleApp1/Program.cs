using System;
using LibGit2Sharp;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\mannj\Documents\uipath-automation-4";

            //Return changes in working directory
            using (var repo = new Repository(filePath))
            {
                foreach (TreeEntryChanges c in repo.Diff.Compare<TreeChanges>())
                {
                    Console.WriteLine(c);
                }
            }

            //Return changes in index
            using (var repo = new Repository(filePath))
            {
                foreach (TreeEntryChanges c in repo.Diff.Compare<TreeChanges>(repo.Head.Tip.Tree,
                                                              DiffTargets.Index))
                {
                    Console.WriteLine(c);
                }
            }

            //Return changes in index and working directory
            using (var repo = new Repository(filePath))
            {
                foreach (TreeEntryChanges c in repo.Diff.Compare<TreeChanges>(repo.Head.Tip.Tree,
                                                              DiffTargets.Index | DiffTargets.WorkingDirectory))
                {
                    Console.WriteLine(c);
                }
            }


            //git diff {filename} local.patch
            var repo1 = new Repository(filePath);
            foreach (var item in repo1.RetrieveStatus())
            {
/*                if (item.State == FileStatus.Modified)
                {*/
                    var patch = repo1.Diff.Compare<Patch>(new List<string>() { item.FilePath });
                    Console.WriteLine("~~~~ Patch file ~~~~");
                    Console.WriteLine(patch.Content);
                //}
            }

        }
    }
}
