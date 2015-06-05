# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Reset Template #

| **URI** | `https://api.passkit.com/v1/template/`<font color='blue'>{templateName}</font>`/reset` <font color='grey'> <i>/push</i> (optional)</font> <font color='grey'> <i>/?format=xml</i> (optional)</font> |
|:--------|:----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Verb** | GET, POST, PUT                                                                                                                                                                                      |
| **Auth** | Yes                                                                                                                                                                                                 |

This method resets each pass record to the default values. This only affects values that the user cannot edit. The method also removes all data-fields from each pass record.

Each pass can have an unlimited number of fields that start with "data-". These fields do not show up on the pass, but are attached to the pass record and thus returned with every request for pass data.

If you wish for the reset to be immediately pushed to all devices with an active pass, include push as the last segment of the URL.

## URL Parameters ##

  * <font color='blue'><b>templateName</b></font> <font color='green'><i>(string)</i></font> The name of the template for the pass records to be reset.

### cURL Syntax ###

**Get request:**

```
curl --digest -u {APIKey}:{APISecret} "https://api.passkit.com/v1/template/{templateName}/reset/push"```


---


## Response Examples ##

#### JSON Format ####

```json

{
"success":true,
"devices": {
"device_1": "a7fc7ff20ef26c95808ab820e2aa797e0c590df760febd974051287779ec69f5"
}
}```

#### XML Format ####

_Note that for XML responses, spaces in tag names will be replaced by 'middle dot' (·).  If a tag starts with an invalid character (E.g. a Number), the tag will be prefixed with two underscores (`__`_)_```
<?xml version="1.0"?>
<PassKit_API_Response>
    <success>1</success>
    <devices>
        <device_1>a7fc7ff20ef26c95808ab820e2aa797e0c590df760febd974051287779ec69f5</device_1>
    </devices>
</PassKit_API_Response>
```_

### Response Parameters ###
  * <font color='blue'>success</font><font color='green'><i>(string)</i></font>
    * Will return <font color='purple'>true</font> for a successful submission, or will not be present in the case of an error.
  * <font color='blue'>devices</font><font color='green'><i>(array)</i></font>
    * A list of the deviceIDs for which a push request has been dispatched to Apple.


---


## Implementation examples ##

Download latest PassKit PHP -and/or C# SDK: https://code.google.com/p/passkit/downloads/list

#### C# Implementation ####
```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Text;
using System.Reflection;
// Make sure to include PassKitAPIWrapper class (takes care of all communication with the API)
using PassKitAPIWrapper;

namespace PassKitWebDemo
{
    public partial class Default : System.Web.UI.Page
    {
        // Set API Account (set with your API account)
        private string apiAccount = "apiAccount";
        // Set API secret (set with your API secret)
        private string apiSecret = "apiSecret";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Set template name
            string template_name = "My template name";

            // Initialize new instance of PassKit API wrapper
            PassKit pk = new PassKit(apiAccount, apiSecret);
            // ResetTemplate will reset all passes for the template
            PassKitResponse result = pk.ResetTemplate(template_name);    
            // Do something with result
        }
    }
}
```

<table border='0'>
<blockquote><tr>
<blockquote><td width='361'></td>
<td width='353'><a href='http://PassKit.com/'>PassKit Home Page</a></td>
<td width='128'><a href='https://create.passkit.com'>Register with PassKit</a></td>
</blockquote></tr>
</table>