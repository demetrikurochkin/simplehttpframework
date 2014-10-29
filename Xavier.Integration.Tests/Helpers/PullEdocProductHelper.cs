using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Xavier.Integration.Tests.Common;

namespace Xavier.Integration.Tests.Helpers
{
    public class PullEdocProductHelper
    {
        public static bool IsHttpStatusOK(string url)
        {
            //TODO return Tuple<bool, string> for errro message in Asserts
            bool isStatusOk = false;
            try
            {
                HttpClient edocClient = new HttpClient(url);
                var code = edocClient.Get().StatusCode;
                if (code == HttpStatusCode.OK)
                {
                    isStatusOk = true;
                }
            }
            catch (WebException ex)
            {
                Debug.WriteLine(ex.GetType().FullName);
                Debug.WriteLine(ex.GetBaseException().ToString());
            }

            return isStatusOk;
        }

        public static bool IsHttpStatusOK(string url, string request)
        {
            bool isStatusOk = false;
            try
            {
                HttpClient edocClient = new HttpClient(url);
                var code = edocClient.Post(request).StatusCode;
                if (code == HttpStatusCode.OK)
                {
                    isStatusOk = true;
                }
            }
            catch (WebException ex)
            {
                Debug.WriteLine(ex.GetType().FullName);
                Debug.WriteLine(ex.GetBaseException().ToString());
            }
            return isStatusOk;
        }
    }
}