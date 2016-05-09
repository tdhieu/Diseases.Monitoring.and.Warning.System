<?php
$infpage = "http://localhost:82/home.aspx";
$server='localhost';
$connectionInfo = array( "UID"=>'sa',
                         "PWD"=>'123456',
                         "Database"=>"CanhBaoDichBenh",
						 "CharacterSet" => "UTF-8");
$connection = sqlsrv_connect( $server, $connectionInfo);
if( $connection === false )
{
     echo "Unable to connect.</br>";
     die( print_r( sqlsrv_errors(), true));
}

$sql = "SELECT TenBanDo, RootDir from BD_BanDo";
$rs = sqlsrv_query( $connection, $sql, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
if($row = sqlsrv_fetch_array( $rs, SQLSRV_FETCH_BOTH))
{
	$user = $row["TenBanDo"];
	$T = $row["RootDir"];
}

$sql = "SELECT     SUM(SoCabitruyennhiem) AS TongSoCaNhiemBenh
FROM         DulieuDichbenh";
$rs = sqlsrv_query( $connection, $sql, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
if($row = sqlsrv_fetch_array($rs, SQLSRV_FETCH_BOTH))
{
	$result = $row["TongSoCaNhiemBenh"];
}

$sql0 = "SELECT     SUM(SoCabitruyennhiem) AS TongSoCaNhiemBenh
FROM         DulieuDichbenh
WHERE     (Tendichbenh = N'AH1N1')";
$rs0 = sqlsrv_query( $connection, $sql0, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
if($row = sqlsrv_fetch_array($rs0, SQLSRV_FETCH_BOTH))
{
	$result0 = $row["TongSoCaNhiemBenh"];
}

$sql1 = "SELECT     SUM(SoCabitruyennhiem) AS TongSoCaNhiemBenh
FROM         DulieuDichbenh
WHERE     (Tendichbenh = N'AH5N1')";
$rs1 = sqlsrv_query( $connection, $sql1, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
if($row = sqlsrv_fetch_array($rs1, SQLSRV_FETCH_BOTH))
{
	$result1 = $row["TongSoCaNhiemBenh"];
}

$sql4 = "SELECT     SUM(SoCabitruyennhiem) AS TongSoCaNhiemBenh
FROM         DulieuDichbenh
WHERE     (Tendichbenh = N'Rubella')";
$rs4 = sqlsrv_query( $connection, $sql4, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
if($row = sqlsrv_fetch_array($rs4, SQLSRV_FETCH_BOTH))
{
	$result4 = $row["TongSoCaNhiemBenh"];
}
?>


