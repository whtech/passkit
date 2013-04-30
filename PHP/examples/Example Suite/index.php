<?php
// Include config file
require_once realpath(dirname(__FILE__)  . '/../config.php');

// Check for setup pass
$file = realpath(dirname(__FILE__)).DIRECTORY_SEPARATOR."demo.pass";

if(!file_exists($file))
{
	header("Location: setup.php");
}
?>

<!DOCTYPE html>
<html>
<head>
	<title>PassKit - Examples In Action</title>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	
	<!-- Stylesheets -->
	<link rel="stylesheet" type="text/css" media="screen" href="style.css"/>
	<link rel="stylesheet" type="text/css" media="screen" href="http://code.jquery.com/ui/1.10.2/themes/smoothness/jquery-ui.css"/>
	
	<!-- Favicons -->
	<link rel="shortcut icon" href="https://d321ofrgjjwiwz.cloudfront.net/favicon.ico" />
	<link rel="apple-touch-icon" href="https://d321ofrgjjwiwz.cloudfront.net/images/apple-touch-icon.png" />
	<link rel="apple-touch-icon" sizes="72x72" href="https://d321ofrgjjwiwz.cloudfront.net/images/apple-touch-icon-72x72.png" />
	<link rel="apple-touch-icon" sizes="114x114" href="https://d321ofrgjjwiwz.cloudfront.net/images/apple-touch-icon-114x114.png" />

	<!-- Include JQuery & JQuery UI & code pretify -->
	<script src="http://code.jquery.com/jquery-1.9.1.min.js"></script>
	<script src="http://code.jquery.com/ui/1.10.2/jquery-ui.js"></script>
	
	<script type="text/javascript">
		$(document).ready(function(){
			$( "#accordion" ).accordion( {
				collapsible: true, 
				active: false,
				heightStyle: "content",
				beforeActivate: function( event, ui ) {
					var newPanelId = ui.newPanel.attr('id');
					
					switch(newPanelId)
					{
						case "getPassesForTemplateExample":
							// Load content for get passes for template example
							$('#getPassesForTemplateExample').load('includes/get_passes_example/get_passes.php');
						break;
						case "newPassExample":
							// Load content for new pass example
							$('#newPassExample').load('includes/issue_pass_example/issue_pass_form.php');
						break;
						case "updatePassExample":
							// Load content for update pass example
							$('#updatePassExample').load('includes/update_pass_example/update_pass_form.php');
						break;
						case "imageUploadExample":
							// Load content for image upload example
							$('#imageUploadExample').load('includes/image_upload_example/image_upload_form.php');
						break;
					}
				}
			});
		});
	</script>
</head>
<body>
	<div id="wrapper">
		<div id="container">
			<header>
				<img src="img/passkit_logo.png" width="300px" height="86px" alt="PassKit logo" id="passkit_logo"/>
			</header>
			
			<h2>Examples</h2>
			
			<div id="accordion">
				<h3>Get passes for template</h3>
				<div id="getPassesForTemplateExample">
				</div>
				<h3>Issue new pass</h3>
				<div id="newPassExample">
				</div>
				<h3>Update existing pass</h3>
				<div id="updatePassExample">
				</div>
				<h3>Change image on existing pass</h3>
				<div id="imageUploadExample">
				</div>
			</div>
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