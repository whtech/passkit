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
        /// <summary>
        /// The HttpStatusCode returned by the request
        /// </summary>
        public HttpStatusCode statusCode { get; set; }

        /// <summary>
        /// The (JSON) response from the server, serialized as a dynamic Dictionary. If the request was successful, response["success"] will be set.
        /// </summary>
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
    /// Allow uses for uploaded images.
    /// </summary>
    public enum PassKitImageType
    {
        /// <summary>
        /// For background use
        /// </summary>
        background,
        /// <summary>
        /// For footer use
        /// </summary>
        footer,
        /// <summary>
        /// For logo use
        /// </summary>
        logo,
        /// <summary>
        /// For icon use
        /// </summary>
        icon,
        /// <summary>
        /// For strip use
        /// </summary>
        strip,
        /// <summary>
        /// For thumbnail use
        /// </summary>
        thumbnail
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
        /// All API methods return a PassKitResponse object that always contains:
        /// 1. HTTP Response Code;
        /// 2. Response object. The first parameter on success is: success (bool), or error (string) on error;
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
        /// <returns>A PassKitResponse object with the HTTP status code, and the JSON result serialized as Dictionary&lt;string, dynamic&gt;</returns>
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

        #region Template methods

        /// <summary>
        /// Gets the passes for a given template.
        /// <see href="https://code.google.com/p/passkit/wiki/GetPassesForTemplate">More info</see>  
        /// </summary>
        /// <param name="templateName">The template name</param>
        /// <returns>PassKitResponse object, with on success the pass meta &amp; field data (for all the passes with templateName).</returns>
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
        /// Requests a list of templates for the current API account.
        /// <see href="https://code.google.com/p/passkit/wiki/ListTemplates">More info</see>
        /// </summary>
        /// <returns>PassKitResponse, with on success a list of template names.</returns>
        public PassKitResponse GetTemplates()
        {
            // Setup the request
            var request = new RestRequest();
            request.Resource = "template/list";

            PassKitResponse result = this.Execute(request);
            return result;
        }

        /// <summary>
        /// This method returns the field names that can be used with the Issue Pass and Update Pass methods for a particular template. 
        /// It returns the names of all dynamic fields in the template, plus other variables such as barcode content, serial number or thumbnail 
        /// image that can be set or updated.
        /// <see href="https://code.google.com/p/passkit/wiki/GetTemplateDetails">More info</see>
        /// </summary>
        /// <param name="templateName">The name of the template</param>
        /// <param name="full">Boolean, if true the method will also return information re. the fields on the back of the template</param>
        /// <returns>PassKitResponse, with on success a list of template details.</returns>
        public PassKitResponse GetTemplateFieldNames(string templateName, bool full = false)
        {
            // Setup the request
            var request = new RestRequest();
            string fullString = string.Empty;
            if (full)
            {
                fullString = "/full";
            }
            request.Resource = "template/{templateName}/fieldnames" + fullString;
            request.AddParameter("templateName", templateName, ParameterType.UrlSegment);

            PassKitResponse result = this.Execute(request);
            return result;
        }

        /// <summary>
        /// Updates the template. Causes all the passes of the template to be updated as well.
        /// <see href="https://code.google.com/p/passkit/wiki/UpdatePass">More info</see>  
        /// </summary>
        /// <param name="templateName">The template name</param>
        /// <param name="fields">A dictionary of field-names and their values</param>
        /// <param name="push">Indicates if the update should be pushed to all devices with an active pass</param>
        /// <returns>PassKitResponse object, with on success a list of device id's for which pushes were dispatched to Apple.</returns>
        public PassKitResponse UpdateTemplate(string templateName, Dictionary<string, string> fields, bool push = true)
        {
            // Setup the request
            var request = new RestRequest();
            string pushString = string.Empty;
            if (push)
            {
                pushString = "/push";
            }
            request.Resource = "template/update/{templateName}" + pushString;
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
        /// This method resets each pass record to the default values. This only affects values that the user cannot edit. 
        /// The method also removes all data-fields from each pass record.
        /// <see href="https://code.google.com/p/passkit/wiki/ResetTemplate">More info</see>
        /// </summary>
        /// <param name="templateName">The name of the template</param>
        /// <param name="push">Indicates if the update should be pushed to all devices with an active pass</param>
        /// <returns>PassKitResponse object, with on success a list of device id's for which pushes were dispatched to Apple.</returns>
        public PassKitResponse ResetTemplate(string templateName, bool push = true)
        {
            // Setup the request
            var request = new RestRequest();
            string pushString = string.Empty;
            if (push)
            {
                pushString = "/push";
            }
            request.Resource = "template/{templateName}/reset" + pushString;
            request.AddParameter("templateName", templateName, ParameterType.UrlSegment);

            PassKitResponse result = this.Execute(request);
            return result;
        }

        #endregion

        #region Pass methods

        /// <summary>
        /// Issues a new PassKit pass for template with 'templateName', with the data provided in the 'fields' dictionary.
        /// The 'fields' dictionary uses the field-names as 'key' and the values as 'value'.
        /// <see href="https://code.google.com/p/passkit/wiki/IssuePass">More info</see>
        /// </summary>
        /// <param name="templateName">The name of the template to issue the pass for</param>
        /// <param name="fields">A dictionary of field-names and their values</param>
        /// <returns>PassKitResponse object, with on success the pass url &amp; pass serial.</returns>
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
        /// Updates the fields for pass identified by 'templateName' and 'serialNumber'. Method can update multiple passes at once in case
        /// the user decided to use the same serial for multiple passes in the pass designer.
        /// <see href="https://code.google.com/p/passkit/wiki/UpdatePass">More info</see>  
        /// </summary>
        /// <param name="templateName">The template name of the pass</param>
        /// <param name="serialNumber">The serial number of the pass</param>
        /// <param name="fields">A dictionary of field-names and their values</param>
        /// <param name="push">Indicates if the update should be pushed to all devices with an active pass</param>
        /// <returns>PassKitResponse object, with on success a list of device id's for which pushes were dispatched to Apple.</returns>
        public PassKitResponse UpdatePass(string templateName, string serialNumber, Dictionary<string, string> fields, bool push = true)
        {
            // Setup the request
            var request = new RestRequest();
            string pushString = string.Empty;
            if (push)
            {
                pushString = "/push";
            }
            request.Resource = "pass/update/template/{templateName}/serial/{serialNumber}" + pushString;
            request.AddParameter("templateName", templateName, ParameterType.UrlSegment);
            request.AddParameter("serialNumber", serialNumber, ParameterType.UrlSegment);

            // Add the fields as parameters
            foreach (KeyValuePair<String, String> entry in fields)
            {
                request.AddParameter(entry.Key, entry.Value, ParameterType.GetOrPost);
            }

            PassKitResponse result = this.Execute(request);
            return result;
        }

        /// <summary>
        /// Updates the fields for pass identified by 'passId'. 'passId' is unique, so method will update one pass.
        /// <see href="https://code.google.com/p/passkit/wiki/UpdatePass">More info</see>  
        /// </summary>
        /// <param name="passId">The unique pass id</param>
        /// <param name="fields">A dictionary of field-names and their values</param>
        /// <param name="push">Indicates if the update should be pushed to all devices with an active pass</param>
        /// <returns>PassKitResponse object, with on success a list of device id's for which pushes were dispatched to Apple.</returns>
        public PassKitResponse UpdatePass(string passId, Dictionary<string, string> fields, bool push = true)
        {
            // Setup the request
            var request = new RestRequest();
            string pushString = string.Empty;
            if (push)
            {
                pushString = "/push";
            }
            request.Resource = "pass/update/passid/{passId}" + pushString;
            request.AddParameter("passId", passId, ParameterType.UrlSegment);

            // Add the fields as parameters
            foreach (KeyValuePair<String, String> entry in fields)
            {
                request.AddParameter(entry.Key, entry.Value, ParameterType.GetOrPost);
            }

            PassKitResponse result = this.Execute(request);
            return result;
        }

        /// <summary>
        /// Gets the details for a pass identified by the given unique pass-id. Returns the details for one unique pass only.
        /// <see href="https://code.google.com/p/passkit/wiki/GetPassDetailsPassId">More info</see>
        /// </summary>
        /// <param name="passId">The unique pass id for the pass</param>
        /// <returns>PassKitResponse object, with on success the pass meta &amp; field data.</returns>
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
        /// Gets the details for a pass identified by the given template name and serial number. Serial number is not unique
        /// in case the user decided to use the same serial for multiple passes in the pass designer. In that case the response
        /// can contain information for multiple passes.
        /// <see href="https://code.google.com/p/passkit/wiki/GetPassDetailsTemplateSerial">More info</see> 
        /// </summary>
        /// <param name="templateName">The template name of the pass</param>
        /// <param name="serialNumber">The serial number pf the pass</param>
        /// <returns>PassKitResponse object, with on success the pass meta &amp; field data in the PassKitResponse.response.</returns>
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
        /// This method is used for invalidating a pass. It accepts the parameters returned by the Get Template Field Names method, plus relevance fields for date and for up to 10 locations. 
        /// Invalidating a pass, performs two functions in a single call. Firstly, it serves as a update, allowing you to change the content of an invalidated pass and secondly, it removes the pass from circulation, 
        /// preventing it from being updated or manually refreshed.
        /// </summary>
        /// <see href="https://code.google.com/p/passkit/wiki/InvalidatePass">More info</see>
        /// <param name="templateName">The template name of the pass</param>
        /// <param name="serialNumber">The serial number pf the pass</param>
        /// <param name="fields">A dictionary of field-names and their values</param>
        /// <returns>PassKitResponse, with on success a list of devices that were updated &amp; invalidated.</returns>
        public PassKitResponse InvalidatePass(string templateName, string serialNumber, Dictionary<string, string> fields)
        {
            // Setup the request
            var request = new RestRequest();
            request.Resource = "pass/invalidate/template/{templateName}/serial/{serialNumber}";
            request.AddParameter("templateName", templateName, ParameterType.UrlSegment);
            request.AddParameter("serialNumber", serialNumber, ParameterType.UrlSegment);

            // Add the fields as parameters
            foreach (KeyValuePair<String, String> entry in fields)
            {
                request.AddParameter(entry.Key, entry.Value, ParameterType.GetOrPost);
            }

            PassKitResponse result = this.Execute(request);
            return result;
        }

        /// <summary>
        /// This method is used for invalidating a pass. It accepts the parameters returned by the Get Template Field Names method, plus relevance fields for date and for up to 10 locations. 
        /// Invalidating a pass, performs two functions in a single call. Firstly, it serves as a update, allowing you to change the content of an invalidated pass and secondly, it removes the pass from circulation, 
        /// preventing it from being updated or manually refreshed.
        /// </summary>
        /// <see href="https://code.google.com/p/passkit/wiki/InvalidatePass">More info</see>
        /// <param name="passId">The unique pass id</param>
        /// <param name="fields">A dictionary of field-names and their values</param>
        /// <returns>PassKitResponse, with on success a list of devices that were updated &amp; invalidated.</returns>
        public PassKitResponse InvalidatePass(string passId, Dictionary<string, string> fields)
        {
            // Setup the request
            var request = new RestRequest();
            request.Resource = "pass/invalidate/passid/{passId}";
            request.AddParameter("passId", passId, ParameterType.UrlSegment);

            // Add the fields as parameters
            foreach (KeyValuePair<String, String> entry in fields)
            {
                request.AddParameter(entry.Key, entry.Value, ParameterType.GetOrPost);
            }

            PassKitResponse result = this.Execute(request);
            return result;
        }

        #endregion

        #region Image methods

        /// <summary>
        /// This method allows you to upload images for use with other methods such as template methods and pass methods. 
        /// Each image that is uploaded is assigned a unique ID, and is processed for use with Passbook, 
        /// according to the imageType selected.
        /// </summary>
        /// <see href="https://code.google.com/p/passkit/wiki/UploadImage">More info</see>
        /// <param name="pathToLocalFile">The path to the local filename (make sure that you have read access to the file)</param>
        /// <param name="imageType">The image type of the file (according to PassKitImageType enum)</param>
        /// <returns>PassKitResponse object, with on success the image ID and the usage.</returns>
        public PassKitResponse UploadImage(string pathToLocalFile, PassKitImageType imageType)
        {
            // Check if the file exists
            FileInfo file;
            if (File.Exists(pathToLocalFile))
            {
                file = new FileInfo(pathToLocalFile);
            }
            else{
                throw new FileNotFoundException("File cannot be found.", pathToLocalFile);
            }

            // Check if image and set mimetype of image
            string ext = file.Extension.ToLower();

            string type = "image/";
            if (ext.Equals(".jpg") || ext.Equals(".jpeg"))
            {
                type += "jpg";
            }
            else if (ext.Equals(".gif"))
            {
                type += "gif";
            }
            else if (ext.Equals(".png"))
            {
                type += "png";
            }
            else
            {
                // Throw not supported error
                throw new NotSupportedException("Image-type not supported. Method only supports image/jpg, image/gif or image/png");
            }

            // Check the filesize. If bigger then 1.5MB throw a not supported exception
            if (file.Length > 1572864)
            {
                throw new NotSupportedException("The file-lenght is too big. Image files bigger then 1.5MB are not supported.");
            }

            // Setup the request
            var request = new RestRequest();
            request.Resource = "image/add/{imageType}";
            // Specifically set method to POST
            request.Method = Method.POST;
            // Set imageType (thumbnail, icon, etc)
            request.AddParameter("imageType", imageType.ToString(), ParameterType.UrlSegment);
            // Set image MIME type: image/jpg, image/gif or image/png are supported
            request.AddParameter("type", type, ParameterType.GetOrPost);
            // Add the actual image file
            request.AddFile("image", File.ReadAllBytes(pathToLocalFile), file.Name, type);
            
            PassKitResponse result = this.Execute(request);
            return result;
        }

        /// <summary>
        /// Method returns information about the image with imageId.
        /// </summary>
        /// <see href="https://code.google.com/p/passkit/wiki/GetImageData">More info</see>
        /// <param name="imageId">The unique ID of the image</param>
        /// <returns>PassKitResponse object, with on success the information for the image.</returns>
        public PassKitResponse GetImageData(string imageId)
        {
            // Setup the request
            var request = new RestRequest();
            request.Resource = "image/{imageID}";
            request.AddParameter("imageID", imageId, ParameterType.UrlSegment);
            
            PassKitResponse result = this.Execute(request);
            return result;
        }

        #endregion
    }
}
