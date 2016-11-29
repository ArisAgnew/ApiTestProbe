using System;
using System.Collections.Generic;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

using TBApiTest.Models;
using TBApiTest.Base;
using TBApiTest.Interaction;

namespace TBApiTest.Tests.GetTests
{
    [TestFixture]
    public class CurrencyRatesTests
    {
        [Test]
        public void CheckThatJsonObjectsSuchAsFromCurrencyAndToCurrencyShouldMatchToCodeAndNameValues()
        {
            // JPath выражения
            string jsonFromCurPath  = "$...fromCurrency";
            string jsonToCurPath    = "$...toCurrency";

            var datapattern = new DataPattern();
            var testdata    = new TestData();
            var http        = new HttpAction();

            var response = http.GETRequest(testdata.BaseUrl, testdata.GetResourcePath()["currencyRatesPath"]);
            var content  = response.Content;

            JObject jsonObj = JObject.Parse(content);            
            IEnumerable<JToken> jsonArrayFromCur    = jsonObj.SelectTokens(jsonFromCurPath, true);
            IEnumerable<JToken> jsonArrayToCur      = jsonObj.SelectTokens(jsonToCurPath, true);

            var rub = datapattern.GetCurrencyStuff()["rub"];
            var usd = datapattern.GetCurrencyStuff()["usd"];
            var eur = datapattern.GetCurrencyStuff()["eur"];
            var gbp = datapattern.GetCurrencyStuff()["gbp"];

            foreach (JToken fromCur in jsonArrayFromCur)
            {
                string cuttedFromCur = fromCur.ToString().TrimAndDoubleReplace(string.Empty, string.Empty, new char[] { '{', '}' });
                Debug.WriteLine(cuttedFromCur);
                if (cuttedFromCur.Contains(rub) && cuttedFromCur.ToString().Length > 0)
                {
                    Assert.AreEqual(rub, cuttedFromCur);
                    Console.WriteLine("RUB TRUE");
                }
                else if (cuttedFromCur.Contains(usd) && cuttedFromCur.ToString().Length > 0)
                {
                    Assert.AreEqual(usd, cuttedFromCur);
                    Console.WriteLine("USD TRUE");
                }
                else if (cuttedFromCur.Contains(eur) & cuttedFromCur.ToString().Length > 0)
                {
                    Assert.AreEqual(eur, cuttedFromCur);
                    Console.WriteLine("EUR TRUE");
                }
                else if (cuttedFromCur.Contains(gbp) && cuttedFromCur.ToString().Length > 0)
                {
                    Assert.AreEqual(gbp, cuttedFromCur);
                    Console.WriteLine("GBP TRUE");
                }
                else
                    throw new Exception($"Matching CurrencyCode did not happen.");
            }


            foreach (JToken toCur in jsonArrayToCur)
            {
                var cuttedToCur = toCur.ToString().TrimAndDoubleReplace(string.Empty, string.Empty, new char[] { '{', '}' });
                Debug.WriteLine(cuttedToCur);
                if (cuttedToCur.Contains(rub) && cuttedToCur.ToString().Length > 0)
                {
                    Assert.AreEqual(rub, cuttedToCur);
                    Console.WriteLine("RUB TRUE");
                }
                else if (cuttedToCur.Contains(usd) && cuttedToCur.ToString().Length > 0)
                {
                    Assert.AreEqual(usd, cuttedToCur);
                    Console.WriteLine("USD TRUE");
                }
                else if (cuttedToCur.Contains(eur) & cuttedToCur.ToString().Length > 0)
                {
                    Assert.AreEqual(eur, cuttedToCur);
                    Console.WriteLine("EUR TRUE");
                }
                else if (cuttedToCur.Contains(gbp) && cuttedToCur.ToString().Length > 0)
                {
                    Assert.AreEqual(gbp, cuttedToCur);
                    Console.WriteLine("GBP TRUE");
                }
                else
                    throw new Exception($"Matching CurrencyName did not happen.");
            }
        }
    }
}
