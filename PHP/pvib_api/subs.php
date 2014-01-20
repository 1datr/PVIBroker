<?php
if(!empty($_POST['service']))
{
	require_once '../pvib_api/index.php';
	$pvib = new pvib_client();
	$pvib->write_subs_data($_POST);
}

?>