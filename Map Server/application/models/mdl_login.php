<?php if( ! defined('BASEPATH')) exit('No direct script access allowed');
class mdl_login extends CI_Model{
	function __construct()
	{
		parent::__construct();
	}
	
	function authorizeUser($username, $password)
	{
		include('DBconnect.php');
		$sqlstr = "select * from users where user_name = '".$username."' and password = '".$password."'";
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		if( $stmt === false )
		{
			echo "Error in executing query.</br>";
			die( print_r( sqlsrv_errors(), true));
		}
		$row_count = sqlsrv_num_rows($stmt);
		include('DBclose.php');
		return $row_count;
	}
}
