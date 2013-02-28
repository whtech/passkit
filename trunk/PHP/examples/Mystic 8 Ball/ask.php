<!DOCTYPE html>
<html>
<head>
	<title>Mystic 8 Ball</title>
	<!-- Disable zoom and make it feel more like a native app -->
	<meta name="viewport" content="width=device-width, minimum-scale=1.0, maximum-scale=1.0"/>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
	<link rel="stylesheet" type="text/css" media="screen" href="style.css"/>
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.0/jquery.min.js" type="text/javascript"></script>
	
	<!-- Submit via AJAX, so we can see the loading image -->
	<script type="text/javascript"> 
		$(document).ready(function(){
			$('#askButton').click(function() {
				$('#loader').show(); // show animation
				$.ajax({
					url: "do-magic.php",
					type: "POST",
					cache: false,
					data: $('#mysticForm').serialize(),
					success : function(data){
						alert(data);
						$('#loader').hide(); // hide the loading message
					},
				});
			});
		}); 
	
	</script>
	
	
</head>
<body>
	<div id="loader" >
		<img src="img/ajax-loader.gif" />
	</div>
	<div id="container">
		<div id="header">
			<img src="img/logo.png" width="470px" height="50px" alt="Mustic 8 Ball logo"/>
		</div>
		<div id="content">
			<p>Just type a question that can be answered with "Yes" or "No", and our mystic 8 ball will give you the answer!</p>
			<form id="mysticForm" action="do-magic.php" method="post">
				<label for="question">Your question:</label>
				<input type="text" name="question" id="question"/>

				<?php if(isset($_REQUEST["pid"])) { ?>
					<input type="hidden" value="<?php echo $_REQUEST["pid"];?>" name="pid"/>
				<?php } ?>
			  
				<input id="askButton" type="button" value="Ask!">
			</form>
		</div>
		<div id="footer">
			<p>&copy; 2013 PassKit Inc. All Rights Reserved.</p>
			<p>PassKit and PassK.it are registered trademarks of PassKit Inc. Passbook and Apple are registered trademarks of Apple Inc.</p>
			<p>PassKit does not endorse any of the companies, artists and services represented within the Passbook pass images or samples on this site.</p>
		</div>
	</div>
</body>
</html>