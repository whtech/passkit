# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# List Templates #

| **URI** | `https://api.passkit.com/v1/template/list`<font color='grey'> <i>/?format=xml</i> (optional)</font> |
|:--------|:----------------------------------------------------------------------------------------------------|
| **Verb** | GET                                                                                                 |
| **Auth** | Yes                                                                                                 |

This method returns all the templates for the user account (API key & secret).

## URL Parameters ##

None

### cURL Syntax ###

```
curl --digest -u {APIKey}:{APISecret} "https://api.passkit.com/v1/template/list"```


---


## Response Examples ##

#### JSON Format ####

```json

{
"success":true,
"templates":[
"My template 1",
"My template 2",
"My template 3"
]
}```

#### XML Format ####

_Note that for XML responses, spaces in tag names will be replaced by 'middle dot' (·).  If a tag starts with an invalid character (E.g. a Number), the tag will be prefixed with two underscores (`__`_)_```
<?xml version="1.0"?>
<PassKit_API_Response>
    <success>1</success>
    <templates>
        <item>My template 1</item>
        <item>My template 2</item>
        <item>My template 3</item>
    </templates>
</PassKit_API_Response>
```_

### Response Parameters ###
  * <font color='blue'>success</font><font color='green'><i>(string)</i></font>
    * Will return <font color='purple'>true</font> for a successful submission, or will not be present in the case of an error.
  * <font color='blue'>templates</font><font color='green'><i>(array)</i></font>
    * A list of the template names for the user account.


---


## Implementation examples ##

Download latest PassKit PHP -and/or C# SDK: https://code.google.com/p/passkit/downloads/list

#### PHP Implementation ####

```
<?php
/**
* Example: List templates
* URI: https://api.passkit.com/v1/template/list
*/

// Include passkit api file
require_once ('class-PassKit.php');

// Set variables
$api_key = "apiKey"; // Add your PassKit API Key
$api_secret = "apiSecret"; // Add your PassKit API Secret

// Create new PassKit instance
$pk = new PassKit($apiKey, $apiSecret);

// Execute API call via get_templates function
$templates = $pk->get_templates();

// Print results
print_r($templates);
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
            // Initialize new instance of PassKit API wrapper
            PassKit pk = new PassKit(apiAccount, apiSecret);
            // GetTemplates will return the information for all templates for this account
            PassKitResponse result = pk.GetTemplates();

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