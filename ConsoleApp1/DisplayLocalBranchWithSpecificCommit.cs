using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class DisplayLocalBranchWithSpecificCommit
    {
        public void DisplaySpecificCommit(string filePath, string commitSha)
        {
            using (var repo = new Repository(filePath))
            {
                foreach (Branch b in ListBranchesContainingCommit(repo, commitSha))
                {
                    Console.WriteLine(b.CanonicalName);
                }
            }

            IEnumerable<Branch> ListBranchesContainingCommit(Repository repo, string commitSha)
            {
                var localHeads = repo.Refs.Where(r => r.IsLocalBranch);

                var commit = repo.Lookup<Commit>(commitSha);
                var localHeadsContainingTheCommit = repo.Refs.ReachableFrom(localHeads, new[] { commit });

                return localHeadsContainingTheCommit
                    .Select(branchRef => repo.Branches[branchRef.CanonicalName]);
            }
        }
    }
}
