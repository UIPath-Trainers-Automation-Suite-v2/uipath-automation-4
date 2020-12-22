using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //----------- input goes here ------------------------------
            //NOTE: only works for file paths and not urls
            string filePath = @"C:\Users\mannj\Documents\GitHub\rev_uipath_wrkspc\TeamPi-Project2";
            //----------------------------------------------------------

            //print repository file path name
            PrintRepositoryFilePathName print_rf = new PrintRepositoryFilePathName();
            print_rf.Print_RFPN(filePath);

            //Return changes in working directory
            //GIT EQUIV: gif diff
            ReturnChangesInWorkingDirectory return_cwd = new ReturnChangesInWorkingDirectory();
            return_cwd.ReturnCWD(filePath);
            Console.WriteLine("--------------------------------------------------------");

            //Return changes in index
            //GIT EQUIV: gif diff --cached
            ReturnChangesInIndex return_ci = new ReturnChangesInIndex();
            return_ci.ReturnCI(filePath);
            Console.WriteLine("--------------------------------------------------------");

            //Return changes in index and working directory
            //GIT EQUIV: git diff HEAD
            ReturnChangesInIndexAndWorkingDirectory return_ciwd = new ReturnChangesInIndexAndWorkingDirectory();
            return_ciwd.ReturnCIandWD(filePath);
            Console.WriteLine("--------------------------------------------------------");

            //Branch remote info
            BranchRemoteInfo bri = new BranchRemoteInfo();
            bri.RemoteBranchInfo(filePath);
            Console.WriteLine("--------------------------------------------------------");

            //git diff {filename} local.patch
            //GIT EQUIV: git diff myChangedFile.as > myChangedFile.patch
            GitDiffLocalPatchForFileName gitdiff_lp = new GitDiffLocalPatchForFileName();
            gitdiff_lp.GitDiffLPforFN(filePath);
            Console.WriteLine("--------------------------------------------------------");

            //Return patch changes in a specific file between commits
            //OUTPUT: Index was out of range. Must be non-negative and less than the size of the collection. 
            /*ReturnPatchChangesInFile c = new ReturnPatchChangesInFile();
            c.class1(filePath);*/

            //indicate end of sequence
            Console.WriteLine("End of Run");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------");
        }
    }
}
