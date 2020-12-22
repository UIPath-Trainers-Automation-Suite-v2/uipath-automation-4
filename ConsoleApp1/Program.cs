using System;
using LibGit2Sharp;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------- input goes here ------------------------------
            string filePath = @"C:\Users\mannj\Documents\uipath-automation-4";
            //string filePath = @"C:\Users\mannj\Documents\GitHub\rev_uipath_wrkspc\MannJames-code";
            //----------------------------------------------------------

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Repository File Path:");
            Console.WriteLine(filePath);
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------");

            //Return changes in working directory
            Console.WriteLine("Return changes in working directory...");
            using (var repo = new Repository(filePath))
            {
                foreach (TreeEntryChanges c in repo.Diff.Compare<TreeChanges>())
                {
                    Console.WriteLine(c);
                }
            }
            Console.WriteLine("--------------------------------------------------------");

            //Return changes in index
            Console.WriteLine("Return changes in index...");
            using (var repo = new Repository(filePath))
            {
                foreach (TreeEntryChanges c in repo.Diff.Compare<TreeChanges>(repo.Head.Tip.Tree,
                                                              DiffTargets.Index))
                {
                    Console.WriteLine(c);
                }
            }
            Console.WriteLine("--------------------------------------------------------");

            //Return changes in index and working directory
            Console.WriteLine("Changes in index and working directory...");
            using (var repo = new Repository(filePath))
            {
                foreach (TreeEntryChanges c in repo.Diff.Compare<TreeChanges>(repo.Head.Tip.Tree,
                                                              DiffTargets.Index | DiffTargets.WorkingDirectory))
                {
                    Console.WriteLine(c);
                }
            }
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------");

            var repo1 = new Repository(filePath);
            //Branch remote info
            foreach (var item in repo1.Branches)
            {
                Console.WriteLine("Remote Name: "+ item.RemoteName);
                Console.WriteLine("Local connected to remote: " + item.IsTracking);
                Console.WriteLine("Instance is remote: " + item.IsRemote);
                Console.WriteLine("Reference: " + item.Reference);
                Console.WriteLine("Remote branch connected to local (if any): " + item.TrackedBranch);
                Console.WriteLine("Additional remote branch info: " + item.TrackingDetails);
                Console.WriteLine("Upstream branch name: " + item.UpstreamBranchCanonicalName);
                Console.WriteLine("--------------------------------------------------------");
            }
            Console.WriteLine("--------------------------------------------------------");

            //git diff {filename} local.patch
            foreach (var item in repo1.RetrieveStatus())
            {
/*                if (item.State == FileStatus.Modified)
                {*/
                var patch = repo1.Diff.Compare<Patch>(new List<string>() { item.FilePath });
                Console.WriteLine("~~~~ Patch file ~~~~");
                Console.WriteLine(patch.Content);
                //}
                Console.WriteLine("--------------------------------------------------------");
            }
            Console.WriteLine("--------------------------------------------------------");

            Console.WriteLine("End of Run");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------");

        }
    }
}
