<?php
	$date = date_create('+3 hours')->format('d.m.Y H:i:s'); 
	$str = file_get_contents("logs.txt");
	$ipaddr = $_SERVER["REMOTE_ADDR"];
	$myfile = fopen("logs.txt", "w") or die("Unable to open file!");
	$txt = $str . $date . " - " . $ipaddr . "\n";
	fwrite($myfile, $txt);
	fclose($myfile);
?>