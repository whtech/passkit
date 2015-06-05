# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Update Pass #

| **URI** | _By template & serial:_ <br />`https://api.passkit.com/v1/pass/update/template/`<font color='blue'>{templateName}</font>`/serial/`<font color='blue'>{serialNumber}</font><font color='grey'> <i>/push (optional) /?format=xml</i> (optional)</font> <br />_-or by pass-id:_ <br /> `https://api.passkit.com/v1/pass/update/passid/`<font color='blue'>{passId}</font><font color='grey'> <i>/push (optional) /?format=xml</i> (optional)</font> |
|:--------|:-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Verb** | GET, POST, PUT                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| **Auth** | Yes                                                                                                                                                                                                                                                                                                                                                                                                                                              |

This method is used for updating a pass. It accepts the parameters returned by the [Get Template Field Names](GetTemplateDetails.md) method, plus relevance fields for date and for up to 10 locations. To identify the correct pass, you can either call the method with template & serial, or with pass-id.

If you wish for the update to be immediately pushed to all all devices with an active pass bearing the serial number, include `push` as the last segment of the URI.

To help make this method as accessible as possible, it accepts GET, POST and PUT requests.  Key/Value pairs can be submitted via GET or POST, and JSON or XML files can be submitted via PUT.

A successful submission will return the deviceID of each device updated and and a count of the number of passes updated in the database.  So for example, if there were 4 issued passes but only 2 had notifications active in the phone, you would see two deviceIDs and a count of 4 passes updated.

## URI Parameters ##

  * <font color='blue'><b>templateName</b></font> <font color='green'><i>(string)</i></font> The name of the template for the pass to be updated

  * <font color='blue'><b>serialNumber</b></font> <font color='green'><i>(string)</i></font> The serial number of the pass to be updated

Or:

  * <font color='blue'><b>passId</b></font> <font color='green'><i>(string)</i></font> The unique id of the pass to be updated

## Request Parameters ##

#### Generic Parameters ####

  * <font color='blue'>{fieldName}</font><font color='green'><i>(mixed)</i></font> <font color='grey'><i>optional</i></font>
    * The value for a dynamic field within the template. The submitted data type must match the data type of the field, as specified in the template.  Date values must be in ISO 8601 format.  If not provided, the pass will return the default value for the field or an empty string or zero value for number and currency fields if no default is present.
  * <font color='blue'>{fieldName}<code>_</code>changeMessage</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * The text of the notification message that will be displayed when the field value changes.  Include %@ in the string to include the new value in the notification.
  * <font color='blue'>{fieldName}<code>_</code>label</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * The value of a dynamic label field. Label values are always treated as text.
  * <font color='blue'>recoveryEmail</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * A recovery email address that can be used to assist users reinstall the pass. An invalid email address or an address domain with no mx records will return an error.
  * <font color='blue'>barcodeContent</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * For templates that allow the barcode encoded content to be changed.  Using %@ in the string will insert the pass serial number into the encoded content.
  * <font color='blue'>barcodeAltContent</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * For templates that allow the barcode alternative content to be changed.  Using %@ in the string will insert the pass serial number into the message.
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

  * <font color='blue'>location<i>{number}</i>address</font><font color='green'><i>(string)</i></font> <font color='grey'><i>required</i></font>
    * An address or other meaningful text that will help you identify the location.
  * <font color='blue'>location<i>{number}</i>latitude</font><font color='green'><i>(float)</i></font> <font color='grey'><i>required</i></font>
    * The latitude of the location.
  * <font color='blue'>location<i>{number}</i>longitude</font><font color='green'><i>(float)</i></font> <font color='grey'><i>required</i></font>
    * The longitude of the location.
  * <font color='blue'>location<i>{number}</i>locationAlert</font><font color='green'><i>(string)</i></font> <font color='grey'><i>required</i></font>
    * The message to be displayed on the lockscreen when the device is close to the location.

#### Beacon Parameters ####

