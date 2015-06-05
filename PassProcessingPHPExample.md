# <font color='#ff0000'>Note: This project has moved to <a href='https://passkit.com/documentation/'>PassKit.com</a>.</font> #

# Introduction #
Interacting with PassKit is really quite simple – especially when compared to interacting with Apple directly for Passbook passes. The following are some excerpts from a PassKit PHP class with explanations. (The full class with documentation is included as a download.)

Nope: due to some wiki reformatting the code below has some strangeness here and there. See the php class in the download for the properly formatted version.

The basic flow is as follows:

Initiate class with the PassKit account details
  1. Set the scanned pass ID or pass serial + template name
  1. Validate the pass with PassKit
  1. Perform any actions as necessary


# cURL #
Communication with the PassKit API from PHP is done with cURL. In this class we have a single function for doing the cURL connection which takes parameters for URL path and post variables to allow us to execute different actions from individual public functions.
Note that the PassKit account ID and Secret are required and are stored in the class properties on initiation so are not passed to this function as parameters.

```php

// {{{ pk_query()
/**
* PassKit Query
*
* The cURL query function to PassKit. Handles all generic parts
* of this activity and can be called from action specific functions
* that provide specific requests.
*
* @author Thomas Smart <dev*ThomasSmart*c0m>
* @category PassKit Communication
* @access private
* @param String $path URL path to use for query
* @param Array $post Additional post parameters to send with the query, optional
* @return Boolean True on successful connection
*/
private function pk_query($path='',$post=array()) {
// Full URL to use for the query
$api_url = "https://api.passkit.com/v1/".$path;

// initiate curl
$session = curl_init($api_url);

// If post-field parameters have been provided
if(!empty($post)){
// Turn it into a string
$post_string='';
foreach($post as $key=>$value){
$post_string .= urlencode($key).'='.urlencode($value).'&';
}
$post_string = rtrim($post_string,'&');

// Set cURL post options
curl_setopt ($session, CURLOPT_POST, true);
curl_setopt ($session, CURLOPT_POSTFIELDS, $post_string);
}

// Set cURL options
curl_setopt ($session, CURLOPT_HTTPAUTH, CURLAUTH_DIGEST);
curl_setopt ($session, CURLOPT_HEADER, false);
curl_setopt ($session, CURLOPT_RETURNTRANSFER, true);
curl_setopt ($session, CURLOPT_SSL_VERIFYPEER, false); // required for older cURL libraries that don't support TLS

// Account ID and secret
curl_setopt ($session, CURLOPT_USERPWD, $this->account.':'.$this->secret);

// Execute then close curl connection
$response = curl_exec($session);
curl_close($session);

// If there is a response, then decode it into a JSON object
$result = ($response ? json_decode($response) : false);

// check if the success parameter is present and true
if(isset($result->success) && $result->success) {
// Store the result object in the property
$this->pk_result = $result;

// Return success
return true;
}

// An error occurred
$this->pk_result = NULL;

// Print error
$this->error('PassKit query error. Curl response: <pre>'.print_r($response,true).'< /pre>',print_r(debug_backtrace(),true)); // debug the response;

// Return fail
return false;
}
// }}}
```

Basically what we are doing with this function is setting up a cURL connection to the API URL with an optional path and, if available, passing optional post variables. We also need to login with auth digest using the PassKit account ID and Secret (provided by PassKit when purchasing an account).

The returning result will be JSON formatted so the next step is to decode this into a PHP object. Then we look for the “success” key and, if found, it will store the object in the property “pk\_result” which can be accessed by the different functions afterwards. This query function will always return a boolean true/false depending on if the “success” key was found or not in the JSON result.

# Basic Functions #

Each “action” function in the class will call the above cURL function and pass a URL and optional post variables. The function then checks if the call returned true or false and, if true, it can get the result from the system variable. If false, it can print out an error.

For example, the following is a very simple function that just connects to the PassKit application and makes sure that the account details are correct.

```php

// {{{ pk_test_connection()
/**
* Connection test
*
* Test PassKit connection and authentication
*
* @author Thomas Smart <dev*ThomasSmart*c0m>
* @category PassKit Communication
* @access public
* @return Boolean True on successful authentication
*/
public function pk_test_connection(){
return $this->pk_query('authenticate/');
}
// }}}
```

To run this you would include the PassKit class, initiate it with the account details and then call the function. There is no return data other than the success or error status which translates to true or false in the query function return.

```php

// Include PassKit class
require_once('PassKit.php');

// Initiate class
$passKit = new PassKit($pk_account,$pk_secret);

// Test authentication
if($passKit->pk_test_connection()){
echo 'Hurray, connected successfully';

}else{
echo 'Failed to authenticate :( ';
}
```

