# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Authenticate #

| **URI** | `https://api.passkit.com/v1/authenticate `<font color='grey'> <i>/?format=xml</i> (optional)</font> |
|:--------|:----------------------------------------------------------------------------------------------------|
| **Verb** | GET                                                                                                 |
| **Auth** | Yes                                                                                                 |

Authenticates access to the API. Returns true (bool) on successful authentication, or error message on unsuccessful authentication.

### cURL Syntax ###

```
curl --digest -u {APIKey}:{APISecret} "https://api.passkit.com/v1/authenticate"```

---


## Response Examples ##

A successful authentication should receive the following response:

#### JSON Format ####

```json

{
"success": true
}```

#### XML Format ####

_Note that for XML responses, spaces in tag names will be replaced by 'middle dot' (·).  If a tag starts with an invalid character (E.g. a Number), the tag will be prefixed with two underscores (`__`_)_```
<?xml version="1.0"?>
<PassKit_API_Response>
     <success>1</success>
</PassKit_API_Response>
```_

### Response Parameters ###
  * <font color='blue'>success</font><font color='green'><i>(string)</i></font>
    * Will return <font color='purple'>true</font> for a successful submission, or will not be present in the case of an error.


<table border='0'>
<blockquote><tr>
<blockquote><td width='361'></td>
<td width='353'><a href='http://PassKit.com/'>PassKit Home Page</a></td>
<td width='128'><a href='https://create.passkit.com'>Register with PassKit</a></td>
</blockquote></tr>
</table>