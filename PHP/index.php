<link rel="stylesheet" type="text/css" href="/css/bootstrap.css" media="screen" />
<link rel="stylesheet" type="text/css" href="/css/bootstrap-responsive.css" media="screen" />
<link rel="stylesheet" type="text/css" href="/css/stacker.css" media="screen" />
<link rel="shortcut icon" type="image/x-icon" href="favicon.ico" />

<script type="text/javascript" src="/js/jquery.min.js"></script>
<script type="text/javascript" src="/js/jquery.json.min.js"></script>
<script type="text/javascript" src="js/jquery.validate.js" ></script>
<script type="text/javascript" src="js/jquery.form.js" ></script>
<script type="text/javascript" src="js/bootstrap.min.js" ></script>
<script type="text/javascript" src="js/jquery.stacker.js" ></script>


<script type="text/javascript" src="js/jquery-1.4.2.min.js" ></script>
<script>
function print_r(arr, level) {
    var print_red_text = "";
    if(!level) level = 0;
    var level_padding = "";
    for(var j=0; j<level+1; j++) level_padding += "    ";
    if(typeof(arr) == 'object') {
        for(var item in arr) {
            var value = arr[item];
            if(typeof(value) == 'object') {
                print_red_text += level_padding + "'" + item + "' :\n";
                print_red_text += print_r(value,level+1);
		} 
            else 
                print_red_text += level_padding + "'" + item + "' => \"" + value + "\"\n";
        }
    } 

    else  print_red_text = "===>"+arr+"<===("+typeof(arr)+")";
    return print_red_text;
}

$(document).ready(function() {
	  // Handler for .ready() called.

	  	$('#stacker1').Stacker({Floors: 6, Rows:33, group: 3});

	  	var timerMulti;
	  	function Timer()
		{
	  		$("#PosX").html("X");
			  $.ajax({
	              url: '/getvar.php?vars=gOPC.Output.Xpos,gOPC.Output.Ypos,gOPC.Output.Zpos',
	              success: function (data) {
	            	
		             // $("#print_r_div").html(print_r(data["gOPC.Output.Xpos"]));
		              data = eval("(" + data + ")");
					 
	                  $("#PosX").html(data["gOPC.Output.Xpos"]);
	                  $("#PosY").html(data["gOPC.Output.Ypos"]);
	                  $("#PosZ").html(data["gOPC.Output.Zpos"]);
	                  timerMulti = setTimeout(Timer, 5000);
	              },
	              dataType: 'text'
	          });
		}

	  	Timer();
		
		
	});
</script>
  
<?
require_once 'config.php';
/*
// Следить за запущеностью псевдодемона
$curl = curl_init();
curl_setopt($curl, CURLOPT_URL, 'http://tiara/run.php');
curl_setopt($curl, CURLOPT_RETURNTRANSFER,false);
curl_setopt($curl, CURLOPT_POST, true);
curl_setopt($curl, CURLOPT_NOBODY,true);	
curl_setopt($curl, CURLOPT_POSTFIELDS, $post);
curl_setopt($curl, CURLOPT_TIMEOUT,2);
$out = curl_exec($curl);
*/



$pvib->addvar("gOPC.Output.Xpos");
$pvib->addvar("gOPC.Output.Ypos");
$pvib->addvar("gOPC.Output.Zpos");
$pvib->addvar("gOPC.Output.load");
           
$pvib->addvar("gOPC.Output.status");
$pvib->addvar("gOPC.Output.drivestatus");
$pvib->addvar("gOPC.Output.power");
$pvib->addvar("gOPC.Output.Mode");   
         /*
$pvib->addvar("gModule1"); // 12 входов с датчиков
$pvib->addvar("gModule2");  //
$pvib->addvar("gModule3"); // 12 выходов на исполнительных устройств
$pvib->addvar("gModule4"); // Шинный передатчик // только Module_OK
$pvib->addvar("gModule8"); // Шинный приемник // только Module_OK
$pvib->addvar("gModule9"); // Энкодер оси Y // ModuleOk, DI1, DI2, Encoder
$pvib->addvar("gModule10"); // Энкодер оси X // ModuleOk, DI1, DI2, Encoder
$pvib->addvar("gModule11"); // Энкодер оси Z // ModuleOk, DI1, DI2, Encoder

$pvib->addvar("gModule12"); // 12 входов с датчиков
$pvib->addvar("gModule13"); // 12 входов с датчиков

$pvib->addvar("gOPC.Input.ack");
$pvib->addvar("gOPC.Input.driveack");
$pvib->addvar("gOPC.Input.start");
$pvib->addvar("gOPC.Input.src_cell");
$pvib->addvar("gOPC.Input.dst_cell");
$pvib->addvar("gOPC.Input.command");
$pvib->addvar("gOPC.Input.power");
*/

?>
<title>АРМ Тиара</title>
<body>
<div id="print_r_div"></div>
	<div class="row-fluid">АРМ ТИАРА</div>
	<div class="row-fluid">
 		<div class="tabbable"> <!-- Only required for left/right tabs -->
		  	<ul class="nav nav-tabs">
		    	<li class="active" id="tab-stacker"><a href="#tab_stacker" data-toggle="tab">Штабелер</a></li>
		    	<li><a href="#tab_alarms" id="tab-alerms" data-toggle="tab">Аварии</a></li>
		    	<li><a href="#tab_catalog" id="tab-search" data-toggle="tab">Поиск деталей</a></li>
		  	</ul>
		  	<div class="tab-content">
			 	<div class="tab-pane active" id="tab_stacker">
	 				<div class="row-fluid">
		    
					    <div class="span10" id="div_content">
					      <?php include "./blocks/content.php"; ?>
					    </div>
					    <div class="span2" id="div_sidebar">
					      <?php include "./blocks/sidebar.php"; ?>
					    </div>
					    
					</div>
			 	</div>
			 	<div class="tab-pane" id="tab_alarms">
			 		<?php include "./blocks/alarms.php"; ?>
			 	</div>
			 	<div class="tab-pane" id="tab_catalog">
			 		<?php include "./blocks/search.php"; ?>
			 	</div>
			</div>
		</div>
	</div>
	<div class="row-fluid">
		<?php include "./blocks/pult.php"; ?>
	</div>
</body>