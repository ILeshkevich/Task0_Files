using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using GithubFiles.Utils;

namespace GithubFiles
{
    internal class Program
    {
        private static readonly List<string> filesChanges = new List<string>();
        private static string path = Environment.CurrentDirectory + "\\Repo";

        private static void Main(string[] args)
        {
            DeleteDirectory(path);

            Console.Write("Input\n" +
                "Github login: ");
            var login = Console.ReadLine();
            Console.Write("Github password: ");
            var pass = Console.ReadLine();
            Console.WriteLine("Input reository url \n" +
                "For example(https://github.com/ILeshkevuch/test.git)");
            var url = Console.ReadLine();

            Git.Clone(url, login, pass, path);
            Git.Log(path, filesChanges);

            Printer.PrintMostPopularFiles(Sorter.GroupByFileName(filesChanges));

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

            Directory.Delete(directoryPath, false);
        }
    }
}
