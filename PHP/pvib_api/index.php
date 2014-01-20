<?php 
class pvib_client {
	VAR $service;
	VAR $url;
	VAR $subspage;
	
	public function __construct()
	{
		
	}
	public function connect_tcpip($srvname,$url,$ip="",$port=11160,$pmode="TRUE",$subspage="/pvib_api/subs.php")
	{
		/*echo '<pre>';
		print_r($_SERVER);
		echo '</pre>';*/
		if($subspage!="")
			$subspage = "http://".$_SERVER['HTTP_HOST'].$subspage;
		$this->subspage = $subspage;
		
		$this->url = $url;
		$this->service = $srvname;
		$curl = curl_init();
		if(!curl)
			return "Error curl init";		
		curl_setopt($curl, CURLOPT_RETURNTRANSFER,true);
		$qurl = $this->url."/mkserv_tcpip/?srvname=".$this->service."&ip=$ip&port=$port&pmode=$pmode&subspage=$subspage";
		//echo $qurl;
		curl_setopt($curl, CURLOPT_URL,$qurl);
		$out = curl_exec($curl);
		
		$time1 = time();
		
		if($this->subspage=="")
			{
				while(($status = $this->get_srv_status())==-1){
				if(time()-$time1>200) return 0;
				}
				return $status;				
			}
		else
			{
				$t1 = time();
				if(file_exists("./subsdata/".$this->service.".php"))
					unlink("./subsdata/".$this->service.".php");
				while(($connstatus = $this->cpu_connected())==-1)
				{
					if(time()-$t1>200) return 0;
				}
				return $connstatus;
			}
		return 0;
	}
	
	function cpu_connected()
	{
		
		if(file_exists("./subsdata/".$this->service.".php"))
		{
			include "./subsdata/".$this->service.".php";
		//	echo file_get_contents("./subsdata/".$this->service.".php");
		}
		if(empty($_SRVINFO)) return -1;
		//print_r($_SRVINFO);
		if($_SRVINFO['cpu_connected']==TRUE) return  0;
		else return $_SRVINFO['error'];
	}
	
	public function get_srv_status()
	{
		$curl = curl_init();
		if(!curl)
			return 0;
		curl_setopt($curl, CURLOPT_RETURNTRANSFER,true);
		//echo $this->url."/srv_status/?srvname=".$this->service;
		curl_setopt($curl, CURLOPT_URL,$this->url."/srv_status/?srvname=".$this->service);
		$out = curl_exec($curl);
		return json_decode($out);
	}
	// Разбор данных по подписке
	public function write_subs_data($post_array)
	{
		if(!empty($post_array['service']))
		{
			$this->service = $post_array['service'];
			$filepath = "../subsdata/".$this->service.".php";
			if(file_exists($filepath))
				include $filepath;
			if(empty($_SRVINFO)) $_SRVINFO = Array();
			switch ($_POST['event'])
			{
				case 'service_connected': 		// if service connected			
					$_SRVINFO['srv_connected'] = TRUE; 
					break;
				case 'srv_connection_error':	// if connection error
					$_SRVINFO['srv_connected'] = FALSE;
					$_SRVINFO['error'] = $_POST['result'];
					break;
				case 'cpu_connected':			// if connected to cpu
					$_SRVINFO['cpu_connected'] = TRUE;
					break;
				case 'cpu_connection_error':	// if cpu connection error
					$_SRVINFO['cpu_connected'] = FALSE;
					$_SRVINFO['error'] = $_POST['result'];
					break;
				case 'srv_var_changed':
					if(empty($_SRVINFO['VARS'])) 
						$_SRVINFO['VARS'] = Array();
					$_SRVINFO['VARS'][$_POST['varname']] = $_POST['value'];
					break;
			}	
			$vardata = "<?php
\$_SRVINFO = ".var_export($_SRVINFO,true).";
?>"; 
			file_put_contents($filepath, $vardata);
		}		
	}
	
	public function addvar($var) {
		$curl = curl_init();
		if(!curl)
			break;
		curl_setopt($curl, CURLOPT_RETURNTRANSFER,true);
		curl_setopt($curl, CURLOPT_URL,$this->url."/watch_var/?srvname=".$this->service."&varname=$var");
		$out = curl_exec($curl);
		return json_decode($out);
	}
	
	public function getvar($varname) {
		$curl = curl_init();
		if(!curl)
			break;
		curl_setopt($curl, CURLOPT_RETURNTRANSFER,true);
		curl_setopt($curl, CURLOPT_URL,$this->url."/get_var/?srvname=".$this->service."&varname=$varname");
		$out = curl_exec($curl);
		return json_decode($out);
		
	}
	
	public function setvar($varname,$val) {
		$curl = curl_init();
		if(!curl)
			break;
		curl_setopt($curl, CURLOPT_RETURNTRANSFER,true);
		curl_setopt($curl, CURLOPT_URL,$this->url."/set_var/?srvname=".$this->service."&varname=$varname&varval=$val");
		$out = curl_exec($curl);
		return json_decode($out);
	
	}
	
	public function  changed_vars()
	{
		$curl = curl_init();
		if(!curl)
			break;
		curl_setopt($curl, CURLOPT_RETURNTRANSFER,true);
		curl_setopt($curl, CURLOPT_URL,$this->url."/varchanged/?srvname=".$this->service);
		$out = curl_exec($curl);
		return json_decode($out);
	}
	
	public function varlist()
	{
		$curl = curl_init();
		if(!curl)
			break;
		curl_setopt($curl, CURLOPT_RETURNTRANSFER,true);
		curl_setopt($curl, CURLOPT_URL,$this->url."/varlist/?srvname=".$this->service);
		$out = curl_exec($curl);
		return json_decode($out);
	}
}


?>