using System;
using System.Net.Http;
using Xamarin.Forms;

namespace XFNativeHttpClientHandler.Services
{
    public class HttpClientService
    {
        public HttpClient HttpClient { get; private set; }

        private static object httpClientHandler = null;
        public static object HttpClientHandler 
        {
            get => httpClientHandler;
            set 
            {
                if (httpClientHandler == null) 
                {
                    if (value is HttpMessageHandler)
                        httpClientHandler = value;
                    else
                        throw new Exception($"{nameof(HttpClientHandler)} incorrect type!");
                }
                else
                    throw new Exception($"{nameof(HttpClientHandler)} is already setup!");
            }
        }

        private static HttpClientService instance = null;
        private static readonly object padlock = new object();

        private HttpClientService()
        {
            if (HttpClientHandler != null)
                HttpClient = new HttpClient((HttpMessageHandler)HttpClientHandler);
            else
                HttpClient = new HttpClient();
        }

        public static HttpClientService Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new HttpClientService();
                    }
                    return instance;
                }
            }
        }
    }
}
