using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLoader.Admin.HTTP
{
    public abstract class BaseService
    {
        protected string Url { get; }

        protected BaseService()
        {
            Url = ApplicationSettings.ApiUrl;
            FlurlHttp.Configure(s => s.OnErrorAsync = HandleFlurlErrorAsync);
            //Используем свою фабрику проверки сертификатов, что бы проскакивать ненадежные сертификаты
            FlurlHttp.Configure(cli => cli.HttpClientFactory = new UntrustedCertClientFactory());
        }

        private async Task HandleFlurlErrorAsync(FlurlCall call)
        {
            call.ExceptionHandled = true;
            if (call.ExceptionHandled)
                throw call.Exception;
            switch (call.HttpResponseMessage.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    //    var dto = JsonConvert.DeserializeObject<ServerExceptionDto>(await call.Response.Content.ReadAsStringAsync());
                    //    throw new BLException(dto.Code, new System.Collections.Generic.List<object>() { dto.Data, call.Request?.Method?.Method, call.Request?.RequestUri?.AbsoluteUri });
                    throw new Exception("BadRequest " + call.Exception.Message);
                    break;
                case System.Net.HttpStatusCode.InternalServerError:
                    //    var internalErrorDto = JsonConvert.DeserializeObject<ServerInternalErrorDto>(await call.Response.Content.ReadAsStringAsync());
                    //    throw new Exception(internalErrorDto.Message);
                    throw new Exception("InternalServerError " + call.Exception.Message);
                    break;
                case System.Net.HttpStatusCode.GatewayTimeout:
                    throw call.Exception;
                    break;
                case System.Net.HttpStatusCode.Forbidden:
                    throw new Exception("Forbidden " + call.Exception.Message);
                    //    throw new BLException(ServerErrorCode.AccessDenied, new System.Collections.Generic.List<object>() { call.Request?.Method?.Method, call.Request?.RequestUri?.AbsoluteUri });
                    break;
            }
        }
    }
}
