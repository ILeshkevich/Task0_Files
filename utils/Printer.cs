using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GithubFiles.Utils
{
    public class Printer
    {
        public static void PrintMostPopularFiles(Dictionary<string, int> files)
        {
            int i = 1;
            foreach (var file in files.OrderByDescending(a => a.Value).ThenBy(a => a.Key))
            {
                Console.WriteLine($"{i}:{file.Key} -- {file.Value}");
                if (i == 10)
                {
                    break;
                }

                i++;
            }
        }
    }
}
