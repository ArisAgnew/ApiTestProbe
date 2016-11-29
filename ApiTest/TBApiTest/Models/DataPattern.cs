using System.Collections.Generic;

namespace TBApiTest.Models
{
    class DataPattern
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// Получает совокупность шаблонов валютных данных
        /// *С# 6.0
        /// </returns>
        public Dictionary<dynamic, dynamic> GetCurrencyStuff() =>
            new Dictionary<dynamic, dynamic>
            {
                {"rub", "\"code\":643,\"name\":\"RUB\""},
                {"usd", "\"code\":840,\"name\":\"USD\""},
                {"eur", "\"code\":978,\"name\":\"EUR\""},
                {"gbp", "\"code\":826,\"name\":\"GBP\""},
            };
    }

    class TestData
    {
        private string baseurl = "https://www.tinkoff.ru/";

        public string BaseUrl
        {
            get { return baseurl; }
            protected set { baseurl = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// Получает необходимый resoursce path
        /// *С# 6.0
        /// </returns>
        public Dictionary<string, object> GetResourcePath() =>
            new Dictionary<string, object>
            {
                {"currencyRatesPath", "api/v1/currency_rates/" }
            };
    }
}
