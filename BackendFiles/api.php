<?php
	$date = date_create('+3 hours')->format('d-m-Y H:i:s'); 
	$str = file_get_contents("jewtextlogs");
	$ipaddr = $_SERVER["REMOTE_ADDR"];
	$myfile = fopen("jewtextlogs", "w") or die("Unable to open file!");
	$txt = $str . $date . " - " . $ipaddr . "\n";
	fwrite($myfile, $txt);
	fclose($myfile);
?>
