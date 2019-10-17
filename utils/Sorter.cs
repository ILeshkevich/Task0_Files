using System;
using System.Collections.Generic;
using System.Linq;

namespace GithubFiles.utils
{
    public class Sorter
    {
        public static Dictionary<string, int> Sort(List<string> filesChanges)
        {
            var files = filesChanges.GroupBy(fC => fC).Select(f => new { Key = f.Key, Count = f.Count() });
            return files.OrderByDescending(a => a.Key).ToDictionary(o => o.Key, o => o.Count);
        }
    }
}
