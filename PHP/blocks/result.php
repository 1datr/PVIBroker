<table>
<tr>
<th>Продукт</th><th>Количество</th><th>Ячейка</th>
</tr>
<?php 
$pattern = '('. quotemeta($_POST['searching_product']) .')';
$replacement = '<strong>\\1</strong>';
setlocale(LC_ALL, "russian","ru_RU.CP1251");

while($row = $mydb->row($res))
{
	
	$row['product'] = preg_replace("/(".$_POST['searching_product'].")/i","<strong>\\1</strong>",$row['product']);
	//$row['product']=str_ireplace($_POST['searching_product'],"<strong>".$_POST['searching_product']."</strong>",$row['product']);
?>
	<tr><td><?=$row['product']?></td><td><?=$row['count']?></td><td><a href="javascript:" onclick="go_cell_info(<?=$row['cell_num']?>);"><?=$row['cell_num']?></a></td></tr>
<?
}
?>
</table>