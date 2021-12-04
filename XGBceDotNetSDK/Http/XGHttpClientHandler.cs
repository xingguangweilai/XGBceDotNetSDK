using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace XGBceDotNetSDK.Http
{
    public class XGHttpClientHandler
    {
        private static readonly ConcurrentDictionary<string, XGHttpClientHandler> httpclients = new ConcurrentDictionary<string, XGHttpClientHandler>();
        public XGHttpClientHandler(string proStr,WebProxy proxy)
        {
            webProxy = proxy;
            string p = string.IsNullOrEmpty(proStr) ? "" : proStr;
            if (p == "")
            {
                client = new HttpClient();
            }
            else
            {
                var httpClientHandler = new HttpClientHandler
                {
                    Proxy = webProxy
                };

                client = new HttpClient(handler: httpClientHandler, disposeHandler: true);
            }
            client.Timeout = TimeSpan.FromSeconds(60);
            createTime = DateTime.Now;
        }

        public readonly HttpClient client;

        public readonly DateTime createTime;

        public readonly WebProxy webProxy;

        public static HttpClient GetHttpClient(WebProxy proxy)
        {
            
            string key = "";
            if (proxy != null &&proxy.Address!=null&& !string.IsNullOrEmpty(proxy.Address.AbsoluteUri))
                key = proxy.Address.AbsoluteUri;
            XGHttpClientHandler result = httpclients.GetOrAdd(key, (k) =>
            {
                return new XGHttpClientHandler(k, proxy);
            });
            TimeSpan timeSpan = DateTime.Now - result.createTime;

            
            while (timeSpan.TotalSeconds > 300)
            {
                ICollection<KeyValuePair<string, XGHttpClientHandler>> kv = httpclients;
                kv.Remove(new KeyValuePair<string, XGHttpClientHandler>(key, result));
                result = httpclients.GetOrAdd(key, (k) =>
                {
                    return new XGHttpClientHandler(k,proxy);
                });
                timeSpan = DateTime.Now - result.createTime;
            }
            return result.client;
        }
    }
}
