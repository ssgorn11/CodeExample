using Flurl.Http.Configuration;
using System.Net.Http;

namespace DataLoader.Admin.HTTP
{
    internal class UntrustedCertClientFactory : DefaultHttpClientFactory
    {
        public override HttpMessageHandler CreateMessageHandler()
        {
            return new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
        }
    }
}
