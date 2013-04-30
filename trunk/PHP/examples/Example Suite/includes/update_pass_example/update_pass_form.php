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
		$("#updatePassForm").submit(function() {
			$('.loader').show(); // show animation
			$.ajax({
				type: "post",
				url: "includes/update_pass_example/update_pass_post.php",
				data: $("#updatePassForm").serialize(),
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
	echo "&lt;pan class=\"error\"&gt;API Connection Error - check API Keys.&lt;/span&gt;";
	die;
}

// Check input and set the data array
if(isset($_POST["update_pass_balance"]) && !empty($_POST["update_pass_balance"]))
{
	$data["Outstanding balance"] = $_POST["update_pass_balance"];
}
else
{
	echo "&lt;span class=\"error\"&gt;Balance is invalid.&lt;/span&gt;";
	die;
}

// Set the pass and update with the new balance
$pk->set_pass_id($_POST["unique_pass_id"]);
// Need to call pass_validate before doing the update
$pk->pass_validate();
$pk_result = $pk->pass_update($data);

if($pk_result)
{
	echo "&lt;span class=\"success\"&gt;Pass updated.&lt;/a&gt;&lt;/span&gt;";
}
else
{
	echo "&lt;span class=\"error\"&gt;Could not update pass. Check if the template name is correct.&lt;/span&gt;";
}
?&gt;
</pre>

<h3>In action</h3>
<p>Enter the new pass balance, and press update.</p>
<p class="postResult"></p>
<form id="updatePassForm" method="post" action="update_pass_post.php">
	<fieldset>    
		<legend>Update balance</legend>
		
		<!-- Hidden unique pass id -->
		<input id="unique_pass_id" name="unique_pass_id" type="hidden" value="<?php echo $pass->uniqueID;?>"/>
		
		<label for="update_pass_balance">Balance</label>
		<input type="number" name="update_pass_balance" placeholder="Enter new balance" required/>

		<input id="updatePassSubmit" type="submit" value="Update pass">
	</fieldset>
</form>