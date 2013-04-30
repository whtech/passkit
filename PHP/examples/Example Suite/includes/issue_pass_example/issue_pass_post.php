<?php
/**
* Example: Issue pass
* URI: https://code.google.com/p/passkit/wiki/IssuePass
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
$data = array();
if(isset($_POST["issue_pass_name"]) && !empty($_POST["issue_pass_name"]))
{
	$data["Name"] = $_POST["issue_pass_name"];
}
else
{
	echo "<span class=\"error\">Name is invalid.</span>";
	die;
}

if(isset($_POST["issue_pass_balance"]) && !empty($_POST["issue_pass_balance"]))
{
	$data["Outstanding balance"] = $_POST["issue_pass_balance"];
}
else
{
	echo "<span class=\"error\">Balance is invalid.</span>";
	die;
}

// Now issue the pass with this data
$pk_result = $pk->pk_issue_pass($template_name, $data);

if(isset($pk_result->success))
{
	echo "<span class=\"success\"><a href=\"".$pk_result->url."\"><img src=\"img/Add_to_Passbook_US_UK@2x.png\" width=\"122px\" height=\"40px\" alt=\"Add to Passbook\"/></a></span>";
}
else
{
	echo "<span class=\"error\">Could not issue pass. Check if the template name is correct.</span>";
}
?>