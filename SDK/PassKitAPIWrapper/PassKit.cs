using RestSharp;
using RestSharp.Deserializers;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PassKitAPIWrapper
{
    /// <summary>
    /// Meta data class for PassKit API response
    /// </summary>
    public class PassKitResponse
    {
        // The HttpStatusCode returned by the request
        public HttpStatusCode statusCode { get; set; }

        // The (JSON) response from the server, serialized as a dynamic Dictionary. If the request was successful, response["success"] will be set.
        public Dictionary<string, dynamic> response { get; set; } 

        /// <summary>
        /// Constructor for PassKitResponse
        /// </summary>
        /// <param name="statusCode">The HttpStatusCode of the request</param>
        /// <param name="response">The JSON response string</param>
        public PassKitResponse(HttpStatusCode statusCode, Dictionary<string, dynamic> response)
        {
            this.statusCode = statusCode;
            this.response = response;
        }
    }

    /// <summary>
    /// Main PassKit API wrapper class
    /// </summary>
    public class PassKit
    {
        // API account
        private string account;
        
        // API secret
        private string secret;

        // API Uri
        private string apiUri = "https://api.passkit.com/v1/";

        /// <summary>
        /// Constructor for the PassKit class.
        /// </summary>
        /// <param name="account">The PassKit API account key: a 32 character Hexadecimal string or a 20 character base62 string</param>
        /// <param name="secret">The PassKit API secret: a base64 string</param>
        public PassKit(string account, string secret)
        {
            this.account = account;
            this.secret = secret;
        }
        
        /// <summary>
        /// The execute method. Used for all calls to the API.
        /// </summary>
        /// <param name="request">The RestRequest object</param>
        /// <returns>A PassKitResponse object with the HTTP status code, and the JSON result serialized as Dictionary<string, dynamic></returns>
        private PassKitResponse Execute(RestRequest request) 
        {
            var client = new RestClient();
            client.BaseUrl = this.apiUri;
            client.AddHandler("application/json", new DynamicJsonDeserializer());
            client.Authenticator = new DigestAuthenticator(this.account, this.secret);
           
            var response = client.Execute<dynamic>(request);
            //response.StatusCode
            if (response.ErrorException != null)
            {
                throw response.ErrorException;
            }
            return new PassKitResponse(response.StatusCode, response.Data);
        }

        /// <summary>
        /// Requests a list of templates for the current API account.
        /// 
        /// More info: https://code.google.com/p/passkit/wiki/ListTemplates
        /// </summary>
        /// <returns>PassKitResponse, with on success a list of template names in PassKitResponse.response.</returns>
        public PassKitResponse GetTemplates()
        {
            // Setup the request
            var request = new RestRequest();
            request.Resource = "template/list";

            PassKitResponse result = this.Execute(request);
            return result;
        }

        /// <summary>
        /// Issues a new PassKit pass for template with 'templateName', with the data provided in the 'fields' dictionary.
        /// The 'fields' dictionary uses the field-names as 'key' and the values as 'value'.
        /// 
        /// More info: https://code.google.com/p/passkit/wiki/IssuePass
        /// </summary>
        /// <param name="templateName">The name of the template to issue the pass for</param>
        /// <param name="fields">A dictionary of field-names and their values</param>
        /// <returns>PassKitResponse object, with on success the pass url & pass serial in the PassKitResponse.response.</returns>
        public PassKitResponse IssuePass(string templateName, Dictionary<string, string> fields)
        {
            // Setup the request
            var request = new RestRequest();
            request.Resource = "pass/issue/template/{templateName}";
            request.AddParameter("templateName", templateName, ParameterType.UrlSegment);

            // Add the fields as parameters
            foreach (KeyValuePair<String, String> entry in fields)
            {
                request.AddParameter(entry.Key, entry.Value, ParameterType.GetOrPost);
            }

            PassKitResponse result = this.Execute(request);
            return result;
        }

        /// <summary>
        /// Gets the details for a pass identified by the given unique pass-id.
        /// 
        /// More info: https://code.google.com/p/passkit/wiki/GetPassDetailsPassId
        /// </summary>
        /// <param name="passId">The unique pass id for the pass</param>
        /// <returns>PassKitResponse object, with on success the pass meta & field data in the PassKitResponse.response.</returns>
        public PassKitResponse GetPassDetails(string passId)
        {
            // Setup the request
            var request = new RestRequest();
            request.Resource = "pass/get/passid/{passId}";
            request.AddParameter("passId", passId, ParameterType.UrlSegment);

            PassKitResponse result = this.Execute(request);
            return result;
        }

        /// <summary>
        /// Gets the details for a pass identified by the given template name and serial number.
        /// 
        /// More info: https://code.google.com/p/passkit/wiki/GetPassDetailsTemplateSerial
        /// </summary>
        /// <param name="templateName">The template name of the pass</param>
        /// <param name="serialNumber">The serial number pf the pass</param>
        /// <returns>PassKitResponse object, with on success the pass meta & field data in the PassKitResponse.response.</returns>
        public PassKitResponse GetPassDetails(string templateName, string serialNumber)
        {
            // Setup the request
            var request = new RestRequest();
            request.Resource = "pass/get/template/{templateName}/serial/{serialNumber}";
            request.AddParameter("templateName", templateName, ParameterType.UrlSegment);
            request.AddParameter("serialNumber", serialNumber, ParameterType.UrlSegment);

            PassKitResponse result = this.Execute(request);
            return result;
        }

        /// <summary>
        /// Gets the passes for a given template.
        /// 
        /// More info: https://code.google.com/p/passkit/wiki/GetPassesForTemplate
        /// </summary>
        /// <param name="templateName">The template name</param>
        /// <returns>PassKitResponse object, with on success the pass meta & field data (for all the passes with templateName) in the PassKitResponse.response.</returns>
        public PassKitResponse GetPasses(string templateName)
        {
            // Setup the request
            var request = new RestRequest();
            request.Resource = "template/{templateName}/passes";
            request.AddParameter("templateName", templateName, ParameterType.UrlSegment);

            PassKitResponse result = this.Execute(request);
            return result;
        }

        /// <summary>
        /// Updates the fields for a pass identified by 'templateName' and 'serialNumber'.
        /// 
        /// More info: https://code.google.com/p/passkit/wiki/UpdatePass
        /// </summary>
        /// <param name="templateName">The template name of the pass</param>
        /// <param name="serialNumber">The serial number of the pass</param>
        /// <param name="fields">A dictionary of field-names and their values</param>
        /// <returns>PassKitResponse object, with on success a list of device id's for which pushes were dispatched to Apple.</returns>
        public PassKitResponse UpdatePass(string templateName, string serialNumber, Dictionary<string, string> fields)
        {
            // Setup the request
            var request = new RestRequest();
            request.Resource = "pass/update/template/{templateName}/serial/{serialNumber}";
            request.AddParameter("templateName", templateName, ParameterType.UrlSegment);
            request.AddParameter("serialNumber", templateName, ParameterType.UrlSegment);

            // Add the fields as parameters
            foreach (KeyValuePair<String, String> entry in fields)
            {
                request.AddParameter(entry.Key, entry.Value, ParameterType.GetOrPost);
            }

            PassKitResponse result = this.Execute(request);
            return result;
        }
    }
}
