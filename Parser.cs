using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IgnatParseEngine
{
    public static class Parser
    {
        public static string GetPageSource(string url)
        {
            var req = WebRequest.Create(url);
            var res = req.GetResponse();
            string result;
            using (var sr = new StreamReader(res.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }
            res.Close();
            return result;
        }

        public static void SavePageSource(string url, string path)
        {
            var req = WebRequest.Create(url);
            var res = req.GetResponse();
            using (var sr = new StreamReader(res.GetResponseStream()))
            {
                using (var sw = new StreamWriter(path, false, Encoding.UTF8))
                {
                    sw.Write(sr.ReadToEnd());
                    sw.Close();
                }
                sr.Close();
            }
            res.Close();
        }

        public static IHtmlDocument GetPageDocument(string url)
        {
            var req = WebRequest.Create(url);
            var res = req.GetResponse();
            string result;
            using (var sr = new StreamReader(res.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }
            res.Close();
            var parser = new HtmlParser();
            return parser.ParseDocument(result);
        }
    }
}
