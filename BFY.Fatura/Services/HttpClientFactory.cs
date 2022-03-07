using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BFY.Fatura.Services
{
    internal class HttpClientFactory
    {
        public static HttpClient Create()
        {
            HttpClient client = new();
            client.DefaultRequestHeaders.Add("accept", "*/*");
            client.DefaultRequestHeaders.Add("accept-language", "tr,en-US;q=0.9,en;q=0.8");
            client.DefaultRequestHeaders.Add("cache-control", "no-cache");
            client.DefaultRequestHeaders
                .TryAddWithoutValidation("content-type", "application/x-www-form-urlencoded;charset=UTF-8");
            client.DefaultRequestHeaders.Add("pragma", "no-cache");
            client.DefaultRequestHeaders.Add("sec-fetch-mode", "cors");
            client.DefaultRequestHeaders.Add("sec-fetch-site", "same-origin");
            client.DefaultRequestHeaders.Add("connection", "keep-alive");

            return client;
        }
    }
}
