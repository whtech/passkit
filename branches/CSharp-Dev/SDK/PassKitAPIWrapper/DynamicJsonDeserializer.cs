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
        /// <summary>
        /// RootElement
        /// </summary>
        public string RootElement { get; set; }

        /// <summary>
        /// Namespace
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        /// Dateformat
        /// </summary>
        public string DateFormat { get; set; }
        
        /// <summary>
        /// Deserializes the JSON as a Dictionary&lt;string, dynamic&gt;
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
