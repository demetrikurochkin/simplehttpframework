using System;
using System.Net;

namespace Xavier.Integration.Tests.Common
{
    public interface IHttpClient
    {
        HttpClientResponse Get();
        HttpClientResponse Put(string requestData);
        HttpClientResponse Post(string requestData);
        string ContentType { get; set; }
        string Method { get; set; }
    }
}
