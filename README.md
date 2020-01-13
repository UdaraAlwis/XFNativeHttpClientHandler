# XFNativeHttpClientHandler
Xamarin Forms Native HttpClientHandler for HttpClient demo...

Let's properly set up our HttpClient with Native HttpClient Handlers in Xamarin.Forms!

Blog post: https://theconfuzedsourcecode.wordpress.com/2020/01/13/xamarin-forms-native-httpclienthandler-for-httpclient/

Instead of using the .NET managed HttpClientHandler, we need make sure to use the Native Client Handlers of each platform with our HttpClient, for the sake of performance, smaller executables, and security advantage.

**AndroidClientHandler**
-AndroidClientHandler is the new handler that delegates to native Java code and Android OS instead of implementing everything in managed code. This option has better performance and smaller executable size.

**NSUrlSessionHandler** 
-The NSURLSession-based handler is based on the native NSURLSession framework available in iOS 7 and newer. This options has better performance and smaller executable size, supports TLS 1.2 standard.

**WinHttpHandler**
-WinHttpHandler is implemented as a thin wrapper on the WinHTTP interface of Windows and is only supported on Windows systems. Provides developers with more granular control over the application's HTTP communication than the default HttpClientHandler class.

Resources that helped me: 

HttpClient Stack Android - https://docs.microsoft.com/en-us/xamarin/android/app-fundamentals/http-stack?context=xamarin%2Fcross-platform&tabs=windows <br />
HttpClient and SSL/TLS iOS/macOS - https://docs.microsoft.com/en-us/xamarin/cross-platform/macios/http-stack?context=xamarin/cross-platform <br />
Windows WinHttpHandler - https://docs.microsoft.com/en-us/dotnet/api/system.net.http.winhttphandler?view=dotnet-plat-ext-3.1 <br />
Xamarin and HttpClient - https://nicksnettravels.builttoroam.com/post-2019-04-24-xamarin-and-the-httpclient-for-ios-android-and-windows-aspx/ <br />
