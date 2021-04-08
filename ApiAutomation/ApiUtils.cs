using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automation.ApiAutomation
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
            try
            {
                return JsonConvert.DeserializeObject<T>(responseBody);
            }

            catch (Exception e) 
            {
                throw new Exception($"Failed to convert response string to Data Model Object");
            }
        }
    }
}
