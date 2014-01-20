<form method="post" id="frm_prod_search">
<input type="hidden" name="stacker_id" value="<?=$STACKER_ID?>" />
<input type="text" name="searching_product" id="searching_product" action="/varloader.php" />
<input type="button" onclick="do_search()" value="Искать" />
</form>
<div id="search_results">

</div>