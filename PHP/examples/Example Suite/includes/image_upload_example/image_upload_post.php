<?php
/**
* Example: Upload image
* URI: https://code.google.com/p/passkit/wiki/UploadImage
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

// Check for a valid image. Keep in mind that we are updating the stripImage of the pass
if (isset($_FILES["stripImage"]) && !($_FILES["stripImage"]['error'] > 0))
{
	$imageID = $pk->pk_image_upload("strip", $_FILES["stripImage"]["tmp_name"], $_FILES["stripImage"]["type"]);

	// if an imageID is returned, then we update the pass with that ID
	if ($imageID)
	{
		// Set data array
		$data["stripImage"] = $imageID;

		// Set the pass and update with the new image
		$pk->set_pass_id($_POST["unique_pass_id"]);
		// Need to call pass_validate before doing the update
		$pk->pass_validate();
		// Update the pass with new stripimage ID
		$pk_result = $pk->pass_update($data);
		
		if($pk_result)
		{
			echo "<span class=\"success\">Pass updated.</a></span>";
		}
		else
		{
			echo "<span class=\"error\">Could not update pass. Check if the template name is correct.</span>";
		}
	}
	else
	{
		echo "<span class=\"error\">Something went wrong with the image upload. Please try again (script only accepts GIF, JPG & PNG).</span>";
	}
}
else
{
	echo "<span class=\"error\">Something went wrong with the image upload. Please try again (script only accepts GIF, JPG & PNG).</span>";
}
?>