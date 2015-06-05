# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Get Image Data #

| **URI** | `https://api.passkit.com/v1/image/`<font color='blue'>{imageID}</font> <font color='grey'><i>/?format=xml (optional)</i></font> |
|:--------|:--------------------------------------------------------------------------------------------------------------------------------|
| **Verb** | GET                                                                                                                             |
| **Auth** | No                                                                                                                              |

This method returns data about a particular <font color='blue'>imageID</font>, specifically the useage types that it has been processed for

A call to this method can be used to validate the validity of a an <font color='blue'>imageID</font> for use as a particular _imageType_

## URL Parameters ##

<font color='blue'>imageID</font> <font color='green'> <i>(string)</i></font>

The imageID returned when when the image was uploaded with the upload method

_**Note:** Image types, sizes and their role in each pass type is explained in more detail [here](PassImages.md)_

#### cURL Syntax ####
```

curl "https://api.passkit.com/v1/image/{imageID}"```

---

## Responses ##

A successful upload should receive the following response:

#### JSON Format ####

```javascript

{
"imageID":"3YrwmjaWGrESOM5rVjd6dK",
"Icon":"true"
}
```

#### XML Format ####

```
<?xml version="1.0"?>
<PassKit_API_Response>
  <imageID>3YrwmjaWGrESOM5rVjd6dK</imageID>
  <Icon>true</Icon>
</PassKit_API_Response>
```

#### Response Parameters ####
  * <font color='blue'>imageID</font><font color='green'><i>(string)</i></font>
    * The image ID requested in the API call
  * <font color='blue'>background</font><font color='green'><i>(boolean)</i></font>
    * Will return true if image has been processed for use as a background image or be absent from the response if not
  * <font color='blue'>footer</font><font color='green'><i>(boolean)</i></font>
    * Will return true if image has been processed for use as a footer image or be absent from the response if not
  * <font color='blue'>logo</font><font color='green'><i>(boolean)</i></font>
    * Will return true if image has been processed for use as a logo image or be absent from the response if not
  * <font color='blue'>icon</font><font color='green'><i>(boolean)</i></font>
    * Will return true if image has been processed for use as a icon image or be absent from the response if not
  * <font color='blue'>strip</font><font color='green'><i>(boolean)</i></font>
    * Will return true if image has been processed for use as a strip image or be absent from the response if not
  * <font color='blue'>thumbnail</font><font color='green'><i>(boolean)</i></font>
    * Will return true if image has been processed for use as a thumbnail image or be absent from the response if not


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
            // Set the image id
            string image_id = "image ID";

            // Initialize new instance of PassKit API wrapper
            PassKit pk = new PassKit(apiAccount, apiSecret);
            // Get the image data
            PassKitResponse result = pk.GetImageData(image_id);

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