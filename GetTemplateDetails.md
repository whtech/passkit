# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Get Template Field Names #

| **URI** | `https://api.passkit.com/v1/template/`<font color='blue'>{templateName}</font>`/fieldnames `<font color='grey'> <i>/full</i> (optional)</font><font color='grey'> <i>/?format=xml</i> (optional)</font> |
|:--------|:--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Verb** | GET                                                                                                                                                                                                     |
| **Auth** | Yes                                                                                                                                                                                                     |

This method returns the field names that can be used with the Issue Pass and Update Pass methods for a particular template.  It returns the names of all dynamic fields in the template, plus other variables such as barcode content, serial number or thumbnail image that can be set or updated.

You can add "/full" after "/fieldnames". This will result in the method also returning the field information re. fields on the back of the pass.

## URL Parameters ##

  * <font color='blue'><b>templateName</b></font> <font color='green'><i>(string)</i></font> The name of the template

### cURL Syntax ###

Normal request:

```
curl --digest -u {APIKey}:{APISecret} "https://api.passkit.com/v1/template/{templateName}/fieldnames"```

With full parameter:

```
curl --digest -u {APIKey}:{APISecret} "https://api.passkit.com/v1/template/{templateName}/fieldnames/full"```

---


## Response Examples ##

#### JSON Format ####

```json

{
"My Pass Template" : {
"Check In"                : "date",
"Check In_changeMessage"  : "text",
"Check Out"               : "date",
"Check Out_changeMessage" : "text",
"No Rooms"                : "number",
"No Guests"               : "number",
"Reservation Num"         : "text",
"Status"                  : "text",
"Status_changeMessage:"   : "text",
"Guest Name"              : "text",
"Hotel Name"              : "text",
"Hotel Address"           : "text",
"Hotel Telephone"         : "text",
"Nightly Rate"            : "currency",
"recoveryEmail"           : "text"
}
}```

#### XML Format ####

_Note that for XML responses, spaces in tag names will be replaced by 'middle dot' (·).  If a tag starts with an invalid character (E.g. a Number), the tag will be prefixed with two underscores (`__`_)_```
<?xml version="1.0"?>
<PassKit_API_Response>
    <My·Pass·Template>
        <Check·In>date</Check·In>
        <Check·In_changeMessage>text</Check·In_changeMessage>
        <Check·Out>date</Check·Out>
        <Check·Out_changeMessage>text</Check·Out_changeMessage>
        <Num·Rooms>number</Num.·Rooms>
        <Num·Guests>number</Num.·Guests>
        <Reservation·Num>text</Reservation·Num>
        <Status>text</Status>
        <Status_changeMessage>text</Status_changeMessage>
        <Guest·Name>text</Guest·Name>
        <Hotel·Name>text</Hotel·Name>
        <Hotel·Address>text</Hotel·Address>
        <Hotel·Telephone>text</Hotel·Telephone>
        <Nightly·Rate>currency</Nightly·Rate>
        <recoveryEmail>text</recoveryEmail>
    </My·Pass·Template>
</PassKit_API_Response>
```_

### Response Parameters ###

  * <font color='blue'>{fieldName}</font><font color='green'><i>(string)</i></font>
    * Returns the name of each dynamic 'value' field, together with the type of data the field accepts. The type value will be either one of <font color='purple'>text</font>, <font color='purple'>number</font>,  <font color='purple'>date</font>,  <font color='purple'>datetime</font> or <font color='purple'>currency</font>.
  * <font color='blue'>{fieldName}<code>_</code>changeMessage</font><font color='green'><i>(string)</i></font>
    * If a field (static or dynamic) has a change message set, this parameter will be returned with a value of <font color='purple'>text</font>
  * <font color='blue'>{fieldName>}<code>_</code>label</font><font color='green'><i>(string)</i></font>
    * Returns the ID of a dynamic 'label' field with a value of <font color='purple'>text</font>
  * <font color='blue'>thumbnailImage</font><font color='green'><i>(string)</i></font>
    * If the template accepts a thumbnail image, this parameter will be returned with a value of <font color='purple'>text</font>
  * <font color='blue'>serialNumber</font><font color='green'><i>(string)</i></font>
    * If the template requires a serial to be provided at pass creation, this parameter will be returned with a value of <font color='purple'>text</font>'
  * <font color='blue'>recoveryEmail</font><font color='green'><i>(string)</i></font>
    * All passes accept a recovery email address. This parameter will always be returned with a value of <font color='purple'>text</font>. An invalid email address or an address domain with no mx records will return an error
  * <font color='blue'>barcodeContent</font><font color='green'><i>(string)</i></font>
    * If the template allows for the barcode encoded content to be changed, this parameter will be returned with a value of <font color='purple'>text</font>
  * <font color='blue'>barcodeAltContent</font><font color='green'><i>(string)</i></font>
    * If the template allows for the barcode alternative content to be changed, this parameter will be returned with a value of <font color='purple'>text</font>

---


## Implementation examples ##

Download latest PassKit PHP -and/or C# SDK: https://code.google.com/p/passkit/downloads/list

#### PHP Implementation ####

```
<?php
/**
* Example: Get template field names
* URI: https://api.passkit.com/v1/template/{templateName}/fieldnames
*/

// Include passkit api file
require_once ('class-PassKit.php');

// Set variables
$api_key = "apiKey"; // Add your PassKit API Key
$api_secret = "apiSecret"; // Add your PassKit API Secret
$template_name = "myTemplateName"; // Add your template name

// Create new PassKit instance
$pk = new PassKit($apiKey, $apiSecret);

// Execute API call via get_template_details function
$template_details = $pk->get_template_details($template_name);

// Print results
print_r($template_details);
?>
```

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
            // GetTemplateFieldNames will get the template details for template_name
            PassKitResponse result = pk.GetTemplateFieldNames(template_name);
    
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