# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Update Template #

| **URI** | `https://api.passkit.com/v1/template/update/`<font color='blue'>{templateName}</font> <font color='grey'> <i>/push</i> (optional)</font> <font color='grey'> <i>/?format=xml</i> (optional)</font> |
|:--------|:---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Verb** | GET, POST, PUT                                                                                                                                                                                     |
| **Auth** | Yes                                                                                                                                                                                                |

This method allows for static fields of default values of dynamic fields of templates to be changed (and potentially pushed) to all passes.

If you wish for the update to be immediately pushed to all devices with an active pass, include push as the last segment of the URL.

## URL Parameters ##

  * <font color='blue'><b>templateName</b></font> <font color='green'><i>(string)</i></font> The name of the template for which you want to update the default values.

## Request Parameters ##

  * <font color='blue'>{fieldName}</font><font color='green'><i>(mixed)</i></font> <font color='grey'><i>optional</i></font>
    * The default value for a dynamic field within the template. The submitted data type must match the data type of the field, as specified in the template. Date values must be in ISO 8601 format.

### cURL Syntax ###

#### GET Request ####

```
curl --digest -u {APIKey}:{APISecret}
"https://api.passkit.com/v1/template/update/{templateName}/push?{parameter}={value}&{parameter}={value}"```

#### POST Request ####

```
curl --digest -u {APIKey}:{APISecret} -d "{parameter}={value};{parameter}={value}"
"https://api.passkit.com/v1/template/update/{templateName}/push"```

#### PUT Request ####

```
curl --digest -u {APIKey}:{APISecret} -d @{filename} -X PUT
"https://api.passkit.com/v1/template/update/{templateName}/push"```


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


<table border='0'>
<blockquote><tr>
<blockquote><td width='361'></td>
<td width='353'><a href='http://PassKit.com/'>PassKit Home Page</a></td>
<td width='128'><a href='https://create.passkit.com'>Register with PassKit</a></td>
</blockquote></tr>
</table>