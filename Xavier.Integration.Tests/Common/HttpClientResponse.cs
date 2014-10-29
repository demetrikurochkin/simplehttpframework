using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Xavier.Integration.Tests.Common
{
    public class HttpClientResponse : IDisposable
    {
        private readonly HttpStatusCode httpStatusCode;
        private readonly string responseBody;

        public HttpClientResponse() { }

        public HttpClientResponse(HttpStatusCode httpStatusCode, string responseBody)
        {
            this.httpStatusCode = httpStatusCode;
            this.responseBody = responseBody;
        }

        public virtual string ResponseBody
        {
            get { return responseBody; }
        }

        public virtual HttpStatusCode StatusCode
        {
            get { return httpStatusCode; }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
