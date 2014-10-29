using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xavier.Integration.Tests.Helpers
{
    public static class UrlHelper
    {
        public static string Combine(string baseUrl, string path)
        {
            if (string.IsNullOrEmpty(path))
                return baseUrl;

            if (string.IsNullOrEmpty(baseUrl))
                return path;

            if (baseUrl[baseUrl.Length - 1] != '/')
                baseUrl += '/';

            if (path[path.Length - 1] == '/')
                path = path.Remove(path.Length - 1, 1);

            return baseUrl + path;
        }
    }
}
