# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Get Pass Details (by pass id) #

| **URI** | `https://api.passkit.com/v1/pass/get/passid/`<font color='blue'>{passId}</font>` `<font color='grey'> <i>/?format=xml</i> (optional)</font> |
|:--------|:--------------------------------------------------------------------------------------------------------------------------------------------|
| **Verb** | GET                                                                                                                                         |
| **Auth** | Yes                                                                                                                                         |

Gets the pass details based on the pass id. The function returns a result of pass meta -and field data.

## URI Parameters ##

  * <font color='blue'><b>passId</b></font> <font color='green'><i>(string)</i></font> The unique id of the pass.

### cURL Syntax ###

```
curl --digest -u {APIKey}:{APISecret} "https://api.passkit.com/v1/pass/get/passid/{passId}"```

---


## Response Examples ##

A successful request should receive the following response:

#### JSON Format ####

```json

{
"success":true,
"serialNumber":"serialNumber",
"templateName":"Lesson package",
"templateLastUpdated":"2013-02-08T01:02:55+00:00",
"passID":"passId",
"passRecord":
{
"passMeta":
{
"passStatus":"Active",
"issueDate":"2013-02-10T08:19:30+00:00",
"passbookSerial":"passbookSerial",
"shareID":"shareId"
},
"passData":
{
"Student name":"Test student",
"Balance":"8",
"Issue date":"2013-02-10",
"Expiry date":"2014-02-10",
"barcodeContent":"barcodeContent"
}
}
}
```

#### XML Format ####

_Note that for XML responses, spaces in tag names will be replaced by 'middle dot' (·).  If a tag starts with an invalid character (E.g. a Number), the tag will be prefixed with two underscores (`__`_)_```
<?xml version="1.0"?>
<PassKit_API_Response>
    <success>1</success>
    <serialNumber>serialNumber</serialNumber>
    <templateName>Lesson package</templateName>
    <templateLastUpdated>2013-02-08T01:02:55+00:00</templateLastUpdated>
    <passID>passId</passID>
    <passRecord>
        <passMeta>
            <passStatus>Active</passStatus>
            <issueDate>2013-02-10T08:19:30+00:00</issueDate>
            <passbookSerial>passbookSerial</passbookSerial>
            <shareID>shareId</shareID>
        </passMeta>
        <passData>
            <Student·name>Test student</Student·name>
            <Balance>8</Balance>
            <Issue·date>2013-02-10</Issue·date>
            <Expiry·date>2014-02-10</Expiry·date>
            <barcodeContent>barcodeContent</barcodeContent>
        </passData>
    </passRecord>
</PassKit_API_Response>

```_

## Implementation examples ##

Download latest PassKit PHP -and/or C# SDK: https://code.google.com/p/passkit/downloads/list

#### PHP Implementation ####

```
<?php
/**
* Example: Get pass details
* URI: https://code.google.com/p/passkit/wiki/GetPassDetailsTemplateSerial
*/

// Include passkit api file
require_once ('class-PassKit.php');

// Set variables
$api_key = "apiKey"; // Add your PassKit API Key
$api_secret = "apiSecret"; // Add your PassKit API Secret
$template_name = "My template"; // Add your template name here
$pass_serial = "Pass serial"; // Add your pass serial here
$unique_pass_id = "Unique pass id"; // Add your unique pass id here

// Create new PassKit instance
$pk = new PassKit($apiKey, $apiSecret);

// Get the pass details via the unique pass id
$pk->set_pass_id($unique_pass_id);
// Need to call pass_validate before get_pass_details
$pk->pass_validate();
$pass_details = $pk->get_pass_details();
// Print results
print_r($pass_details);
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
        // Set the image template
        string template_name = "My template";
        // Set the pass serial
        string pass_serial = "Pass serial";
        // Set the unique pass id
        string unique_pass_id = "Unique pass id";

        // Initialize new instance of PassKit API wrapper
        PassKit pk = new PassKit(apiAccount, apiSecret);

        // Get the pass details via the unique pass id
        PassKitResponse result = pk.GetPassDetails(unique_pass_id);
        // Do something with result
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