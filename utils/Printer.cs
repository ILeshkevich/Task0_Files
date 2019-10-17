using System;
using System.Collections.Generic;
using System.Text;

namespace GithubFiles.utils
{
    public class Printer
    {
        public static void Print(Dictionary<string, int> files)
        {
            foreach (var file in files)
            {
                int i = 1;
                Console.WriteLine($"{i + 1}:{file.Key} -- {file.Value}");
                if (i == 10) break;
            }
        }
    }
}
