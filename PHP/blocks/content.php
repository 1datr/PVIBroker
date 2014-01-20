
  	
<?php 
$floor_count = 6;
$row_count = 33;
$cellheight = 25;
$cellwidth = 25;
$STACKER_ID=1;	// ID штабелера

$arr_emptycells = Array(205,223,241,259,277,295,313,331,349,367,385,391);

//$arr_poddons = Array(199,211,217,229,235,247,253,265,271,283,289,301,307,319,325,337,343,355,361,373,379);
function getcellnumber($floor,$row,$rack)
{
	GLOBAL $floor_count;
	GLOBAL $row_count;
	GLOBAL $arr_cells_nextpass;
	if($rack==0)
	{
		if($row==0)
		{
			return $floor;			
		}
		else 
			return ($floor+1)+getcellnumber($floor_count-1,$row-1,$rack);
	}
	elseif($rack==1)
	{
		$base = $floor_count*$row_count;
		if($row==0)
		{
			//if($floor==0)
			return $base+$floor;
		}
		else
			return ($floor+1)+getcellnumber($floor_count-1,$row-1,$rack);
	}
}

$floor_count = 6;
$row_count = 33;
$cellheight = 25;
$cellwidth = 25;


require_once './db/mysql.php';
require_once 'config.php';
$mydb = new dbmysql($dbuser,$dbpass,$dbhost,$dbname);


?>
	<div  style="overflow:auto;">
	
	<div id="stacker1"></div>
	</div>	
		<div>
			X:<span id="PosX"></span>&nbsp;Y:<span id="PosY"></span>&nbsp;Z:<span id="PosZ"></span>
		</div>
	
	 