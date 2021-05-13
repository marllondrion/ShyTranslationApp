using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ShyTranslationApp.Core
{
    class TranslateService
    {
        public static void Main(string[] args)
        {
            string[] values = "Palavras para conversar ".Split('.', '!', '?');
            foreach(string v in values){
                if(v!=null && v.Length !=0)
                Console.WriteLine(Translate(v));
            }
            
        }

        public static String Translate(String word, string toLanguage = "en", string fromLanguage = "pt")
        {   
            string url = $"https://translate.googleapis.com/translate_a/single?client=gtx&sl={fromLanguage}&tl={toLanguage}&dt=t&q={HttpUtility.UrlEncode(word)}";
            var webClient = new WebClient
            {
                Encoding = System.Text.Encoding.UTF8
            };
            var result = webClient.DownloadString(url);
            try
            {
                result = result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                return result;
            }
            catch
            {
                return "Error";
            }
        }
    }
}
