using System;
using System.Collections.Generic;
using System.Linq;

namespace GithubFiles.Utils
{
    public class Sorter
    {
        public static Dictionary<string, int> GroupByFileName(List<string> filesChanges)
        {
            return filesChanges.GroupBy(fC => fC).Select(f => new { Key = f.Key, Count = f.Count() }).ToDictionary(o => o.Key, o => o.Count);
        }
    }
}
