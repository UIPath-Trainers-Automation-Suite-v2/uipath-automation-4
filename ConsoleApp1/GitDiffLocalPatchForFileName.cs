using LibGit2Sharp;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class GitDiffLocalPatchForFileName
    {
        public void GitDiffLPforFN(string filePath)
        {
            var repo = new Repository(filePath);
            foreach (var item in repo.RetrieveStatus())
            {
                /*                if (item.State == FileStatus.Modified)
                                {*/
                var patch = repo.Diff.Compare<Patch>(new List<string>() { item.FilePath });
                Console.WriteLine("~~~~ Patch file ~~~~");
                Console.WriteLine(patch.Content);
                //}
                Console.WriteLine("--------------------------------------------------------");
            }
        }
    }
}
