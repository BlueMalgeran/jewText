<?php
    $ipaddr = $_SERVER["REMOTE_ADDR"];
    $str = file_get_contents("banlist.txt");
    if (strpos($str, $ipaddr) != false) {  
        echo "true";
    } else {
        echo "false";
    }
?>