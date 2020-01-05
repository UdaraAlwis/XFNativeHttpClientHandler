using System.Net.Http;
using Xamarin.Forms;

namespace XFNativeHttpClientHandler.Services
{
    public class HttpClientService
    {
        public HttpClient HttpClient { get; private set; }

        public static object HttpClientHandler = null;

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
