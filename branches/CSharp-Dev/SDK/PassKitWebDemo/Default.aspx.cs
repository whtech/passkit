using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PassKitAPIWrapper;
using System.ComponentModel;
using System.Text;
using System.Reflection;

namespace PassKitWebDemo
{
    public partial class Default : System.Web.UI.Page
    {
        private string apiAccount = "account";
        private string apiSecret = "secret";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.uploadImageAndGetDetails();
        }

        public void listTemplates()
        {
            PassKit pk = new PassKit(apiAccount, apiSecret);
            PassKitResponse result = pk.GetTemplates();
        }

        public void issueNewPass()
        {
            // Create Dictionary with pass fields
            Dictionary<string, string> fields = new Dictionary<string,string>();
            fields["Student name"] = "Test student";
            fields["Balance"] = "10";
            fields["Issue date"] = "2013-03-26";
            fields["Expiry date"] = "2014-03-26";

            PassKit pk = new PassKit(apiAccount, apiSecret);
            PassKitResponse result = pk.IssuePass("Lesson package", fields);
        }

        public void getPassDetailsPassId()
        {
            PassKit pk = new PassKit(apiAccount, apiSecret);
            PassKitResponse result = pk.GetPassDetails("JCecLhBk9mmC");
        }

        public void getPassDetailsTemplateSerial()
        {
            PassKit pk = new PassKit(apiAccount, apiSecret);
            PassKitResponse result = pk.GetPassDetails("Lesson package", "4756935660433049");
        }

        public void getPassesForTemplate()
        {
            PassKit pk = new PassKit(apiAccount, apiSecret);
            PassKitResponse result = pk.GetPasses("Lesson package");
        }

        public void updatePassTemplateSerial()
        {
            // Create Dictionary with pass fields
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields["Balance"] = "5";
            
            PassKit pk = new PassKit(apiAccount, apiSecret);
            PassKitResponse result = pk.UpdatePass("Lesson package", "4756935660433049", fields);
        }

        public void updatePassPassId()
        {
            // Create Dictionary with pass fields
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields["Balance"] = "2";

            PassKit pk = new PassKit(apiAccount, apiSecret);
            PassKitResponse result = pk.UpdatePass("JCecLhBk9mmC", fields);
        }

        public void updateTemplate()
        {
            // Create Dictionary with template fields
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields["Terms_label"] = "Terms & Sausages";

            PassKit pk = new PassKit(apiAccount, apiSecret);
            PassKitResponse result = pk.UpdateTemplate("Lesson package", fields);
        }

        public void getTemplateFieldNames()
        {
            PassKit pk = new PassKit(apiAccount, apiSecret);
            PassKitResponse result = pk.GetTemplateFieldNames("Lesson package");
        }

        public void resetTemplate()
        {
            PassKit pk = new PassKit(apiAccount, apiSecret);
            PassKitResponse result = pk.ResetTemplate("Lesson package");
        }

        public void uploadImageAndGetDetails()
        {
            PassKit pk = new PassKit(apiAccount, apiSecret);

            // Upload the image
            PassKitResponse result = pk.UploadImage(@"C:\wamp\www\passkit\mystic_8_ball\img\mystic8ballicon.png", PassKitImageType.icon);

            // Get the information for the returned imageID by using the GetImageData call
            PassKitResponse imageResponse = pk.GetImageData(result.response["imageID"]);
        }
    }
}