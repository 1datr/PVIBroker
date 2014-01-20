<?php 
$srv = "srv1";
if(!empty($_GET['var']))
{
	include "./subsdata/$srv.php";
	echo $_SRVINFO['VARS'][$_GET['var']];
}
	
?>