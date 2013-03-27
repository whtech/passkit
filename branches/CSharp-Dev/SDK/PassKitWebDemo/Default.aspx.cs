using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PassKitAPIWrapper;
using System.ComponentModel;

namespace PassKitWebDemo
{
    public partial class Default : System.Web.UI.Page
    {
        private string apiAccount = "apiAccount";
        private string apiSecret = "apiSecret";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.getPassesForTemplate();
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
    }
}