<?php
// Check if passId is set
$passId = null;
if(isset($_REQUEST["pid"]))
{
	$passId = $_REQUEST["pid"];
}
else
{
	echo "Pass-id not set";
	die;
}

// Set variables
$apiKey = ""; // Add your PassKit API Key
$apiSecret = ""; // Add your PassKit API Secret
$absAnswerDirPath = dirname(__FILE__).DIRECTORY_SEPARATOR."img".DIRECTORY_SEPARATOR."answers";

// Include passkit api file
require_once realpath(dirname(__FILE__)  . '/../../SDK/class-PassKit.php');

// Set template name
$template_name = "Mystic 8 Ball"; // Must match the template name in your PassKit account

// Create a new PassKit Object
$pk = new PassKit($apiKey, $apiSecret);

// Test API connection - no need to do this in live environment;
if (!$pk->pk_test_connection())
{
	echo "API Connection Error - check API Keys";
	die;
}

// Pick a random image from the images directory
$scannedDir = array_diff(scandir($absAnswerDirPath), array('..', '.'));
$randomImageFile = $scannedDir[array_rand($scannedDir)];

// We want to use the filename of the picture as update text for a passfield, so the following code will do that,
// and replace all _ with spaces.

// Get rid of the extension
$imageNameArray = explode(".", $randomImageFile);
// Build string and replace _ with spaces
$pictureText = str_replace("_", " ", $imageNameArray[0]);

// Check if our array cache is set
$imageCache = "images.bin";
if(!file_exists($imageCache))
{
	file_put_contents($imageCache, "");
}

// Get file contents
$contents = file_get_contents($imageCache);

// If file has contents, then we unserialize it as an array
$imageArray = array();
if(!empty($contents))
{
	$imageArray = unserialize($contents);
}

// Check if our image exists in the cache array (check with hash and filename to be unique), if so we get the passkit image ID
$key = md5_file($absAnswerDirPath.DIRECTORY_SEPARATOR.$randomImageFile).$randomImageFile;
$pkImageId = null;
if(isset($imageArray[$key]))
{
	// If it exists (meaning it was uploaded before), we retrieve the image ID
	$pkImageId = $imageArray[$key];
}
else
{
	// It is not set, so upload the image, and store the ID in the cache
	$pkImageId = $pk->pk_image_upload("strip", $absAnswerDirPath.DIRECTORY_SEPARATOR.$randomImageFile);

	// If $pkImageId isset then store it in the cache array, if not set then exit
	if($pkImageId)
	{
		$imageArray[$key] = $pkImageId;
		
		// Serialize the array and store it in the cache file
		file_put_contents($imageCache, serialize($imageArray));
	}
	else
	{
		echo "Could not update image '".$randomImage."' to PassKit";
		die;
	}
}

// Now with a valid image id we can update the pass
if(!$pk->set_pass_id($passId)){
	echo "This is not a valid Pass ID.";
	die;
}

// Validate the pass with PassKit 
if(!$pk->pass_validate()){
	echo "This pass is not valid for this PassKit account.";
	die;
}

// Get the pass details. We need these because we need to increment the question counter with one so the pass will
// show the update message on the lock screen
$passDetails = $pk->get_pass_details();

// Set the data array & update
$passData["stripImage"] = $pkImageId;
$passData["Status"] = $pictureText;
$passData["Question Counter"] = $passDetails["pass_data"]["Question Counter"] + 1;
$passData["Flip"] = "to ask again";

if($pk->pass_update($passData))
{
	echo "The Mystic 8 Ball has spoken.";
}
?>