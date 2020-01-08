using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Android.Net;
using Javax.Net.Ssl;
using Xamarin.Android.Net;

namespace XFNativeHttpClientHandler.Droid
{
    /// <summary>
    /// Custom AndroidClientHandler for disabling
    /// Self-Signed HTTPS Certificate Validation
    /// Credits: https://nicksnettravels.builttoroam.com/android-certificates/
    /// </summary>
    public class CustomAndroidClientHandler : AndroidClientHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Version = new System.Version(2, 0);
            return await base.SendAsync(request, cancellationToken);
        }

        protected override SSLSocketFactory ConfigureCustomSSLSocketFactory(HttpsURLConnection connection)
        {
            return SSLCertificateSocketFactory.GetInsecure(0, null);
        }

        protected override IHostnameVerifier GetSSLHostnameVerifier(HttpsURLConnection connection)
        {
            return new BypassHostnameVerifier();
        }
    }

    internal class BypassHostnameVerifier : Java.Lang.Object, IHostnameVerifier
    {
        public bool Verify(string hostname, ISSLSession session)
        {
            return true;
        }
    }
}