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

            Printer.Print(Sorter.Sort(filesChanges));

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

        

        
    
    }
}
