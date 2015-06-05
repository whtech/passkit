# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

## Authentication & Access ##

Our API uses HTTP Digest authentication.  This means that your API secret never leaves your machine.

HTTP Digest is compatible with all modern web browsers which provides an option to use simple HTML forms to POST or GET to and from the API.

Our Digest realm is rotated every 2 minutes.

---

## cURL Syntax and Examples ##
To access the API from a Mac or Linux command line (or from the console of a Windows machine with cURL installed), you can use the following cURL commands:

### For GET requests ###

```
curl --digest -u {API Key}:{API Secret} "https://api.passkit.com/{version}/{method URL}"```

**Example GET Request - List the fields available for 'My Great Pass' template**

```
curl --digest -u ff0b04afe47feacd09a850d9a1dd91d0:kFTlvlfrjU/djar.V3tO0uyvoF0svLGVhM7ccGN.ek80GdqcJNcju
"https://api.passkit.com/v1/template/My%20Great%20Pass/fieldnames"```

---

### For POST Requests ###

```
curl --digest -u {API Key}:{API Secret} --data "{method parameters}"
-F "{POST Fieldname}=@{path and filename};{MIME Type}"
-X POST "https://api.passkit.com/{version}/{method URL}"```

**Example POST Request - Uploading a thumbnail image** _(an unauthenticated call)_

```
curl  -F "image=@/Users/Percy/Pictures/Percy.jpg;type=image/jpeg"
-X POST "https://api.passkit.com/v1/image/add/thumbnail"```

**Example POST Request - Issue a new pass for your 'My Great Pass' template and retrieve the results in XML format**

```
curl --digest -u ff0b04afe47feacd09a850d9a1dd91d0:kFTlvlfrjU/djar.V3tO0uyvoF0svLGVhM7ccGN.ek80GdqcJNcju
--data "Issued To=Percy PassKit&Balance=20"
"https://api.passkit.com/v1/pass/issue/template/My%20Great%20Pass/?format=xml"```

**Example POST Request - Issue a batch of passes for 'My Great Pass'**

```
curl --digest -u ff0b04afe47feacd09a850d9a1dd91d0:kFTlvlfrjU/djar.V3tO0uyvoF0svLGVhM7ccGN.ek80GdqcJNcju
-d @batch.json "https://api.passkit.com/v1/pass/issue/batch/template/My%20Great%20Pass"```

---

### For PUT Requests ###

**Example PUT Request - Update the balance and reward tier of 'My Great Pass', serial number 1234 and push an update**

```
curl --digest -u  ff0b04afe47feacd09a850d9a1dd91d0kFTlvlfrjU/djar.V3tO0uyvoF0svLGVhM7ccGN.ek80GdqcJNcju
-d "Balance=29.88&Reward Tier=Gold" -X PUT
"https://api.passkit.com/v1/pass/update/template/My%20Great%20Pass/serial/1234/push"```

---

Of course, you don't (and probably will not) have to use cURL directly from the command line, however the above examples are provided as a base to help you configure your solution.

## PHP Generic Example ##
```
<?php
$api_key = 'API_KEY';
$api_secret = 'API_SECRET';

$api_url = "https://api.passkit.com/v1/pass/issue/template/test"; //add the full url to the method

/* for calls that require parameters
$params = array(
 	'parameter'=> 'value',
 	'parameter' => $_POST['value'], // get the value from a form submission
 	'etc' => '',
 ) ;
*/

$session = curl_init($api_url);
// for posting parameters
// curl_setopt ($session, CURLOPT_POST, true);
// curl_setopt ($session, CURLOPT_POSTFIELDS, $params);
curl_setopt ($session, CURLOPT_HTTPAUTH, CURLAUTH_DIGEST);
curl_setopt ($session, CURLOPT_USERPWD, $api_key . ':' . $api_secret);
curl_setopt ($session, CURLOPT_HEADER, false);
curl_setopt ($session, CURLOPT_USERAGENT,'PassKit API v1');
curl_setopt ($session, CURLOPT_RETURNTRANSFER, true);
curl_setopt ($session, CURLOPT_SSL_VERIFYPEER, false); // required for older cURL libraries that don't support TLS
$response = curl_exec($session);
curl_close($session);

$result = ($response ? json_decode($response) : false); // if there is a response, then decode it into a JSON object
if (isset($result->success) && $result->success) { // check if the success parameter is present and true
	// do stuff here like initiate another CURL session to grab the .pkpass from $result->url to send back to device

} else {
	var_dump($response); // debug the response;
}
```

---

We'll shortly be publishing code samples in the major languages to get you started submitting to and querying the API as easily as possible.


---


<table border='0'>
<blockquote><tr>
<blockquote><td width='361'></td>
<td width='353'><a href='http://PassKit.com/'>PassKit Home Page</a></td>
<td width='128'><a href='https://create.passkit.com'>Register with PassKit</a></td>
</blockquote></tr>
</table>