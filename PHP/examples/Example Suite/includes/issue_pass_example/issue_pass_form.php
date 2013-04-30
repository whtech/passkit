<script src="https://google-code-prettify.googlecode.com/svn/loader/run_prettify.js"></script>
<!-- Submit via AJAX, so we can see the loading image -->
<script type="text/javascript"> 
	$(document).ready(function(){
		$("#issuePassForm").submit(function() {
			$('.loader').show(); // show animation
			$.ajax({
				type: "post",
				url: "includes/issue_pass_example/issue_pass_post.php",
				data: $("#issuePassForm").serialize(),
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

<h3>Code example</h3>
<pre class="prettyprint linenums">
&lt;?php
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
	echo "&lt;span class=\"error\"&gt;API Connection Error - check API Keys.&lt;/span&gt;";
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
	echo "&lt;span class=\"error\"&gt;Name is invalid.&lt;/span&gt;";
	die;
}

if(isset($_POST["issue_pass_balance"]) && !empty($_POST["issue_pass_balance"]))
{
	$data["Outstanding balance"] = $_POST["issue_pass_balance"];
}
else
{
	echo "&lt;span class=\"error\"&gt;Balance is invalid.&lt;/span&gt;";
	die;
}

// Now issue the pass with this data
$pk_result = $pk->pk_issue_pass($template_name, $data);

if(isset($pk_result->success))
{
	echo "&lt;span class=\"success\"&gt;Pass issued: &lt;a href=\"".$pk_result->url."\"&gt;".$pk_result->url."&lt;/a&gt;&lt;/span&gt;";
}
else
{
	echo "&lt;span class=\"error\"&gt;Could not issue pass. Check if the template name is correct.&lt;/span&gt;";
}?&gt;
</pre>

<h3>In action</h3>
<p>Fill out the form, and click issue pass to retreive a new pass and pass URL.</p>
<p class="postResult"></p>
<form id="issuePassForm" method="post" action="issue_pass_post.php">
	<fieldset>    
		<legend>Issue a new pass</legend>
		
		<label for="issue_pass_name">Name</label>
		<input type="text" name="issue_pass_name" placeholder="Enter full name" required/>
 
		<label for="issue_pass_balance">Balance</label>
		<input type="number" name="issue_pass_balance" placeholder="Enter balance" required/>

		<input id="issuePassSubmit" type="submit" value="Issue pass">
	</fieldset>
</form>