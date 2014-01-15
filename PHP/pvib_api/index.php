<?php 
class pvib_client {
	VAR $service;
	VAR $url;
	public function __construct()
	{
		
	}
	public function connect_tcpip($srvname,$url,$ip="",$port=11160)
	{
		$this->url = $url;
		$this->service = $srvname;
		$curl = curl_init();
		if(!curl)
			return 0;		
		curl_setopt($curl, CURLOPT_RETURNTRANSFER,true);
		$qurl = $this->url."/mkserv_tcpip/?srvname=".$this->service."&ip=$ip&port=$port";
		//echo $qurl;
		curl_setopt($curl, CURLOPT_URL,$qurl);
		$out = curl_exec($curl);
		
		while(($status = $this->get_srv_status())==-1){
		
		}

		return $status;
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