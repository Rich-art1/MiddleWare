using Shyjus.BrowserDetection;

namespace MiddleWare
{
    public class MyCustomMiddleware
    {
        private RequestDelegate next;

        public MyCustomMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext,
                                      IBrowserDetector detector)
        {
            var browser = detector.Browser;

            if (browser.Name == BrowserNames.Edge || browser.Name == BrowserNames.InternetExplorer)
            {
                      httpContext.Response.Redirect("mozilla.org/pl/firefox/new/");
            }
            else
            {
                await this.next.Invoke(httpContext);
            }
        }


        public static class MyCustomMiddlewareExtension
        {
            public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<MyCustomMiddleware>();
            }
        }
    }
}
