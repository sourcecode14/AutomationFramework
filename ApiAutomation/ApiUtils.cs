using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Automation.Framework.ApiAutomation
{
    public class ApiUtils
    {
        public JObject ConvertDatModelToJson(Object model) 
        {
            JObject payload = null;
            try
            {
               return payload = JObject.Parse(JsonConvert.SerializeObject(model));        
            }

            catch(Exception e)
            {
                throw new Exception($"Failed to Convert {model.GetType().Name} Model to Json\nException Received as {e.Message}");
            }
        }

        public T ConvertResponseToDataModel<T>(string responseBody) 
        {
            if (!string.IsNullOrWhiteSpace(responseBody))
                try
                {
                    return JsonConvert.DeserializeObject<T>(responseBody);
                }

                catch (Exception e)
                {
                    throw new Exception($"Failed to convert response string to Data Model Object {nameof(T)}\n {e.Message}\n{e.StackTrace}");
                }
            else 
            {
                throw new Exception($"Respone receieved was empty , hence response body cannot be converted to Data model {nameof(T)}");
            }
        }

        public string GenerateUUID()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

        public string GetParamterValueFromURL(string url , string paramtername) 
        {
            Uri theUri = new Uri(url);
            string paramterValue = HttpUtility.ParseQueryString(theUri.Query).Get(paramtername);
            return paramterValue;
        }
    }
}
