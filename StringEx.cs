using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IgnatParseEngine
{
    public static class StringEx
    {
        // text,tag => <tag>text</tag>
        public static string ToTag(this string s, string tag)
        {
            return $"<{tag}>{s}</{tag}>";
        }

        public static string JoinAll(this string[] arr, string separator)
        {
            return string.Join(separator, arr);
        }

        public static string ReFind(this string s, string pattern)
        {
            var regex = new Regex(pattern);
            var match = regex.Match(s);
            if (match.Success)
            {
                return match.Value;
            }
            return null;
        }

        public static string ReFindGroup(this string s, string pattern, string gpName)
        {
            var regex = new Regex(pattern);
            var match = regex.Match(s);
            if (match.Groups[gpName].Success)
            {
                return match.Groups[gpName].Value;
            }
            return null;
        }

        public static List<string> ReFindAll(this string s, string pattern)
        {
            var regex = new Regex(pattern);
            var match = regex.Match(s);
            var list = new List<string>();
            if (match.Success)
            {
                list.Add(match.Value);
                match = match.NextMatch();
            }
            return list;
        }

        public static string ReRemove(this string s, string pattern)
        {
            var regex = new Regex(pattern);
            return regex.Replace(s, "");
        }

        public static string ReReplace(this string s, string pattern, string replacement)
        {
            var regex = new Regex(pattern);
            return regex.Replace(s, replacement);
        }
    }
}
