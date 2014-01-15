<?php
//require_once './br_api/index.php';
require_once './pvib_api/index.php';
?>


$pvib = new pvib_client();

$pvib->addvar("gOPC.Output.Xpos");
$pvib->addvar("gOPC.Output.Ypos");
$pvib->addvar("gOPC.Output.Zpos");
$pvib->addvar("gOPC.Output.load");
           
$pvib->addvar("gOPC.Output.status");
$pvib->addvar("gOPC.Output.drivestatus");
$pvib->addvar("gOPC.Output.power");
$pvib->addvar("gOPC.Output.Mode");   
         
$pvib->addvar("gModule1"); // 12 входов с датчиков
$pvib->addvar("gModule2");  //
$pvib->addvar("gModule3"); // 12 выходов на исполнительных устройств
$pvib->addvar("gModule4"); // Ўинный передатчик // только Module_OK
$pvib->addvar("gModule8"); // Ўинный приемник // только Module_OK
$pvib->addvar("gModule9"); // Ёнкодер оси Y // ModuleOk, DI1, DI2, Encoder
$pvib->addvar("gModule10"); // Ёнкодер оси X // ModuleOk, DI1, DI2, Encoder
$pvib->addvar("gModule11"); // Ёнкодер оси Z // ModuleOk, DI1, DI2, Encoder

$pvib->addvar("gModule12"); // 12 входов с датчиков
$pvib->addvar("gModule13"); // 12 входов с датчиков

$pvib->addvar("gOPC.Input.ack");
$pvib->addvar("gOPC.Input.driveack");
$pvib->addvar("gOPC.Input.start");
$pvib->addvar("gOPC.Input.src_cell");
$pvib->addvar("gOPC.Input.dst_cell");
$pvib->addvar("gOPC.Input.command");
$pvib->addvar("gOPC.Input.power");

echo "<span>X :".$pvib->getvar("gOPC.Output.Xpos")."</span>";
echo "<span>Y :".$pvib->getvar("gOPC.Output.Ypos")."</span>";
echo "<span>Z :".$pvib->getvar("gOPC.Output.Zpos")."</span>";
?>