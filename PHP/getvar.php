<?php 
$srv = "srv1";
if(!empty($_GET['vars']))
{
	require_once 'config.php';
	
		
	$vars = explode(',',$_GET['vars']);
	//print_r($vars);
	$var_array = Array();
	
	foreach($vars as $idx => $v)
	{
		$val = $pvib->getvar($v);
		$var_array[$v] = $val;
	}	
	echo json_encode($var_array);
}
	
?>