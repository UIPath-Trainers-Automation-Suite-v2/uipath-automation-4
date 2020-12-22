using LibGit2Sharp;
using System;

namespace ConsoleApp1
{
    class BranchRemoteInfo
    {
        public void RemoteBranchInfo(string filePath)
        {
            var repo = new Repository(filePath);
            foreach (var item in repo.Branches)
            {
                Console.WriteLine("Remote Name: " + item.RemoteName);
                Console.WriteLine("Local connected to remote: " + item.IsTracking);
                Console.WriteLine("Instance is remote: " + item.IsRemote);
                Console.WriteLine("Reference: " + item.Reference);
                Console.WriteLine("Remote branch connected to local (if any): " + item.TrackedBranch);
                Console.WriteLine("Additional remote branch info: " + item.TrackingDetails);
                Console.WriteLine("Upstream branch name: " + item.UpstreamBranchCanonicalName);
                Console.WriteLine("--------------------------------------------------------");
            }
        }
    }
}
