# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Issue Pass #

| **URI** | `https://api.passkit.com/v1/pass/issue/template/`<font color='blue'>{templateName}</font><font color='grey'> <i>/?format=xml</i> (optional)</font> |
|:--------|:---------------------------------------------------------------------------------------------------------------------------------------------------|
| **Verb** | GET, POST                                                                                                                                          |
| **Auth** | Yes                                                                                                                                                |

This method is used for creating passes. It accepts the parameters returned by the [Get Template Field Names](GetTemplateDetails.md) method, plus relevance fields for date and for up to 10 locations.

We have tried to make this method as accessible as possible.  Requests can be issued as a GET or POST request using key/value pairs, or by POSTing a JSON or XML file to the URI.

A successful submission will return the serial number and URL of the created pass.

## URI Parameters ##

  * <font color='blue'><b>templateName</b></font> <font color='green'><i>(string)</i></font> The name of the template from which the pass will be created

## Request Parameters ##

#### Generic Parameters ####

  * <font color='blue'>{fieldName}</font><font color='green'><i>(mixed)</i></font> <font color='grey'><i>optional</i></font>
    * The value for a dynamic field within the template. The submitted data type must match the data type of the field, as specified in the template.  Date values must be in ISO 8601 format.  If not provided, the pass will return the default value for the field or an empty string or zero value for number and currency fields if no default is present.
  * <font color='blue'>{fieldName}<code>_</code>changeMessage</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * The text of the notification message that will be displayed when the field value changes.  Include %@ in the string to include the new value in the notification.
  * <font color='blue'>{fieldName}<code>_</code>label</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * The value of a dynamic label field. Label values are always treated as text.
  * <font color='blue'>serialNumber</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * For templates that require a serial number to be provided at pass creation. The serial provided must be unique within the template.
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
    * To set the label color. Accepts a 6 digit HEX color code.
  * <font color='blue'>foregroundColor / foregroundColour</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * To set the foreground color. Accepts a 6 digit HEX color code.
  * <font color='blue'>backgroundColor / backgroundColour</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * To set the background color. Accepts a 6 digit HEX color code.

#### Image Parameters ####

The images on each pass can be set by using the image parameters.
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

#### Install passthru parameters ####

Optionally, you can set the parameters related to latitude and longitude of where the device was when the pass was installed. If you don't set these parameters, they will default to the values of the server making the API call.

  * <font color='blue'>installLatitude</font><font color='green'><i>(float)</i></font> <font color='grey'><i>optional</i></font>
    * The latitude of the location.
  * <font color='blue'>installLongitude</font><font color='green'><i>(float)</i></font> <font color='grey'><i>optional</i></font>
    * The longitude of the location.
  * <font color='blue'>locationDeclined</font><font color='green'><i>(bool)</i></font> <font color='grey'><i>optional</i></font>
    * Only used and set to true if the user declined to give their location data when installing a pass.
  * <font color='blue'>installIP</font><font color='green'><i>(string)</i></font> <font color='grey'><i>optional</i></font>
    * The IP address of the device.

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
https://api.passkit.com/v1/pass/issue/template/My%20Pass%20Template/?Check%20In=2012-10-06T00:00:00+08:00&CheckOut=2012-10-08T00:00:00+08:00&... etc.```

#### JSON Format ####
```

{
"Check In": "2012-10-06T00:00:00+08:00",
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
"location1locationAlert": "Enjoy your stay",
"recoveryEmail": "daniel.allen@example.com"
}
```

#### XML Format ####
_Note that for XML requests, spaces in tag names must be replaced by 'middle dot' (·).  If a tag starts with an invalid character (E.g. a Number), the tag should be prefixed with two underscores (`__`_)_```
<?xml version="1.0" encoding="UTF-8" ?>
<PassKit_API_Request>
	<Check·In>2012-10-06T00:00:00+08:00</Check·In>
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
	<recoveryEmail>daniel.allen@example.com</recoveryEmail>
</PassKit_API_Request>
```_

### cURL Syntax ###
#### GET Request ####
```
curl --digest -u {APIKey}:{APISecret}
"https://api.passkit.com/v1/pass/issue/template/{templateName}/?{parameter}={value}&{parameter}={value}"```

#### POST Request (key/value) ####
```
curl --digest -u {APIKey}:{APISecret} -d "{parameter}={value};{parameter}={value}"
"https://api.passkit.com/v1/pass/issue/template/{templateName}"```

#### POST Request (file) ####
```
curl --digest -u {APIKey}:{APISecret} -F @{filename} -X POST "https://api.passkit.com/v1/pass/issue/template/{templateName}"```

---


## Response Examples ##

#### JSON Format ####

```

{
"success": true,
"serial": "0905188361315670",
"url": "https:\/\/r.pass.is\/DXerKIGmXyrx"
}
```

#### XML Format ####
```
<?xml version="1.0"?>
<PassKit_API_Response>
	<success>1</success>
	<serial>0905188361315670</serial>
	<url>https://r.pass.is/DXerKIGmXyrx</url>
</PassKit_API_Response>
```

### Response Parameters ###
  * <font color='blue'>success</font><font color='green'><i>(string)</i></font>
    * WIll return <font color='purple'>true</font> for a successful submission, or will not be present in the case of an error.
  * <font color='blue'>serial</font><font color='green'><i>(string)</i></font>
    * The serial number of the issued pass.
  * <font color='blue'>url</font><font color='green'><i>(string)</i></font>
    * The URL for downloading the issued pass.

---


## Implementation examples ##

Download latest PassKit PHP -and/or C# SDK: https://code.google.com/p/passkit/downloads/list

#### PHP Implementation ####

```
<?php
/**
* Example: Issue pass
* URI: https://api.passkit.com/v1/pass/issue/template/{templateName}
*/

// Include passkit api file
require_once ('class-PassKit.php');

// Set variables
$apiKey = "apiKey"; // Add your PassKit API Key
$apiSecret = "apiSecret"; // Add your PassKit API Secret
$template_name = "My template"; // Add your template name here

// Create new PassKit instance
$pk = new PassKit($apiKey, $apiSecret);

// Set the data array
$data["field1"] = "field 1 data";
$data["field2"] = "field 2 data";
$data["field3"] = "field 3 data";

// Now issue the pass with this data
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
        // Set the image template
        string template_name = "My template";

        // Initialize new instance of PassKit API wrapper
        PassKit pk = new PassKit(apiAccount, apiSecret);

        // Set the data dictionary
        Dictionary<string, string> data = new Dictionary<string, string>();
        data["field 1"] = "Field 1 data";
        data["field 2"] = "Field 2 data";
        data["field 3"] = "Field 3 data";

        // Issue a new pass with the data array
        PassKitResponse result = pk.IssuePass(template_name, data);

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