As this initiates a connection to the API you don’t really want to do this every time you perform some update to a pass. I use it just once to test new or updated account details and for debugging.

There are 2 ways (with this class) that you can submit a pass for validation (which needs to be done before you can execute any updates on the pass).

1. The Pass ID. This is the quickest way.  You can include the PID into the passKit pass barcode when creating a pass by using %pid as the barcode content. As the PID is for a specific unique pass the PassKit API will know exactly what you are requesting and can provide the pass details and template name using this alone. It is also possible to include additional information in the barcode if you need it for integration or other things. As long as the Pass ID comes last and separated by a – from any previous content. Note that this is not a PassKit API requirement but simply how I have structured this PHP class.

```php

// {{{ set_pass_id()
/**
* Set pass ID
*
* Call this function with the Pass ID. It will be santized
* and stored as a property. If it is empty it will return an error.
*
* @author Thomas Smart <dev*ThomasSmart*c0m>
* @category Validation and Retrieval
* @access public
* @param String $pass_id Pass code as scanned from barcode (required)
* @return Boolean
*/
public function set_pass_id($pass_id) {
// Split it up by "-" in case multiple strings have been passed
$pass_id = explode('-',$pass_id);

// Last one should be the PID (set with %pid in pass creator / front content / text to encode
// santize this for security
$this->pass_id = $this->sanitize($pass_id[count($pass_id)-1]);

// Pass ID should not be empty
if($pass_id == ''){
// Print error
$this->error('Pass ID is required and cannot be empty.',debug_backtrace());

// Return fail
return false;
}

// return success
return true;
}
// }}}
```

2.  Serial number + template name. As a backup you could print out the serial number below the barcode by using %@ as the barcode alt-text. Staff can then manually type in this number if their barcode scanner is not working. However, with a serial number alone PassKit will not know which pass it is, hence the need to also include the template name.

The variables returned with this query differ from the Pass ID query but it includes the Pass ID so in this function we can select the Pass ID and pass it to the “get pass details from pass id” function that is used above for option 1. This allows the flow to continue as if a Pass ID was entered.

```php

// {{{ set_pass_serial()
/**
* Set pass ID via serial
*
* Call this function with the params Pass Serial and Template Name.
* Using these it will query PassKit for the Pass ID and feed that
* into the set_pass_id function.
*
* set the Pass Serial and call set_pass_id()
*
* @author Thomas Smart <dev*ThomasSmart*c0m>
* @category Validation and Retrieval
* @access public
* @param String $serial Pass serial (required)
* @param String $template Pass template (required)
* @return Boolean
*/
public function set_pass_serial($serial,$template) {
// They should not be empty
if($serial == '' || $template == ''){
// Print error
$this->error('Pass Serial and Template are required and cannot be empty.',debug_backtrace());

// Return fail
return false;
}

// send the template name and pass serial to passkit for a response
// if the call fails then return fail
if(!$this->pk_query("pass/get/template/$template/serial/$serial")){
// Print error
$this->error('Pass Serial and Template combination not recognized by PassKit.',debug_backtrace());

// Return fail
return false;
}

// If the pass ID does not exist in the return then return fail
if(!isset($this->pk_result->uniqueID)){
// Print error
$this->error('Pass Serial and Template combination not recognized by PassKit.',debug_backtrace());

// Return fail
return false;
}

// query was success and we have a valid Pass ID. Send this to the set_pas_id
// function to continue the flow as normal. Return the status of that function.
return $this->set_pass_id($this->pk_result->uniqueID);
}
// }}}
```


Once the Pass ID is set we can validate it by calling a method in the PassKit API that should return a full set of details for the pass or an error on false. Again, the result will be stored as an object in the system variable “pk\_result”.

