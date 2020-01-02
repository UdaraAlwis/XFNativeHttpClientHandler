# XFNativeHttpClientHandler
Xamarin Forms Native HttpClient Handler demo...

Let's properly set up our HttpClient with Native HttpClient Handlers in Xamarin.Forms!

Instead of using the .NET managed HttpClientHandler, we neet make sure to use the Native Client Handlers of each platform with our HttpClien, for the sake of performance, smaller executables, and security advantage.

**AndroidClientHandler**
-AndroidClientHandler is the new handler that delegates to native Java code and Android OS instead of implementing everything in managed code. This option has better persformance and smaller executable size.

**NSUrlSessionHandler**
-The NSURLSession-based handler is based on the native NSURLSession framework available in iOS 7 and newer. This options has better persformance and smaller executable size, supports TLS 1.2 standard.

**WinHttpHandler**
-WinHttpHandler is implemented as a thin wrapper on the WinHTTP interface of Windows and is only supported on Windows systems. Provides developers with more granular control over the application's HTTP communication than the HttpClientHandler class.


https://docs.microsoft.com/en-us/xamarin/android/app-fundamentals/http-stack?context=xamarin%2Fcross-platform&tabs=windows

https://docs.microsoft.com/en-us/xamarin/cross-platform/macios/http-stack?context=xamarin/cross-platform

https://docs.microsoft.com/en-us/dotnet/api/system.net.http.winhttphandler?view=dotnet-plat-ext-3.1

https://nicksnettravels.builttoroam.com/post-2019-04-24-xamarin-and-the-httpclient-for-ios-android-and-windows-aspx/
