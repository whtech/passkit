using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Web.Script.Serialization;

// ReSharper disable CheckNamespace
namespace RestSharp.Deserializers
// ReSharper restore CheckNamespace
{
    /// <summary>
    /// Custom implementation of the IDeserializer class to return the JSON response as a Dictionary object
    /// </summary>
    public class DynamicJsonDeserializer : IDeserializer
    {
        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
        
        /// <summary>
        /// Deserializes the JSON as a Dictionary<string, dynamic>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        public T Deserialize<T>(IRestResponse response)
        {
            var jsonSerialization = new JavaScriptSerializer();
            dynamic dictObj = jsonSerialization.Deserialize<Dictionary<string, dynamic>>(response.Content);
            return dictObj;
        }
    }
}
