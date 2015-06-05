# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Invalidate Pass #

| **URI** | _By template & serial:_<br />`https://api.passkit.com/v1/pass/invalidate/template/`<font color='blue'>{templateName}</font>`/serial/`<font color='blue'>{serialNumber}</font><font color='grey'> <i>/?format=xml</i> (optional)</font><br />_-or by pass-id:_<br />`https://api.passkit.com/v1/pass/invalidate/passid/`<font color='blue'>{passId}</font><font color='grey'> <i>/?format=xml</i> (optional)</font> |
|:--------|:-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Verb** | GET, POST, PUT                                                                                                                                                                                                                                                                                                                                                                                                     |
| **Auth** | Yes                                                                                                                                                                                                                                                                                                                                                                                                                |

This method is used for invalidating a pass. It accepts the parameters returned by the [Get Template Field Names](GetTemplateDetails.md) method, plus relevance fields for date and for up to 10 locations. To identify the correct pass, you can either call the method with template & serial, or with pass-id.

Invalidating a pass, performs two functions in a single call.  Firstly, it serves as a update, allowing you to change the content of an invalidated pass and secondly, it removes the pass from circulation, preventing it from being updated or manually refreshed.

Relevance alerts (Location and date) will continue to function on the pass holder's device, unless specifically deactivated by specifying the removeLocations and the removeRelevantDate parameters.  Alternatively, you may decide for marketing or client engagement purposes to use this to your advantage and specify new dates, locations and location alert messages that may engage the pass holder.

For additional security, there is a request parameter that will remove the barcode from the face of the pass to prevent it from being presented.

Invalidated passes remain in the database for analytics purposes but once invalidated, they cannot be reactivated.

Note that in order to change the pass on a users device, they must have notifications turned on.  You should still maintain your own diligence checks before accepting any pass.

To help make this method as accessible as possible, it accepts GET, POST and PUT requests.  Key/Value pairs can be submitted via GET or POST, and JSON or XML files can be submitted via PUT.

A successful submission will return the deviceID of each device updated and and a count of the number of passes updated in the database.  So for example, if there were 4 issued passes but only 2 had notifications active in the phone, you would see two deviceIDs and a count of 4 passes invalidated.

## URI Parameters ##

  * <font color='blue'><b>templateName</b></font> <font color='green'><i>(string)</i></font> The name of the template for the pass to be updated

  * <font color='blue'><b>serialNumber</b></font> <font color='green'><i>(string)</i></font> The serial number of the pass to be updated

Or:

  * <font color='blue'><b>passId</b></font> <font color='green'><i>(string)</i></font> The unique id of the pass to be updated

## Request Parameters ##

#### Generic parameters ####

  * <font color='blue'>{fieldName}</font><font color='green'><i>(mixed)</i></font> <font color='grey'><i>optional</i></font>
    * The value for a dynamic field within the template. The submitted data type must match the data type of the field, as specified in the template.  Date values must be in ISO 8601 format.  If not provided, the pass will return the default value for the field or an empty string or zero value for number and currency fields if no default is present.
  * <font color='blue'>{fieldName}<code>_</code>changeMessage</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * The text of the notification message that will be displayed when the field value changes.  Include %@ in the string to include the new value in the notification.
  * <font color='blue'>{fieldName}<code>_</code>label</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * The value of a dynamic label field. Label values are always treated as text.
  * <font color='blue'>recoveryEmail</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * A recovery email address that can be used to assist users reinstall the pass. An invalid email address or an address domain with no mx records will return an error.
  * <font color='blue'>removeBarcode</font><font color='green'><i>(boolean)</i></font> <font color='grey'><i>optional</i></font>
    * If set to true, the barcode will be removed from the face of the pass.
  * <font color='blue'>barcodeContent</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * For templates that allow the barcode encoded content to be changed.  Using %@ in the string will insert the pass serial number into the encoded content.
  * <font color='blue'>barcodeAltContent</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * For templates that allow the barcode alternative content to be changed.  Using %@ in the string will insert the pass serial number into the message.
  * <font color='blue'>removeRelevantDate</font><font color='green'><i>(boolean)</i></font> <font color='grey'><i>optional</i></font>
    * If set to true, the relevantDate will be removed from the pass. The pass holder will no longer receive time based alerts.
  * <font color='blue'>relevantDate</font><font color='green'><i>(date)</i></font> <font color='grey'><i>optional</i></font>
    * For Pass types that support a relevant date, a date in ISO 8601 format can be provided. More information on the behavior of the relevant date can be found [here](LockScreenMessages.md).

#### Colour Parameters ####

  * <font color='blue'>labelColor / labelColour</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * To change the label color. Accepts a 6 digit HEX color code.
  * <font color='blue'>foregroundColor / foregroundColour</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * To change the foreground color. Accepts a 6 digit HEX color code.
  * <font color='blue'>backgroundColor / backgroundColour</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * To change the background color. Accepts a 6 digit HEX color code.

#### Image Parameters ####

