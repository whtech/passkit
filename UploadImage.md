# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Upload Image #

| **URI** | `https://api.passkit.com/v1/image/add/`<font color='blue'>{imageType}</font> <font color='grey'><i>?url={url} (optional)</i></font><font color='grey'> <i>/?format=xml (optional)</i></font> |
|:--------|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Verb** | POST                                                                                                                                                                                         |
| **Auth** | Yes                                                                                                                                                                                          |

This method allows you to upload images for use with other methods such as template methods and pass methods.  Each image that is uploaded is assigned a unique ID, and is processed for use with Passbook, according to the <font color='blue'>imageType</font> selected.

Images of type `image/jpeg, image/png` and `image/gif` can be uploaded and an imageID is returned.

A single image can be used for multiple purposes _(E.g. as a thumbnail and as an icon)_ but to do so, it must be uploaded twice.  Under these cases, a single imageID will be approved for use with multiple types.

To see all the permitted usage types for a particular imageID, see the Get Image Details call.

The same image can

## URL Parameters ##

<font color='blue'>imageType</font> <font color='green'> <i>(string)</i></font> can be any one of the following:
  * _background
  * footer
  * logo
  * icon
  * strip
  * thumbnail_

_**Note:** Image types, sizes and their role in each pass type is explained in more detail [here](PassImages.md)_

<font color='blue'>url</font> <font color='green'> <i>(string)</i></font> <font color='grey'> <i>optional</i></font> The url for an image already hosted online (instead of uploading one).

## Request Contents ##

The request type must be `Content-Type multipart/form-data`, and the request must contain a field titled <font color='green'><i><b>image</b></i></font> containing  a file of type `image/jpeg, image/png` or `image/gif` image.

#### cURL Syntax ####
```

curl --digest -u ff0b04afe47feacd09a850d9a1dd91d0:kFTlvlfrjU/djar.V3tO0uyvoF0svLGVhM7ccGN.ek80GdqcJNcju
-F "image=@{filename};type={MIME type}" -X POST "https://api.passkit.com/v1/image/add/{imageType}"```

---

## Responses ##

A successful upload should receive the following response:

#### JSON Format ####

```javascript

{
"success": true,
"imageID": "UPQCQqyzzLaJEvfq9X0pM",
"usage": "Thumbnail Image"
}
```

#### XML Format ####

```
<?xml version="1.0"?>
<PassKit_API_Response>
    <success>1</success>
    <imageID>UPQCQqyzzLaJEvfq9X0pM</imageID>
    <usage>UPQCQqyzzLaJEvfq9X0pM</usage>
</PassKit_API_Response>
```

### Response Parameters ###
  * <font color='blue'>success</font><font color='green'><i>(boolean)</i></font>
    * Will return true for a successful upload, or will not be present in the case of an error
  * <font color='blue'>imageID</font><font color='green'><i>(string)</i></font>
    * imageID for use in other methods
  * <font color='blue'>usage</font><font color='green'><i>(string)</i></font>
    * The usage type that image has been processed for

---


## Implementation examples ##

Download latest PassKit PHP -and/or C# SDK: https://code.google.com/p/passkit/downloads/list

#### PHP Implementation ####

```
<?php
/**
* Example: Upload image
* URI: https://api.passkit.com/v1/image/add/{imageType}
*/

// Include passkit api file
require_once ('class-PassKit.php');

// Set variables
$api_key = "apiKey"; // Add your PassKit API Key
$api_secret = "apiSecret"; // Add your PassKit API Secret
$template_name = "My template"; // Add your template name here
$path_to_image_file = "home/my_image.jpg"; // Set this to your image path. 

// Create new PassKit instance
$pk = new PassKit($apiKey, $apiSecret);

// Upload the image. Image-type has to be has to be: thumbnail, strip, logo, footer, background or icon
$pk_image_id = $pk->pk_image_upload("strip", $path_to_image_file);

// After upload, $pk_image_id contains the image id for the image. We use this data id in the data array (when issuing or updating a pass).
// The data array can be: thumbnailImage, stripImage, logoImage, footerImage, backgroundImage or iconImage (depending on the purpose
// that you want to use the image for.
$data["stripImage"] = $pk_image_id;
// Set other data parameters
$data["field1"] = "field 1 data";
$data["field2"] = "field 2 data";

// Now issue or update the pass with this data, and the image will be set
$pk->pk_issue_pass($template_name, $data);
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
            // Set the template name
            string template_name = "My template";
            // Set the image path
            string image_path = @"home/my_image.jpg";

            // Initialize new instance of PassKit API wrapper
            PassKit pk = new PassKit(apiAccount, apiSecret);
            // Upload the image (image type has to be one of the types in the PassKitImageType enum)
            PassKitResponse uploadResult = pk.UploadImage(image_path, PassKitImageType.strip);

            // Get the image ID from the result
            if (uploadResult.response["success"])
            {
                string image_id = (string)uploadResult.response["imageID"];
                
                // Use the image id to issue a pass
                // Create the data array
                Dictionary<string, string> data = new Dictionary<string, string>();
                // Set the image field in the data array, the image field can be: thumbnailImage, stripImage, logoImage, footerImage, backgroundImage or iconImage 
                // (depending on the purpose that you want to use the image for).
                data["stripImage"] = image_id;
                // Set other data fields
                data["field1"] = "Field 1 data";
                data["field2"] = "Field 2 data";
                   
                // Issue new pass
                PassKitResponse issueResponse = pk.IssuePass(template_name, data);

                // Do something with response
            }
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