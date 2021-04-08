using Automation.ApiAutomation.Enums;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.ApiAutomation
{
    public class ApiHelper
    {
        public string ApiHost { get; set; }
        public Dictionary<string, string> Headers { get; set; }

        public Dictionary<string, string> Cookies { get; set; }

        public ApiHelper(string apiHost = "", Dictionary<string, string> headers = null, Dictionary<string, string> cookies = null) 
        {
            ApiHost = apiHost;
            Headers = headers;
            Cookies = cookies;
        }
         
        internal RestRequest AddCookiesToRequest(RestRequest restRequest)
        {
            if (Cookies != null)
            {
                foreach (var item in Cookies)
                {
                    restRequest.AddCookie(item.Key, item.Value);
                }
            }

            return restRequest;
        }
        public IRestResponse SendRequest(Method method,string endpoint,JObject payLoad,string contentType= "application/json" ) 
        {
            RestClient restClient = new RestClient(ApiHost);
            RestRequest restRequest = new RestRequest(endpoint, method);
            restRequest.AddHeaders(Headers);
            AddCookiesToRequest(restRequest);
            restRequest.AddParameter(contentType,payLoad,ParameterType.RequestBody);
            IRestResponse restResponse = restClient.Execute(restRequest);
            return restResponse;

        }
    }
}
