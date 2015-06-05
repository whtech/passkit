# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Get Unique Pass ID (by share ID) #

| **URI** | `https://api.passkit.com/v1/pass/shareid/`<font color='blue'>{shareId}</font><font color='grey'> <i>/full</i> (optional)</font><font color='grey'> <i>/?format=xml</i> (optional)</font> |
|:--------|:-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Verb** | GET                                                                                                                                                                                      |
| **Auth** | Yes                                                                                                                                                                                      |

This method performs a look-up based upon the share ID of the pass. The share ID is another unique identifier for the pass that is used to determine parent/child relationships between passes.

The method returns the unique pass ID for the pass if it finds the record with <font color='blue'>{shareId}</font>.

## URL Parameters ##

  * <font color='blue'><b>shareId</b></font> <font color='green'><i>(string)</i></font> The share ID of the pass.

### cURL Syntax ###

```
curl --digest -u {APIKey}:{APISecret} "https://api.passkit.com/v1/pass/shareid/{shareId}"```


---


## Response Examples ##

#### JSON Format ####

```json

{
"success": true,
"uniqueID": "uniqueId"
}```

#### XML Format ####

_Note that for XML responses, spaces in tag names will be replaced by 'middle dot' (·).  If a tag starts with an invalid character (E.g. a Number), the tag will be prefixed with two underscores (`__`_)_```

<?xml version="1.0"?>
<PassKit_API_Response>
    <success>1</success>
    <uniqueID>uniqueId</uniqueID>
</PassKit_API_Response>
```_

### Response Parameters ###
  * <font color='blue'>success</font><font color='green'><i>(string)</i></font>
    * Will return <font color='purple'>true</font> for a successful submission, or will not be present in the case of an error.
  * <font color='blue'>uniqueId</font><font color='green'><i>(array)</i></font>
    * The unique pass ID of the pass.


---


<table border='0'>
<blockquote><tr>
<blockquote><td width='361'></td>
<td width='353'><a href='http://PassKit.com/'>PassKit Home Page</a></td>
<td width='128'><a href='https://create.passkit.com'>Register with PassKit</a></td>
</blockquote></tr>
</table>