The images on each pass can be changed by using the image parameters.
  * <font color='blue'>thumbnailImage</font><font color='green'><i>(imageID)</i></font> <font color='grey'><i>optional</i></font>
    * For templates that accept a thumbnail image. Accepts the thumbnail imageID as returned by the [Upload Image](UploadImage.md) method.  ImageIDs, can be checked with the [Get Image Data](GetImageData.md) method.
  * <font color='blue'>stripImage</font><font color='green'><i>(imageID)</i></font> <font color='grey'><i>optional</i></font>
    * For templates that accept a strip image. Accepts the strip imageID as returned by the [Upload Image](UploadImage.md) method. ImageIDs, can be checked with the [Get Image Data](GetImageData.md) method.
  * <font color='blue'>logoImage</font><font color='green'><i>(imageID)</i></font> <font color='grey'><i>optional</i></font>
    * For templates that accept a logo image. Accepts the logo imageID as returned by the [Upload Image](UploadImage.md) method. ImageIDs, can be checked with the [Get Image Data](GetImageData.md) method.
  * <font color='blue'>footerImage</font><font color='green'><i>(imageID)</i></font> <font color='grey'><i>optional</i></font>
    * For templates that accept a footer image. Accepts the footer imageID as returned by the [Upload Image](UploadImage.md) method. ImageIDs, can be checked with the [Get Image Data](GetImageData.md) method.
  * <font color='blue'>backgroundImage</font><font color='green'><i>(imageID)</i></font> <font color='grey'><i>optional</i></font>
    * For templates that accept a background image. Accepts the background imageID as returned by the [Upload Image](UploadImage.md) method. ImageIDs, can be checked with the [Get Image Data](GetImageData.md) method.
  * <font color='blue'>iconImage</font><font color='green'><i>(imageID)</i></font> <font color='grey'><i>optional</i></font>
    * For templates that accept a icon image. Accepts the icon imageID as returned by the [Upload Image](UploadImage.md) method. ImageIDs, can be checked with the [Get Image Data](GetImageData.md) method.

#### Location Parameters ####

Optionally, each pass can hold up to 10 locations. When submitting locations, the address, latitude, longitude and locationAlert parameters are all required. More information on the behavior of locations can be found [here](LockScreenMessages.md).
  * <font color='blue'>removeLocations</font><font color='green'><i>(boolean)</i></font> <font color='grey'><i>optional</i></font>
    * If set to true, all locations will be removed from the pass. The pass holder will no longer receive location based alerts.
  * <font color='blue'>location<i>{number}</i>address</font><font color='green'><i>(string)</i></font> <font color='grey'><i>required</i></font>
    * An address or other meaningful text that will help you identify the location.
  * <font color='blue'>location<i>{number}</i>latitude</font><font color='green'><i>(float)</i></font> <font color='grey'><i>required</i></font>
    * The latitude of the location.
  * <font color='blue'>location<i>{number}</i>longitude</font><font color='green'><i>(float)</i></font> <font color='grey'><i>required</i></font>
    * The longitude of the location.
  * <font color='blue'>location<i>{number}</i>locationAlert</font><font color='green'><i>(string)</i></font> <font color='grey'><i>required</i></font>
    * The message to be displayed on the lockscreen when the device is close to the location.

### Request Examples ###

#### GET Request ####

```
https://api.passkit.com/v1/pass/invalidate/template/My%20Pass%20Template/serial/12345/?Check%20In=2012-10-06T00:00:00+08:00&CheckOut=2012-10-08T00:00:00+08:00&... etc.```

#### JSON Format ####
```

{
"Check In": "2012-10-07T00:00:00+08:00",
"Check In_changeMessage" : "Your check in date has changed to %@",
"Check Out": "2012-10-08T00:00:00+08:00",
"No. Rooms": "1",
"No. Guests": "2",
"Reservation No.": "8864337",
"Guest Name": "Daniel Allen",
"Hotel Name": "JW Marriott Hotel Hong Kong",
"Hotel Address": "Pacific Place, 88 Queensway, Hong Kong",
"Hotel Telephone": "+852 2810 8366",
"Nightly Rate": "HK$ 3,315",
"removeBarcode": true,
"removeRelevantDate": true,
"removeLocations": true
}
```

#### XML Format ####
_Note that for XML requests, spaces in tag names must be replaced by 'middle dot' (·).  If a tag starts with an invalid character (E.g. a Number), the tag should be prefixed with two underscores (`__`_)_```
<?xml version="1.0" encoding="UTF-8" ?>
<PassKit_API_Request>
	<Check·In>2012-10-06T00:00:00+08:00</Check·In>
        <Check·In_changeMessage>Your check in date has changed to %@</Check·In_changeMessage>
	<Check·Out>2012-10-08T00:00:00+08:00</Check·Out>
	<No.·Rooms>1</No.·Rooms>
	<No.·Guests>2</No.·Guests>
	<Reservation·No.>8864337</Reservation·No.>
	<Guest·Name>Daniel Allen</Guest·Name>
	<Hotel·Name>JW Marriott Hotel Hong Kong</Hotel·Name>
	<Hotel·Address>Pacific Place, 88 Queensway, Hong Kong</Hotel·Address>
	<Hotel·Telephone>+852 2810 8366</Hotel·Telephone>
	<Nightly·Rate>HK$ 3,315</Nightly·Rate>
        <removeBarcode>1</removeBarcode>
        <removeRelevantDate>1</removeRelevantDate>
        <removeLocations>1</removeLocations>
</PassKit_API_Request>
```_

