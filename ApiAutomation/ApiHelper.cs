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
        public ApiUtils ApiUtils { get; set; }
        public string ApiHost { get; set; }
        public Dictionary<string, string> Headers { get; set; }

        public Dictionary<string, string> Cookies { get; set; }

        public ApiHelper(string apiHost = "", Dictionary<string, string> headers = null, Dictionary<string, string> cookies = null) 
        {
            ApiUtils = new ApiUtils();
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

        public IRestResponse SendGetRequest(string endpoint , string queryparam=null) 
        {
            string endpointWithQueryparamIfAny = "";
            if (String.IsNullOrWhiteSpace(queryparam))
            {
                endpointWithQueryparamIfAny = endpoint;
            }
            else 
            {
                endpointWithQueryparamIfAny = $"{endpoint}?{queryparam}";
                
            }
            return SendRequest(Method.GET, endpointWithQueryparamIfAny);
        }

        public IRestResponse SendRequest(Method method,string endpoint,JObject payLoad=null,string contentType= "application/json" ) 
        {
            RestClient restClient = new RestClient(ApiHost);
            RestRequest restRequest = new RestRequest(endpoint, method);
            restRequest.AddHeaders(Headers);
            AddCookiesToRequest(restRequest);
            if (method != Method.GET) 
            {
                restRequest.AddParameter(contentType, payLoad, ParameterType.RequestBody);
            }
            
            IRestResponse restResponse = restClient.Execute(restRequest);
            return restResponse;

        }
    }
}
