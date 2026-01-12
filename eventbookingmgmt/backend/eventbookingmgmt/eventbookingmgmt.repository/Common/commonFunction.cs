using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eventbookingmgmt.repository.Common
{
    public class commonFunction
    {
        public static string ConvertToJSON<T>(T obj) where T : class
        {
            try
            {
                var settings = new JsonSerializerSettings()
                {
                    DateFormatString = "yyyy'-'MM'-'dd'T'HH':'mm':'ss"
                };
                return JsonConvert.SerializeObject(obj, (Newtonsoft.Json.Formatting)System.Xml.Formatting.Indented, settings);
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
