using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Fullbar.Web.Common
{
    public static class WebApiHelper
    {
        public static HttpClient WebApiClient = new HttpClient();

        static WebApiHelper()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:49738/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
