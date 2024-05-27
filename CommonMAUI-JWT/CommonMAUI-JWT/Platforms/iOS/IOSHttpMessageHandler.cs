using CommonMAUI_JWT.Handler;
using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMAUI_JWT.Platforms.iOS
{
    public class IOSHttpMessageHandler : IPlatformHttpMessageHandler
    {
        public HttpMessageHandler GetHttpMessageHandler()
        {
            return new NSUrlSessionHandler {
                TrustOverrideForUrl = (NSUrlSessionHandler sender, string url, SecTrust trust) => url.StartsWith("https://localhost");
            }
        }
    }
}
