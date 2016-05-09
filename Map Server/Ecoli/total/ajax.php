<?php
require '../total/dbconnect.php';
?>
<?php
if (!isset($_REQUEST['do']))
    exit();
$do = $_REQUEST['do'];
switch ($do) {
    case 1:
        if (isset($_REQUEST['tenhuyen'])) {
            $tenhuyen = $_REQUEST['tenhuyen'];
            $sql5 = "Select Sum(socamacbenh) As TongSoCaNhiemBenh
            From BC_SolieuBaocaoNam,BC_BaoCaoNam,Benhvien,Districts
            where BC_SolieuBaocaoNam.idbaocao=BC_BaoCaoNam.idbaocao
            and BC_BaoCaoNam.idnoibaocao=Benhvien.idbenhvien
            and  BC_SolieuBaocaoNam.iddichbenh=N'8'
            and Benhvien.idquanhuyen=Districts.DistrictID
            and Districts.DistrictName=N'$tenhuyen'";
            $rs5 = sqlsrv_query( $connection, $sql5, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));

            $sql5_data = "Select socamacbenh As socatruyennhiem
                  From BC_SolieuBaocaoNam,BC_BaoCaoNam,Benhvien,Districts
                  where BC_SolieuBaocaoNam.idbaocao=BC_BaoCaoNam.idbaocao
                  and BC_BaoCaoNam.idnoibaocao=Benhvien.idbenhvien
                  and  BC_SolieuBaocaoNam.iddichbenh=N'8'
                  and Benhvien.idquanhuyen=Districts.DistrictID
                  and Districts.DistrictName=N'$tenhuyen'";
            $rs_data = sqlsrv_query( $connection, $sql5_data, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));

            $rs5_data = array();
            while ($row = sqlsrv_fetch_array($rs_data, SQLSRV_FETCH_BOTH)) {
                $rs5_data[] = $row['socatruyennhiem'];
            }

            $sql6_data = "Select socatuvong As socatuvong
                  From BC_SolieuBaocaoNam,BC_BaoCaoNam,Benhvien,Districts
                  where BC_SolieuBaocaoNam.idbaocao=BC_BaoCaoNam.idbaocao
                  and BC_BaoCaoNam.idnoibaocao=Benhvien.idbenhvien
                  and  BC_SolieuBaocaoNam.iddichbenh=N'8'
                  and Benhvien.idquanhuyen=Districts.DistrictID
                  and Districts.DistrictName=N'$tenhuyen'";
            $rs6 = sqlsrv_query( $connection, $sql6_data, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));

            $rs6_data = array();
            while ($rowdata = sqlsrv_fetch_array($rs6, SQLSRV_FETCH_BOTH)) {
                $rs6_data[] = $rowdata['socatuvong'];
            }

            $sql6 = "Select Sum(socatuvong) As TongSoCaTuVong
            From BC_SolieuBaocaoNam,BC_BaoCaoNam,Benhvien,Districts
            where BC_SolieuBaocaoNam.idbaocao=BC_BaoCaoNam.idbaocao
            and BC_BaoCaoNam.idnoibaocao=Benhvien.idbenhvien
            and  BC_SolieuBaocaoNam.iddichbenh=N'8'
            and Benhvien.idquanhuyen=Districts.DistrictID
            and Districts.DistrictName=N'$tenhuyen'";
            $rs6 = sqlsrv_query( $connection, $sql6, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
			
			if($row = sqlsrv_fetch_array( $rs5, SQLSRV_FETCH_BOTH))
			{
				$result5 = $row["TongSoCaNhiemBenh"];
			}
			if($row = sqlsrv_fetch_array( $rs6, SQLSRV_FETCH_BOTH))
			{
				$result6 = $row["TongSoCaTuVong"];
			}
           
            $result = $result5 . ';' . $result6 . ';';
            for ($i = 1; $i <= 12; ++$i) {
                if ($i < count($rs5_data) - 1) {
                    $result .= $rs5_data[$i] . ';';
                } else {
                    $result .= "0;";
                }
            }
            echo $result;
        }
        break;

    case 2:
        if (isset($_REQUEST['tenhuyen'])) {
            $tenhuyen = $_REQUEST['tenhuyen'];
            $sqlnt = "Select NguongTren
                      From BD_VungTrongDiem,BD_BanDo,Districts
                      Where BD_VungTrongDiem.MS_BanDo=BD_BanDo.MS_BanDo
                      and BD_VungTrongDiem.idhuyen=Districts.DistrictID
                      and DistrictName=N'$tenhuyen'";
            $rsnt = sqlsrv_query( $connection, $sqlnt, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));

            $rsnt_data = array();
            while ($rownt = sqlsrv_fetch_array($rsnt, SQLSRV_FETCH_BOTH)) {
                $rsnt_data[] = $rownt['NguongTren'];
            }
            $sqlnd = "Select NguongDuoi
                      From BD_VungTrongDiem,BD_BanDo,Districts
                      Where BD_VungTrongDiem.MS_BanDo=BD_BanDo.MS_BanDo
                      and BD_VungTrongDiem.idhuyen=Districts.DistrictID
                      and DistrictName=N'$tenhuyen'";
            $rsnd = sqlsrv_query( $connection, $sqlnd, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));

            $rsnd_data = array();
            while ($rownd = sqlsrv_fetch_array($rsnd, SQLSRV_FETCH_BOTH)) {
                $rsnd_data[] = $rownd['NguongDuoi'];
            }
            $string = implode("_", $rsnt_data);
            $string = $string . ";" . implode("_", $rsnd_data);
            echo $string;
        }
        break;

       case 3:
        if (isset($_REQUEST['tenhuyen'])) {
            $tenhuyen = $_REQUEST['tenhuyen'];
            $sql5 = "Select Sum(socamacbenh) As TongSoCaNhiemBenh
            From BC_SolieuBaocaoNam,BC_BaoCaoNam,Benhvien,Districts
            where BC_SolieuBaocaoNam.idbaocao=BC_BaoCaoNam.idbaocao
            and BC_BaoCaoNam.idnoibaocao=Benhvien.idbenhvien
            and  BC_SolieuBaocaoNam.iddichbenh=N'9'
            and Benhvien.idquanhuyen=Districts.DistrictID
            and Districts.DistrictName=N'$tenhuyen'";
            $rs5 = sqlsrv_query( $connection, $sql5, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));

            $sql5_data = "Select socamacbenh As socatruyennhiem
                  From BC_SolieuBaocaoNam,BC_BaoCaoNam,Benhvien,Districts
                  where BC_SolieuBaocaoNam.idbaocao=BC_BaoCaoNam.idbaocao
                  and BC_BaoCaoNam.idnoibaocao=Benhvien.idbenhvien
                  and  BC_SolieuBaocaoNam.iddichbenh=N'9'
                  and Benhvien.idquanhuyen=Districts.DistrictID
                  and Districts.DistrictName=N'$tenhuyen'";
            $rs_data = sqlsrv_query( $connection, $sql5_data, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));

            $rs5_data = array();
            while ($row = sqlsrv_fetch_array($rs_data, SQLSRV_FETCH_BOTH)) {
                $rs5_data[] = $row['socatruyennhiem'];
            }

            $sql6_data = "Select socatuvong As socatuvong
                  From BC_SolieuBaocaoNam,BC_BaoCaoNam,Benhvien,Districts
                  where BC_SolieuBaocaoNam.idbaocao=BC_BaoCaoNam.idbaocao
                  and BC_BaoCaoNam.idnoibaocao=Benhvien.idbenhvien
                  and  BC_SolieuBaocaoNam.iddichbenh=N'9'
                  and Benhvien.idquanhuyen=Districts.DistrictID
                  and Districts.DistrictName=N'$tenhuyen'";
            $rs6 = sqlsrv_query( $connection, $sql6_data, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));

            $rs6_data = array();
            while ($rowdata = sqlsrv_fetch_array($rs6, SQLSRV_FETCH_BOTH)) {
                $rs6_data[] = $rowdata['socatuvong'];
            }

            $sql6 = "Select Sum(socatuvong) As TongSoCaTuVong
            From BC_SolieuBaocaoNam,BC_BaoCaoNam,Benhvien,Districts
            where BC_SolieuBaocaoNam.idbaocao=BC_BaoCaoNam.idbaocao
            and BC_BaoCaoNam.idnoibaocao=Benhvien.idbenhvien
            and  BC_SolieuBaocaoNam.iddichbenh=N'9'
            and Benhvien.idquanhuyen=Districts.DistrictID
            and Districts.DistrictName=N'$tenhuyen'";
            $rs6 = sqlsrv_query( $connection, $sql6, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));

            if($row = sqlsrv_fetch_array( $rs5, SQLSRV_FETCH_BOTH))
			{
				$result5 = $row["TongSoCaNhiemBenh"];
			}
			if($row = sqlsrv_fetch_array( $rs6, SQLSRV_FETCH_BOTH))
			{
				$result6 = $row["TongSoCaTuVong"];
			}

            $result = $result5 . ';' . $result6 . ';';
            for ($i = 1; $i <= 12; ++$i) {
                if ($i < count($rs5_data) - 1) {
                    $result .= $rs5_data[$i] . ';';
                } else {
                    $result .= "0;";
                }
            }
            echo $result;
            //alert($result);
        }

        break;

       case 4:
        if (isset($_REQUEST['tenhuyen'])) {
            $tenhuyen = $_REQUEST['tenhuyen'];

            $sqlnt = "Select NguongTren
                      From BD_VungTrongDiem,BD_BanDo,Districts
                      Where BD_VungTrongDiem.MS_BanDo=BD_BanDo.MS_BanDo
                      and BD_VungTrongDiem.idhuyen=Districts.DistrictID
                      and DistrictName=N'$tenhuyen'";
            $rsnt = sqlsrv_query( $connection, $sqlnt, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));

            $rsnt_data = array();
            while ($rownt = sqlsrv_fetch_array($rsnt, SQLSRV_FETCH_BOTH)) {
                $rsnt_data[] = $rownt['NguongTren'];
            }
            $sqlnd = "Select NguongDuoi
                      From BD_VungTrongDiem,BD_BanDo,Districts
                      Where BD_VungTrongDiem.MS_BanDo=BD_BanDo.MS_BanDo
                      and BD_VungTrongDiem.idhuyen=Districts.DistrictID
                      and DistrictName=N'$tenhuyen'";
            $rsnd = sqlsrv_query( $connection, $sqlnd, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));

            $rsnd_data = array();
            while ($rownd = sqlsrv_fetch_array($rsnd, SQLSRV_FETCH_BOTH)) {
                $rsnd_data[] = $rownd['NguongDuoi'];
            }
            $string = implode("_", $rsnt_data);
            $string = $string . ";" . implode("_", $rsnd_data);
            echo $string;
        }
        break;

}