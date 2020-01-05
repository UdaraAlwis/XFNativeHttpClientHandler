using System.Net.Http;

namespace XFNativeHttpClientHandler.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            var uwpClientHandler = new WinHttpHandler()
            {
                //ServerCertificateValidationCallback =
                //   (message, certificate2, arg3, arg4) =>
                //   {
                //       return true;
                //   }
            };
            Services.HttpClientService.HttpClientHandler = uwpClientHandler;

            LoadApplication(new XFNativeHttpClientHandler.App());
        }
    }
}
