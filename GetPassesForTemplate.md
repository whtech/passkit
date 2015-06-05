# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Get Passes For Template #

| **URI** | `https://api.passkit.com/v1/template/`<font color='blue'>{templateName}</font>`/passes` <font color='grey'> <i>/?format=xml</i> (optional)</font> |
|:--------|:--------------------------------------------------------------------------------------------------------------------------------------------------|
| **Verb** | GET                                                                                                                                               |
| **Auth** | Yes                                                                                                                                               |

This method returns some basic template information and all the passes (pass meta -and field data) that were issued for the given template with <font color='blue'>{templateName}</font>.

## URL Parameters ##

  * <font color='blue'><b>templateName</b></font> <font color='green'><i>(string)</i></font> The name of the template

### cURL Syntax ###

```
curl --digest -u {APIKey}:{APISecret} "https://api.passkit.com/v1/template/{templateName}/passes"```


---


## Response Examples ##

#### JSON Format ####

```json

{
"success": true,
"templateName": "My template",
"templateLastUpdated": "2013-02-08T01:02:55+00:00",
"totalPasses": 2,
"passRecords": {
"pass_1": {
"passMeta": {
"passStatus": "Active",
"installIP": "123.123.123.123",
"installIPCountry": "HK",
"installIPCity": "Central District",
"recoveryURL": "http://recoveryUrl.com",
"issueDate": "2013-02-10T08:19:30+00:00",
"lastDataChange": "2013-03-02T04:56:47+00:00",
"lastPushRefresh": "2013-02-10T14:45:08+00:00",
"lastManualRefresh": "2013-03-02T04:57:09+00:00",
"passExpires": "2013-03-02T04:57:09+00:00",
"passbookSerial": "uniqueSerial",
"uniqueID": "uniqueId",
"serialNumber": "serialNumber",
"shareID": "shareid"
},
"passData": {
"Student·name": "Test student",
"Balance": "8",
"Issue·date": "2013-02-10",
"Expiry·date": "2014-02-10",
"barcodeContent": "content"
}
},
"pass_2": {
"passMeta": {
"passStatus": "Active",
"installIP": "123.123.123.123",
"installIPCountry": "HK",
"installIPCity": "Central District",
"recoveryURL": "http://recoveryUrl.com",
"issueDate": "2013-02-10T08:19:30+00:00",
"lastDataChange": "2013-03-02T04:56:47+00:00",
"lastPushRefresh": "2013-02-10T14:45:08+00:00",
"lastManualRefresh": "2013-03-02T04:57:09+00:00",
"passExpires": "2013-03-02T04:57:09+00:00",
"passbookSerial": "uniqueSerial",
"uniqueID": "uniqueId",
"serialNumber": "serialNumber",
"shareID": "shareid"
},
"passData": {
"Student·name": "Test student 2",
"Balance": "8",
"Issue·date": "2013-02-10",
"Expiry·date": "2014-02-10",
"barcodeContent": "content"
}
}
}
}
```

#### XML Format ####

_Note that for XML responses, spaces in tag names will be replaced by 'middle dot' (·).  If a tag starts with an invalid character (E.g. a Number), the tag will be prefixed with two underscores (`__`_)_```
<?xml version="1.0"?>
<PassKit_API_Response>
    <success>1</success>
    <templateName>My template</templateName>
    <templateLastUpdated>2013-02-08T01:02:55+00:00</templateLastUpdated>
    <totalPasses>2</totalPasses>
    <passRecords>
        <pass_1>
            <passMeta>
                <passStatus>Active</passStatus>
                <installIP>123.123.123.123</installIP>
                <installIPCountry>HK</installIPCountry>
                <installIPCity>Central District</installIPCity>
                <recoveryURL>http://recoveryUrl.com</recoveryURL>
                <issueDate>2013-02-10T08:19:30+00:00</issueDate>
                <lastDataChange>2013-03-02T04:56:47+00:00</lastDataChange>
                <lastPushRefresh>2013-02-10T14:45:08+00:00</lastPushRefresh>
                <lastManualRefresh>2013-03-02T04:57:09+00:00</lastManualRefresh>
                <passExpires>2013-03-02T04:57:09+00:00</passExpires>
                <passbookSerial>uniqueSerial</passbookSerial>
                <uniqueID>uniqueId</uniqueID>
                <serialNumber>serialNumber</serialNumber>
                <shareID>shareid</shareID>
            </passMeta>
            <passData>
                <Student·name>Test student</Student·name>
                <Balance>8</Balance>
                <Issue·date>2013-02-10</Issue·date>
                <Expiry·date>2014-02-10</Expiry·date>
                <barcodeContent>content</barcodeContent>
            </passData>
        </pass_1>
	<pass_2>
            <passMeta>
                <passStatus>Active</passStatus>
                <installIP>123.123.123.123</installIP>
                <installIPCountry>HK</installIPCountry>
                <installIPCity>Central District</installIPCity>
                <recoveryURL>http://recoveryUrl.com</recoveryURL>
                <issueDate>2013-02-10T08:19:30+00:00</issueDate>
                <lastDataChange>2013-03-02T04:56:47+00:00</lastDataChange>
                <lastPushRefresh>2013-02-10T14:45:08+00:00</lastPushRefresh>
                <lastManualRefresh>2013-03-02T04:57:09+00:00</lastManualRefresh>
                <passExpires>2013-03-02T04:57:09+00:00</passExpires>
                <passbookSerial>uniqueSerial</passbookSerial>
                <uniqueID>uniqueId</uniqueID>
                <serialNumber>serialNumber</serialNumber>
                <shareID>shareid</shareID>
            </passMeta>
            <passData>
                <Student·name>Test student 2</Student·name>
                <Balance>8</Balance>
                <Issue·date>2013-02-10</Issue·date>
                <Expiry·date>2014-02-10</Expiry·date>
                <barcodeContent>content</barcodeContent>
            </passData>
        </pass_2>
    </passrecords>
</PassKit_API_Response>
```_

