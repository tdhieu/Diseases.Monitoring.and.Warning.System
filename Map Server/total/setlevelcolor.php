<?php
	require("../total/dbconnect.php");
	if(isset($_POST['diseasetype']))
	{
		$diseasetype = $_POST['diseasetype'];
	}
	$sqlstr = "SELECT MauCapDo, TenCapDo ";
	$sqlstr .= "FROM BD_CapDo ";
	$sqlstr .= "WHERE Loai_DichBenh = ".$diseasetype;
	$sqlstr .= " ORDER BY TenCapDo";
	$stmt = sqlsrv_query( $connection, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
	$colorlist = array(4);
	$count = 0;
	while($row = sqlsrv_fetch_array( $stmt, SQLSRV_FETCH_BOTH))
	{
		$colorlist[$count++] = $row["MauCapDo"];
		if($count == 4) break;
	}
	if($count != 0)
	{
		$newlist = "<tr><td class='table1' style='background-color:".$colorlist[0]."'>&nbsp;</td><td>Cấp 1</td><td class='table3' style='background-color:".$colorlist[1]."'>&nbsp;</td><td>Cấp 3</td></tr>";
		$newlist .= "<tr><td width='12%' class='table2' style='background-color:".$colorlist[2]."'>&nbsp;</td><td width='38%'>Cấp 2</td><td width='10%' class='table4' style='background-color:".$colorlist[3]."'>&nbsp;</td><td width='40%'>Cấp 4</td></tr>";
		$newlist .= "<tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>";
	}
	else $newlist = "Chương trình không lấy được dữ liệu các cấp độ. Vui lòng thử lại lần khác!";
	echo $newlist;
?>