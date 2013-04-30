<?php
/**
* Example: Issue pass
* URI: https://code.google.com/p/passkit/wiki/UpdatePass
*/

// Include passkit api file
require_once realpath(dirname(__FILE__)  . '/../../../../SDK/class-PassKit.php');
// Include config file
require_once realpath(dirname(__FILE__)  . '/../../../config.php');

// Create new PassKit instance
$pk = new PassKit($api_key, $api_secret);

// Test API connection - no need to do this in live environment;
if (!$pk->pk_test_connection())
{
	echo "<span class=\"error\">API Connection Error - check API Keys.</span>";
	die;
}

// Check input and set the data array
if(isset($_POST["update_pass_balance"]) && !empty($_POST["update_pass_balance"]))
{
	$data["Outstanding balance"] = $_POST["update_pass_balance"];
}
else
{
	echo "<span class=\"error\">Balance is invalid.</span>";
	die;
}

// Set the pass and update with the new balance
$pk->set_pass_id($_POST["unique_pass_id"]);
// Need to call pass_validate before doing the update
$pk->pass_validate();
$pk_result = $pk->pass_update($data);

if($pk_result)
{
	echo "<span class=\"success\">Pass updated.</a></span>";
}
else
{
	echo "<span class=\"error\">Could not update pass. Check if the template name is correct.</span>";
}
?>