### cURL Syntax ###

#### GET Request ####
_By template & serial:_
```
curl --digest -u {APIKey}:{APISecret}
"https://api.passkit.com/v1/pass/invalidate/template/{templateName}/serial/{serialNumber}/push?{parameter}={value}&{parameter}={value}"```

_By pass-id:_
```
curl --digest -u {APIKey}:{APISecret}
"https://api.passkit.com/v1/pass/invalidate/passid/{passId}/push?{parameter}={value}&{parameter}={value}"```

#### POST Request ####
_By template & serial:_
```
curl --digest -u {APIKey}:{APISecret} -d "{parameter}={value};{parameter}={value}"
"https://api.passkit.com/v1/pass/invalidate/template/{templateName}/serial/{serialNumber}/push"```

_By pass-id:_
```
curl --digest -u {APIKey}:{APISecret} -d "{parameter}={value};{parameter}={value}"
"https://api.passkit.com/v1/pass/invalidate/passid/{passId}/push"```

#### PUT Request ####
_By template & serial:_
```
curl --digest -u {APIKey}:{APISecret} -d @{filename} -X PUT
"https://api.passkit.com/v1/pass/invalidate/template/{templateName}/serial/{serialNumber}/push"```

_By pass-id:_
```
curl --digest -u {APIKey}:{APISecret} -d @{filename} -X PUT
"https://api.passkit.com/v1/pass/invalidate/passid/{passId}/push"```


---


## Response Examples ##

#### JSON Format ####

```

{
"success": true,
"device_ids": {
"device_1": "a7fc7ff20ef26c95808ab820e2aa797e0c590df760febd974051287779ec69f5"
},
"passes": 2
}
```

#### XML Format ####
```
<?xml version="1.0"?>
<PassKit_API_Response>
        <success>1</success>
        <device_ids>
                <device_1>a7fc7ff20ef26c95808ab820e2aa797e0c590df760febd974051287779ec69f5</device_1>        
        </device_ids>
        <passes>2</passes>
</PassKit_API_Response>
```

### Response Parameters ###
  * <font color='blue'>success</font><font color='green'><i>(string)</i></font>
    * WIll return <font color='purple'>true</font> for a successful submission, or will not be present in the case of an error.
  * <font color='blue'>device_ids</font><font color='green'><i>(array)</i></font>
    * A list of the deviceIDs for which a push request has been dispatched to Apple.
  * <font color='blue'>passes</font><font color='green'><i>(integer)</i></font>
    * The number of issued passes updated in the database.

---


## Implementation examples ##

Download latest PassKit PHP -and/or C# SDK: https://code.google.com/p/passkit/downloads/list

#### PHP Implementation ####

```
<?php
/**
* Example: Invalidate pass
* URI: https://code.google.com/p/passkit/wiki/InvalidatePass
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

// Set the data array for the fields to update before invalidating the pass
$data["field1"] = "field 1 data";
$data["field2"] = "field 2 data";
$data["field3"] = "field 3 data";
// Make sure to remove barcode, relevant date & locations
$data["removeBarcode"] = 1;
$data["removeLocations"] = 1;
$data["removeRelevantDate"] = 1;

// Example 1: this example shows you how to set the pass via the combination of template_name & pass_serial, and then invalidate
$pk->set_pass_serial($pass_serial, $template_name);
// Validate pass (otherwise invalidate pass doesn't work)
$pk->pass_validate();
// Invalidate pass
$pk->pass_invalidate($data);

// Example 2: this example shows you how to set the pass via the unique pass id, and then invalidate the pass (use either example 1 or 2)
$pk->set_pass_id($unique_pass_id);
// Validate pass (otherwise invalidate pass doesn't work)
$pk->pass_validate();
// Invalidate pass
$pk->pass_invalidate($data);
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

        // Set the data dictionary for the fields to update before invalidating the pass
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["field 1"] = "Field 1 data";
        data["field 2"] = "Field 2 data";
        data["field 3"] = "Field 3 data";
        // Make sure to remove barcode, relevant date & locations
        data["removeBarcode"] = "1";
        data["removeLocations"] = "1";
        data["removeRelevantDate"] = "1";

        // There are 2 ways to invalidate a pass, via template & serial combination, or via unique pass id.

        // Example 1: this example shows you how to invalidate the pass via the combination of template_name & pass_serial
        PassKitResponse result = pk.InvalidatePass(template_name, pass_serial, data);
        // Do something with result

        // Example 2: this example shows you how to invalidate the pass via the unique pass id
        PassKitResponse result2 = pk.InvalidatePass(unique_pass_id, data);
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