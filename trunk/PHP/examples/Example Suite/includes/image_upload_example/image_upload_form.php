<?php
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

// Load in the demo pass information
$pass = unserialize(file_get_contents(realpath(dirname(__FILE__)) . DIRECTORY_SEPARATOR . ".." . DIRECTORY_SEPARATOR . ".." . DIRECTORY_SEPARATOR . "demo.pass"));

// Set pass id
$pk->set_pass_id($pass->uniqueID);
// Need to call pass_validate before get_pass_details
$pk->pass_validate();
$pass_data = $pk->get_pass_details();
?>

<script src="https://google-code-prettify.googlecode.com/svn/loader/run_prettify.js"></script>
<!-- Submit via AJAX, so we can see the loading image -->
<script type="text/javascript"> 
	$(document).ready(function(){
		$("#imageUploadForm").submit(function() {
			$('.loader').show(); // show animation
			
			// Because we need to send an image
			var form = document.getElementById('imageUploadForm');
			var formData = new FormData(form);

			$.ajax({
				type: "post",
				url: "includes/image_upload_example/image_upload_post.php",
				data: formData,
				processData: false,  
				contentType: false, 
				success: function(response) {
					$('.loader').hide(); // hide animation
					$(".postResult").html("Result: " + response);
					$(".postResult").show();
				}
			});
			
			return false;
		});
	}); 

</script>

<div class="loader">
	<img src="img/ajax_loader.gif" />
</div>

<h3>Pre-requisites</h3>
<p>This example uses the demo pass that was created during the setup.</p><br/>
<p>Your demo pass is: <a href="<?php echo $pass->url;?>"><?php echo $pass->url;?></a></p><br/>
<p>The current pass values are:</p>
<ul>
	<li>"Name" =&gt; <strong><?php echo $pass_data["pass_data"]["Name"];?>;</strong></li>
	<li>"Outstanding balance" =&gt; <strong><?php echo $pass_data["pass_data"]["Outstanding balance"];?>;</strong></li>
</ul>

<h3>Code example</h3>
<pre class="prettyprint linenums">
&lt;?php
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
	echo "&lt;span class=\"error\"&gt;API Connection Error - check API Keys.&lt;/span&gt;";
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
			echo "&lt;span class=\"success\"&gt;Pass updated.&lt;/a&gt;&lt;/span&gt;";
		}
		else
		{
			echo "&lt;span class=\"error\"&gt;Could not update pass. Check if the template name is correct.&lt;/span&gt;";
		}
	}
	else
	{
		echo "&lt;span class=\"error\"&gt;Something went wrong with the image upload. Please try again (script only accepts GIF, JPG & PNG).&lt;/span&gt;";
	}
}
else
{
	echo "&lt;span class=\"error\"&gt;Something went wrong with the image upload. Please try again (script only accepts GIF, JPG & PNG).&lt;/span&gt;";
}
?>
&gt;
</pre>

<h3>In action</h3>
<p>Select the new strip image for the pass and press update.</p>
<p class="postResult"></p>
<form id="imageUploadForm" method="post" action="#" enctype="multipart/form-data">
	<fieldset>    
		<legend>Update strip image</legend>
		
		<!-- Hidden unique pass id -->
		<input id="unique_pass_id" name="unique_pass_id" type="hidden" value="<?php echo $pass->uniqueID;?>"/>
		
		<label for="stripImage">Strip image (at least 624px widht)</label>
		<input type="file" name="stripImage" placeholder="Select image" accept="image/*" />

		<input id="imageUploadSubmit" type="submit" value="Upload image to pass">
	</fieldset>
</form>