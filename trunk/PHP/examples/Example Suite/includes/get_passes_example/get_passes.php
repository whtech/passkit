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

$result = $pk->get_passes_for_template($template_name);
?>

<script src="https://google-code-prettify.googlecode.com/svn/loader/run_prettify.js"></script>

<h3>Code example</h3>
<pre class="prettyprint linenums">
&lt;?php
/**
* Example: Get passes for template
* URI: https://code.google.com/p/passkit/wiki/GetPassesForTemplate
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

$result = $pk->get_passes_for_template($template_name);
?&gt;
</pre>

<h3>In action</h3>
<p>Template: <strong><?php echo $result["templateName"];?></strong></p>
<p>Template last updated: <strong><?php echo date("r", strtotime($result["templateLastUpdated"]));?></strong></p>
<p>Total passes issues: <strong><?php echo $result["totalPasses"];?></strong></p>

<h4>Pass records</h4>
<table>
	<tr>
		<td class="colHeader" colspan="3">Pass meta</td>
		<td class="colHeader" colspan="3">Pass data</td>
	</tr>
	<tr>
		<th>Unique ID</th>
		<th>Recovery URL</th>
		<th>Status</th>
		<th>Name</th>
		<th>Balance</th>
		<th>Image ID</td>
	</tr>
	<?php
	foreach($result["passRecords"] as $pass)
	{
		?>
		<tr>
			<td><?php echo $pass["passMeta"]["uniqueID"];?></td>
			<td><a href="<?php echo $pass["passMeta"]["recoveryURL"];?>"><?php echo $pass["passMeta"]["recoveryURL"];?></a></td>
			<td><?php echo $pass["passMeta"]["passStatus"];?></td>
			<td><?php if(isset($pass["passData"]["Name"])) { echo $pass["passData"]["Name"]; }?></td>
			<td><?php if(isset($pass["passData"]["Outstanding balance"])) { echo $pass["passData"]["Outstanding balance"]; }?></td>
			<td><?php if(isset($pass["passData"]["stripImage"])) { echo $pass["passData"]["stripImage"]; }?></td>
		</tr>
		<?php
	}
	?>
</table>