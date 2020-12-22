using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ReturnPatchChangesInFile
    {
        public void class1(string filePath)
        {
            string result;
            using (var repo = new Repository(filePath))
            {
                List<Commit> CommitList = new List<Commit>();
                foreach (LogEntry entry in repo.Commits.QueryBy(filePath).ToList())
                    CommitList.Add(entry.Commit);
                CommitList.Add(null); // Added to show correct initial add

                int ChangeDesired = 0; // Change difference desired
                var repoDifferences = repo.Diff.Compare<Patch>((Equals(CommitList[ChangeDesired + 1], null)) ? null :
                    CommitList[ChangeDesired + 1].Tree, (Equals(CommitList[ChangeDesired], null)) ? null : CommitList[ChangeDesired].Tree);
                PatchEntryChanges file = null;
                try { file = repoDifferences.First(e => e.Path == filePath); }
                catch { } // If the file has been renamed in the past- this search will fail
                if (!Equals(file, null))
                {
                    result = file.Patch;
                    Console.WriteLine(result);
                }
            }
        }
    }
}
