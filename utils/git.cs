using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GithubFiles.utils
{
    class Git
    {
        static public void Clone(string url, string login, string pass, string path)
        {
            try
            {
                var co = new CloneOptions();
                co.CredentialsProvider = (_url, _user, _cred) => new UsernamePasswordCredentials { Username = login, Password = pass };
                Console.WriteLine("Cloning...");
                Repository.Clone(url, path, co);
                Console.WriteLine("Comlite");
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }


        static public void Log(string path, List<string> files)
        {
            using (var repo = new Repository(path))
            {
                foreach (var commit in repo.Commits)
                {
                    foreach (var parent in commit.Parents)
                    {
                        foreach (TreeEntryChanges change in repo.Diff.Compare<TreeChanges>(parent.Tree, commit.Tree))
                        {
                            files.Add(change.Path);
                        }
                    }
                }
            }
        }
    }
}


