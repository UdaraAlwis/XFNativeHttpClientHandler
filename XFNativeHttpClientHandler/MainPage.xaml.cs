using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFNativeHttpClientHandler.Services;

namespace XFNativeHttpClientHandler
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly MainPageViewModel _viewModel;

        private readonly HttpClient _httpClient;

        public MainPage()
        {
            InitializeComponent();

            _httpClient = HttpClientService.Instance.HttpClient;

            _viewModel = new MainPageViewModel();
            BindingContext = _viewModel;
        }

        private async void TestButton_Clicked(object sender, EventArgs e)
        {
            _viewModel.IsRunning = true;

            var secureHttpsBadssl = "https://google.com/";
            var selfSignedBadSsl = "https://self-signed.badssl.com/";
            var httpBadSsl = "http://http.badssl.com/";

            try
            {
                var resultSelfSignedTest = await _httpClient.GetAsync(secureHttpsBadssl);
                _viewModel.ResultHttpsSecured = resultSelfSignedTest.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _viewModel.ResultHttpsSecured = false;
            }

            try
            {
                var resultSelfSignedTest = await _httpClient.GetAsync(selfSignedBadSsl);
                _viewModel.ResultHttpsSelfSigned = resultSelfSignedTest.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _viewModel.ResultHttpsSelfSigned = false;
            }

            try
            {
                var resultBadSslTest = await _httpClient.GetStringAsync(httpBadSsl);
                _viewModel.ResultHttpTest = true;
            }
            catch (Exception ex)
            {
                _viewModel.ResultHttpTest = false;
            }

            _viewModel.IsRunning = false;
        }
    }

    public class MainPageViewModel : INotifyPropertyChanged
    {
        private bool _resultHttpsSecured;
        public bool ResultHttpsSecured
        {
            get
            {
                return _resultHttpsSecured;
            }
            set
            {
                _resultHttpsSecured = value;
                NotifyPropertyChanged();
            }
        }

        private bool _resultHttpsSelfSigned;
        public bool ResultHttpsSelfSigned
        {
            get
            {
                return _resultHttpsSelfSigned;
            }
            set
            {
                _resultHttpsSelfSigned = value;
                NotifyPropertyChanged();
            }
        }

        private bool _resultHttpTest;
        public bool ResultHttpTest
        {
            get
            {
                return _resultHttpTest;
            }
            set
            {
                _resultHttpTest = value;
                NotifyPropertyChanged();
            }
        }

        private bool _isRunning;
        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                _isRunning = value;
                NotifyPropertyChanged();
            }
        }

        private string _proxySettingsText;
        public string ProxySettingsText
        {
            get
            {
                return _proxySettingsText;
            }
            set
            {
                _proxySettingsText = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
