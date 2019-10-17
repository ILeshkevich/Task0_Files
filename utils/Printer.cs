using System;
using System.Collections.Generic;
using System.Text;

namespace GithubFiles.utils
{
    public class Printer
    {
        public static void Print(Dictionary<string, int> files)
        {
            int i = 1;
            foreach (var file in files)
            {
                Console.WriteLine($"{i}:{file.Key} -- {file.Value}");
                if (i == 10) break;
                i++;
            }
        }
    }
}
