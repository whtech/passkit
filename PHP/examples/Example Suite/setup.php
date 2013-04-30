<?php
$file = dirname(__FILE__).DIRECTORY_SEPARATOR."demo.pass";

$setup_done = false;
$error = null;

if(isset($_REQUEST["s"]) && $_REQUEST["s"] === "1")
{
	if(!file_exists($file))
	{
		// Include passkit api file
		require_once realpath(dirname(__FILE__)  . '/../../SDK/class-PassKit.php');
		// Include config file
		require_once realpath(dirname(__FILE__)  . '/../config.php');
		
		// Create new PassKit instance
		$pk = new PassKit($api_key, $api_secret);

		// Test API connection - no need to do this in live environment;
		if (!$pk->pk_test_connection())
		{
			echo "<p>API Connection Error - check API Keys</p>";
		}
		else
		{
			// Set data array
			$data["Name"] = "Demo pass";
			$data["Outstanding balance"] = 10;

			// Now issue the pass with this data
			$pk_result = $pk->pk_issue_pass($template_name, $data);

			if(isset($pk_result->success))
			{
				// Write pass result object to file
				$fp = fopen("demo.pass", "w");
				fwrite($fp, serialize($pk_result));
				fclose($fp);
			
				$setup_done = true;
			}
			else
			{
				$error = "Setup could not be completed, please double check API key, API secret & Template name in includes/config.php";
			}
		}
	}
	else
	{
		$setup_done = true;
	}
}
elseif(file_exists($file))
{
	$setup_done = true;
}
?>
<!DOCTYPE html>
<html>
<head>
	<title>PassKit - Examples In Action: Setup</title>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	
	<!-- Stylesheets -->
	<link rel="stylesheet" type="text/css" media="screen" href="style.css"/>
	
	<!-- Favicons -->
	<link rel="shortcut icon" href="https://d321ofrgjjwiwz.cloudfront.net/favicon.ico" />
	<link rel="apple-touch-icon" href="https://d321ofrgjjwiwz.cloudfront.net/images/apple-touch-icon.png" />
	<link rel="apple-touch-icon" sizes="72x72" href="https://d321ofrgjjwiwz.cloudfront.net/images/apple-touch-icon-72x72.png" />
	<link rel="apple-touch-icon" sizes="114x114" href="https://d321ofrgjjwiwz.cloudfront.net/images/apple-touch-icon-114x114.png" />
</head>
<body>
	<div id="wrapper">
		<div id="container">
			<header>
				<img src="img/passkit_logo.png" width="300px" height="86px" alt="PassKit logo" id="passkit_logo"/>
			</header>
			<h2>Setup</h2>
			<section id="setup">
				<ol>
					<li>Create an account with <a href="https://create.passkit.com/">PassKit</a></li>
					<li>Login to your account and copy the following URL into your browser: <a href="https://create.passkit.com/loader/?t=1nSdfMy4CwqoWY1m3hO8y&c=1">https://create.passkit.com/loader/?t=1nSdfMy4CwqoWY1m3hO8y&c=1</a></li>
					<li>Type in a name for the template ('Example template' or something similar), and click 'Save Pass'</li>
					<li>Change the api key, secret &amp; template name in the config.php in the example-suite root folder</li>
					<li>Click the setup link below to start the setup.</li>
				</ol>
				<hr/>
				<div id="setupContents">
					<?php
					if($setup_done)
					{
						$pk_result = unserialize(file_get_contents($file));
						echo "<p>Setup already done. Add the demo pass to Passbook:</p><br/>";
						echo "<a href=\"".$pk_result->url."\"><img src=\"img/Add_to_Passbook_US_UK@2x.png\" width=\"122px\" height=\"40px\" alt=\"Add to Passbook\"/></a><br/>";
						echo "<p><a href=\"index.php\">Continue to the examples</a></p>";
					}
					else
					{
						if($error)
						{
							echo "<p class=\"error\">".$error."</p>";
						}
						echo "<a href=\"".$_SERVER["REQUEST_URI"]."?s=1\">Start setup</a>";
					}
					?>
				</div>
			</section>
		</div>
		<!-- Start Footer -->
		<footer class="container">
			<p>&copy; 2013 PassKit All Rights Reserved. <br />PassKit and PassK.it are registered trademarks of Anatta Ltd. Passbook and Apple are registered trademarks of Apple Inc. <br />PassKit does not endorse any of the companies, artists and services represented within the Passbook pass images or samples on this site.</p><br />
			<p><a href="http://passkit.com/privacy-statement.html" title="Privacy Statement" rel="nofollow">Privacy Statement</a> | <a href="http://passkit.com/terms-conditions.html" title="Terms and Conditions" rel="nofollow">Terms &amp; Conditions</a></p>
		</footer>
		<!-- End Footer -->
	</div>
</body>
</html>