### Response Parameters ###

#### Template parameters ####

  * <font color='blue'>success</font><font color='green'><i>(string)</i></font>
    * Will return <font color='purple'>true</font> for a successful submission, or will not be present in the case of an error.
  * <font color='blue'>templateName</font><font color='green'><i>(string)</i></font>
    * The name of the template.
  * <font color='blue'>templateLastUpdated</font><font color='green'><i>(date)</i></font>
    * The date when the template was last updated.
  * <font color='blue'>totalPasses</font><font color='green'><i>(int)</i></font>
    * The total amount of issued passes.
  * <font color='blue'>passRecords</font><font color='green'><i>(array)</i></font>
    * An array of all the pass records.

#### Pass meta-data parameters ####

  * <font color='blue'>passStatus</font><font color='green'><i>(string)</i></font>
    * The status of the pass.
  * <font color='blue'>installIp</font><font color='green'><i>(string)</i></font>
    * The installation IP address of the device when the pass was installed.
  * <font color='blue'>installIPCountry</font><font color='green'><i>(string)</i></font>
    * The country that the device was in when the pass was installed.
  * <font color='blue'>installIPCity</font><font color='green'><i>(string)</i></font>
    * The city that the device was in when the pass installed.
  * <font color='blue'>recoveryURL</font><font color='green'><i>(string)</i></font>
    * The recovery URL of the pass.
  * <font color='blue'>issueDate</font><font color='green'><i>(date)</i></font>
    * The issue date of the pass.
  * <font color='blue'>lastDataChange</font><font color='green'><i>(date)</i></font>
    * The time when data was last changed on the pass.
  * <font color='blue'>lastPushRefresh</font><font color='green'><i>(date)</i></font>
    * The time when data was pushed last to the pass.
  * <font color='blue'>lastManualRefresh</font><font color='green'><i>(date)</i></font>
    * The last time the user did a manual refresh.
  * <font color='blue'>passExpires</font><font color='green'><i>(date)</i></font>
    * The expiry date of the pass.
  * <font color='blue'>passbookSerial</font><font color='green'><i>(string)</i></font>
    * The PassBook serial of the pass.
  * <font color='blue'>uniqueID</font><font color='green'><i>(string)</i></font>
    * The unique pass-id of the the pass.
  * <font color='blue'>serialNumber</font><font color='green'><i>(string)</i></font>
    * The serial number of the pass.
  * <font color='blue'>shareID</font><font color='green'><i>(string)</i></font>
    * The share-id of the pass.

#### Pass field-data parameters ####

  * <font color='blue'>{fieldName}</font><font color='green'><i>(string)</i></font>
    * Returns the name of each dynamic 'value' field, together with the type of data the field accepts. The type value will be either one of <font color='purple'>text</font>, <font color='purple'>number</font>,  <font color='purple'>date</font>,  <font color='purple'>datetime</font> or <font color='purple'>currency</font>.
  * <font color='blue'>barcodeContent</font><font color='green'><i>(string)</i></font>
    * If the template allows for the barcode encoded content to be changed, this parameter will be returned with a value of <font color='purple'>text</font>


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
            // GetPasses will get the passes for the template_name
            PassKitResponse result = pk.GetPasses(template_name);    
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