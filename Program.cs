using System;
using LibGit2Sharp;
using System.IO;
using GithubFiles.utils;
using System.Collections.Generic;
using System.Linq;

namespace GithubFiles
{
    class Program
    {
        private static readonly List<string> filesChanges = new List<string>();
        private const string login = "fileTracker";
        private const string pass = "trackerpass1";
        private static string path = Environment.CurrentDirectory + "\\Repo";
        static void Main(string[] args)
        {
            DeleteDirectory(path);
            Console.Clear();
            Console.WriteLine("Input reository url \nFor example(https://github.com/ILeshkevuch/test.git)");
            var url = Console.ReadLine();

            Git.Clone(url,login,pass,path);

            Git.Log(path, filesChanges);

            Print(Sort());

            DeleteDirectory(path);
        }

        public static void DeleteDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                return;
            }

            var files = Directory.GetFiles(directoryPath);
            var directories = Directory.GetDirectories(directoryPath);

            foreach (var file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (var dir in directories)
            {
                DeleteDirectory(dir);
            }

            File.SetAttributes(directoryPath, FileAttributes.Normal);

            Directory.Delete(directoryPath,false);
        }

        private static void Print(Dictionary<string,int> files)
        {
            foreach (var file in files)
            {
                int i = 1;
                Console.WriteLine($"{i + 1}:{file.Key} -- {file.Value}");
                if (i == 10) break;
            }
        }

        private static Dictionary<string,int> Sort()
        {
            var files = filesChanges.GroupBy(fC => fC).Select(f => new { Key = f.Key, Count = f.Count() });
            return files.OrderByDescending(a => a.Key).ToDictionary(o => o.Key, o => o.Count);
        }
    
    }
}
