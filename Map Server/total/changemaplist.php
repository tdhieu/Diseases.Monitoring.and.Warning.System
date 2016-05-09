<?php
	require("../total/dbconnect.php");
	if(isset($_POST['diseasetype']))
	{
		$diseasetype = $_POST['diseasetype'];
	}
	$sqlstr = "SELECT TenFile, TenBanDo, RootDir from BD_BanDo where Loai_DichBenh=".$diseasetype;
	$sqlstr .= " ORDER BY TenBanDo";
	$stmt = sqlsrv_query( $connection, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
	$newlist = "<option value='-1'>--Chọn bản đồ--</option>";
	while($row = sqlsrv_fetch_array( $stmt, SQLSRV_FETCH_BOTH))
	{
		$newlist .= "<option value='".$row['RootDir'].$row['TenFile'].".php'>".$row['TenBanDo']."</option>";
	}
	echo $newlist;
?>