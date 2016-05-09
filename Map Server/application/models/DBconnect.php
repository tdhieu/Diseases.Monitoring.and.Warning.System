<?php
$conn = sqlsrv_connect($this->config->item('serverName'), $this->config->item('connectionInfo'));	
if( $conn === false )
{
	echo "Unable to connect.</br>";
	die( print_r( sqlsrv_errors(), true));
}
?>