Optionally, each pass can hold up to 10 beacons. When submitting beacons, the name parameter is required.
  * <font color='blue'>beacon{number}</font><font color='green'><i>(bool)</i></font> <font color='grey'><i>required</i></font>
    * Set to true to use the beacon.
  * <font color='blue'>beacon{number}name</font><font color='green'><i>(string)</i></font> <font color='grey'><i>required</i></font>
    * A UUID or other meaningful text that will help you identify the beacon.
  * <font color='blue'>beacon{number}major</font><font color='green'><i>(16-bit unsigned integer)</i></font> <font color='grey'><i>optional</i></font>
    * The major identifier of a beacon.
  * <font color='blue'>beacon{number}minor</font><font color='green'><i>(16-bit unsigned integer)</i></font> <font color='grey'><i>optional</i></font>
    * The minor identifier of a beacon.
  * <font color='blue'>beacon{number}beaconAlert</font><font color='green'><i>(string)</i></font> <font color='grey'><i>required</i></font>
    * The message to be displayed on the lockscreen when the device is close to the beacon.

### Request Examples ###

#### GET Request ####

```
https://api.passkit.com/v1/pass/update/template/My%20Pass%20Template/serial/12345/?Check%20In=2012-10-06T00:00:00+08:00&CheckOut=2012-10-08T00:00:00+08:00&... etc.```

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
"relevantDate": "2012-10-06T00:00:00+08:00",
"location1address": "Pacific Place, 88 Queensway, Hong Kong",
"location1latitude": "22.27772",
"location1longitude": "114.16481",
"location1locationAlert": "Enjoy your stay"
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
	<relevantDate>2012-10-06T00:00:00+08:00</relevantDate>
	<location1address>Pacific Place, 88 Queensway, Hong Kong</location1address>
	<location1latitude>22.27772</location1latitude>
	<location1longitude>114.16481</location1longitude>
	<location1locationAlert>Enjoy your stay</location1locationAlert>
</PassKit_API_Request>
```_

### cURL Syntax ###

#### GET Request ####
_By template & serial:_
```
curl --digest -u {APIKey}:{APISecret}
"https://api.passkit.com/v1/pass/update/template/{templateName}/serial/{serialNumber}/push?{parameter}={value}&{parameter}={value}"```

_By pass-id:_
```
curl --digest -u {APIKey}:{APISecret}
"https://api.passkit.com/v1/pass/update/passId/{passId}/push?{parameter}={value}&{parameter}={value}"```

#### POST Request ####
_By template & serial:_
```
curl --digest -u {APIKey}:{APISecret} -d "{parameter}={value};{parameter}={value}"
"https://api.passkit.com/v1/pass/update/template/{templateName}/serial/{serialNumber}/push"```

_By pass-id:_
```
curl --digest -u {APIKey}:{APISecret} -d "{parameter}={value};{parameter}={value}"
"https://api.passkit.com/v1/pass/update/passId/{passId}/push"```

#### PUT Request ####
_By template & serial:_
```
curl --digest -u {APIKey}:{APISecret} -d @{filename} -X PUT
"https://api.passkit.com/v1/pass/update/template/{templateName}/serial/{serialNumber}/push"```

_By pass-id:_
```
curl --digest -u {APIKey}:{APISecret} -d @{filename} -X PUT
"https://api.passkit.com/v1/pass/update/passId/{passId}/push"```


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
* Example: Update pass
* URI: https://code.google.com/p/passkit/wiki/UpdatePass
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

// Set the data array for the fields to update
$data["field1"] = "field 1 data";
$data["field2"] = "field 2 data";
$data["field3"] = "field 3 data";

// Example 1: this example shows you how to set the pass via the combination of template_name & pass_serial, and then update the pass data
$pk->set_pass_serial($pass_serial, $template_name);
// Validate pass
$pk->pass_validate();
// Update pass
$pk->pass_update($data);

// Example 2: this example shows you how to set the pass via the unique pass id, and then update the pass data (use either example 1 or 2)
$pk->set_pass_id($unique_pass_id);
// Validate pass
$pk->validate_pass();
// Update pass
$pk->pass_update($data);
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

        // Set the data dictionary
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["field 1"] = "Field 1 data";
        data["field 2"] = "Field 2 data";
        data["field 3"] = "Field 3 data";

        // There are 2 ways to update a pass, via templat & serial combination, or via unique pass id.

        // Example 1: this example shows you how to update the pass via the combination of template_name & pass_serial
        PassKitResponse result = pk.UpdatePass(template_name, pass_serial, data, true);
        // Do something with result

        // Example 2: this example shows you how to set the pass via the unique pass id
        PassKitResponse result2 = pk.UpdatePass(unique_pass_id, data, true);
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