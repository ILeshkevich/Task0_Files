using System;
using System.Collections.Generic;
using LibGit2Sharp;

namespace GithubFiles.Utils
{
    public class Git
    {
        public static void Clone(string url, string login, string pass, string path)
        {
            try
            {
                var co = new CloneOptions();
                co.CredentialsProvider = (url1, user, cred) => new UsernamePasswordCredentials { Username = login, Password = pass };
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

        public static void Log(string path, List<string> files)
        {
            try
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

                        if (files.Count == 0)
                        {
                            foreach (var file in commit.Tree)
                            {
                                files.Add(file.Path);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
            }
        }
    }
}
