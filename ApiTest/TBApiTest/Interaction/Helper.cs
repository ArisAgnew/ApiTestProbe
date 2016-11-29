using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using RestSharp;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Collections;

namespace TBApiTest.Interaction
{
    public static class Helper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="replace1"></param>
        /// <param name="replace2"></param>
        /// <param name="trimChars"></param>
        /// <returns></returns>
        public static string TrimAndDoubleReplace(this string o, string replace1, string replace2, params char[] trimChars)
            => o.Trim(trimChars).Replace(Environment.NewLine, replace1).Replace(" ", replace2);


        internal static void Serialize<T>(this T arg, string fileName)
        {
            string res = JsonConvert.SerializeObject(arg, Formatting.Indented);
            File.WriteAllText(fileName, res);
        }

        internal static T Deserialize<T>(string fileName)
        {
            string json = File.ReadAllText(fileName);
            T res = JsonConvert.DeserializeObject<T>(json);
            return res;
        }
    }
}
