using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace Xavier.Integration.Tests.Common
{
    public class HttpClient : IHttpClient
    {
        private const string GET = "GET";
        private const string POST = "POST";
        private const string PUT = "PUT";
        private readonly HttpWebRequest httpWebRequest;

        public HttpClient(string url)
            : this((HttpWebRequest) WebRequest.Create(url))
        {

        }

        public HttpClient(HttpWebRequest httpWebRequest)
        {
            this.httpWebRequest = httpWebRequest;
            ContentType = "application/json; charset=UTF-8";
        }

        #region IHttpClient wrapper

        public string ContentType { get; set; }

        public HttpClientResponse Get()
        {
            return MakeRequest(GET, "");
        }

        public HttpClientResponse Post(string requestData)
        {
            return MakeRequest(POST, requestData);
        }

        public HttpClientResponse Put(string requestData)
        {
            return MakeRequest(PUT, requestData);
        }

        public string Method
        {
            get { return httpWebRequest.Method; }
            set { httpWebRequest.Method = value; }
        }
        #endregion

        private HttpClientResponse MakeRequest(string method, string requestData)
        {
            //TODO: create USING methods
            httpWebRequest.Method = method;
            httpWebRequest.ContentType = ContentType;
            httpWebRequest.ContentLength = requestData.Length;
 
            SetRequestData(requestData);

            var response = httpWebRequest.GetResponse();
            var responseStream = response.GetResponseStream();
            var responseStreamReader = new StreamReader(responseStream);
            string responseFromServer = responseStreamReader.ReadToEnd();


            responseStreamReader.Close();
            responseStream.Close();
            response.Close();

            return new HttpClientResponse(((HttpWebResponse)response).StatusCode, responseFromServer);
        }

        private void SetRequestData(string requestData)
        {
            if (string.IsNullOrEmpty(requestData)) return;

            var requestDataBuffer = Encoding.Default.GetBytes(requestData);
            httpWebRequest.ContentLength = requestDataBuffer.Length;
            httpWebRequest.GetRequestStream()
                .Write(requestDataBuffer, 0, requestDataBuffer.Length);
        }
    }

}