```php

// {{{ pass_validate()
/**
* Validate Pass
*
* Validate the set Pass ID with PassKit
*
* @author Thomas Smart <dev*ThomasSmart*c0m>
* @category Validation and Retrieval
* @access public
* @return Boolean True on successful validation
*/
public function pass_validate() {
// a pass ID number is required
if($this->pass_id==''){
// Print error
$this->error('Pass ID is required to be set before you can use this function. Please use the set_pass_id($pass_id) function to set the pass ID first.',debug_backtrace());

// Return fail
return false;
}

// Send call to PassKit to validate the pass and return details
if(!$this->pk_query($url_path='pass/get/passid/'.$this->pass_id)){
// Print error
$this->error('PassKit was unable to provide pass details for the pass ID: '.$this->pass_id,debug_backtrace());

// Return fail
return false;
}

// Save pass details to the property
$this->pass_details = array(
"pass_pid"                =>    $this->pass_id,
"serial_number"        =>    $this->pk_result->serialNumber,
"template_name"        =>    $this->pk_result->templateName,
"template_update"    =>    $this->pk_result->templateLastUpdated,
"system_status"        =>    $this->pk_result->passRecord->passMeta->passStatus,
"pass_data"                =>    $this->object2array($this->pk_result->passRecord->passData)
);

// if data-status is found then store in variable and delete from passdata array
if(isset($this->pk_result->passRecord->passData->{'data-status'})){
$pass_status = $this->pk_result->passRecord->passData->{'data-status'};
unset($this->pk_result->passRecord->passData->{'data-status'});

// not found so set default 'Available'
}else{
$pass_status = 'Available';
}

// set pass status in details
$this->pass_details['pass_status'] = $pass_status;

// Return success
return true;
}
// }}}
```


If there were no errors and “false” returns, you can now assume that the pass in question has been fully validated. You can update your application with the status “valid” if that is all you need to do. If you need to perform an action on the pass such as redeem, you can call the function to redeem it.

Almost all pass actions are actually just updates. So the class has a function called update which sets up the generic part of the query and then receives a specific instructions from action-specific functions such as “redeem”.

```php

// {{{ pass_update()
/**
* Update a pass
*
* Update or add dynamic fields for the current pass. The URL path
* is the same for most update actions and the fields to change can
* be passed as a parameter array. Note that adding new fields is
* the same as updating existing fields. Added fields will not
* be visible by the user. Specific frequently used actions are
* available below as their own functions. They will call this
* generic update function with specific instructions.
*
* @author Thomas Smart <dev*ThomasSmart*c0m>
* @category Pass Interaction
* @access private
* @return Boolean True on successful redeem
*/
private function pass_update($fields) {
// pass details are required
if(empty($this->pass_details)){
// Print error
$this->error('Pass details are required to be set before you can use this function. Please use the pass_validate() function to validate the Pass ID with PassKit and set pass details.',debug_backtrace());

// Return fail
return false;
}

// send update to passkit to set the status to redeemed
return $this->pk_query('pass/update/template/'.urlencode($this->pass_details['template_name']).'/serial/'.$this->pass_details['serial_number'].'/push/',$fields);
}
// }}}
```

To redeem a pass we call the redeem function:

```php

// {{{ pass_redeem()
/**
* Redeem Pass
*
* Redeem the pass with PassKit by setting the data-status variable in the
* passData section. This allows us to "redeem" the pass without nuking it.
* additional fields to update can be passed to this function. For example
* to replace an "expire" label and date with a "redeemed" label and date.
*
* @author Thomas Smart <dev*ThomasSmart*c0m>
* @category Pass Interaction
* @access public
* @param  Array $post_fields, additional fields to post with the redeem action
* @return Boolean True on successful redeem
*/
public function pass_redeem($post_fields=array()) {
// pass details are required
if(empty($this->pass_details)){
// Print error
$this->error('Pass details are required to be set before you can use this function. Please use the pass_validate() function to validate the Pass ID with PassKit and set pass details.',debug_backtrace());

// Return false
return false;
}

// action
$action = array("data-status"=>"Redeemed");

// If there are additional fields to update merge them with the action array
if(!empty($post_fields)){
$action = array_merge($action, $post_fields);
}

// send action to passkit to set the status to redeemed
return $this->pass_update($action);
}
// }}}
```

There are several other such functions available in the class.

An example of how to bring this all together and execute it from your processing file.

```php

<PHP

// Variables
$pk_account = "MY_PASSKIT_ACCOUNT_KEY";
$pk_secret = "MY_PASSKIT_ACCOUNT_SECRET";
$pass_id = "SCANNED PASS ID"; // must be a pass created with the same PassKit account used above

// Include PassKit class
require_once('PassKit.php');

// Initiate class
$passKit = new PassKit($pk_account,$pk_secret);

if(!$passKit->set_pass_id($pass_id)){
echo 'This is not a valid Pass ID.';
exit;
}

// validate the pass with PassKit

if(!$passKit->pass_validate()){
echo 'This pass is not valid for this PassKit account.';
exit;
}

// redeem the pass with PassKit

if(!$passKit->pass_redeem($post_redeem)){
echo 'This pass could not be redeemed.';
exit;
}

// success!
echo 'Pass has been validated and redeemed.';
```

# PHP SDK Download #
The PHP SDK can be downloaded at the [Download Page](https://code.google.com/p/passkit/downloads/list).
