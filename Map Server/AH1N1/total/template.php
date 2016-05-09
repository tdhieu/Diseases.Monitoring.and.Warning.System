<?php
require("../total/dbconnect.php");
?>
<script type="text/javascript">
    function main()
    {
        init1();
        init();
    }
    if (window.addEventListener)
        window.addEventListener("load", main, false)
    else if (window.attachEvent)
        window.attachEvent("onload", main)
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>Bản đồ dịch bệnh</title>
        <!--Phần liên kết với bản đồ mapserver-->
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
        <link rel="stylesheet" href="../total/c2.css" type="text/css">
		<!--------------------------------------------------- Include jquery library area ---------------------------------------------------------------------->
		<link type="text/css" rel="stylesheet" href="../total/jquery1.4.2/css/ui-lightness/jquery-ui-1.8.custom.css" />
		<script src="../total/jquery1.4.2/js/jquery-1.4.2.min.js"></script>
		<script src="../total/jquery1.4.2/js/jquery-1.4.2.js"></script>
		<script src="../total/jquery1.4.2/js/jquery-ui-1.8.custom.min.js"></script>
		<!--------------------------------------------- End of include jquery library area ------------------------------------------------------------------>
    </head>
    <body>
        <div class="style13" id="header">
            <div id="headerright"><a name="head"><img src="../total/images.jpg" width="62" height="50" class="img1"><img src="../total/logoVAST.jpg" width="60" height="50" class="img3"><img src="../total/logo-IAMI-no-border.jpg" width="62" height="50" class="img2"></a></div>
<div id="headerword">
  <p class="word">Viện Công Nghệ Thông Tin <br>
        Viện Cơ Học và Tin Học Ứng Dụng</p>
          </div>
            <span class="style10"> Health</span> <span class="style11">GIS</span>
            <div class="wordheaderbelow" id="headerbelow"> Hệ thống cảnh báo và giám sát dịch bệnh</div>
        </div>
        <div id="content">
            <div id="trai">
                <div class="image" id="abowtrai"></div>
                <div id="nodeList"></div>
                <!--Bắt đầu của table vùng dịch bệnh,vùng trọng điểm,tọa độ-->
                <div id="belowtrai">
                    <table width="100%" border="2" align="center" cellpadding="1" cellspacing="1" class="clean">
                        <tr>
                            <td width="39%"><p align="center" class="style3">Cấp độ dịch bệnh:</p>
                                <table width="100%" border="0" cellspacing="1" cellpadding="1" id="tbldiseaselevel">
                                    <tr>
                                        <td class="table1">&nbsp;</td>
                                        <td>Cấp 1</td>
                                        <td class="table3">&nbsp;</td>
                                        <td>Cấp 3</td>
                                    </tr>
                                    <tr>
                                        <td width="12%" class="table2">&nbsp;</td>
                                        <td width="38%">Cấp 2</td>
                                        <td width="10%" class="table4">&nbsp;</td>
                                        <td width="40%">Cấp 4</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>              <p align="center">&nbsp;</p></td>
                            <td width="37%"><p align="center" class="style3"><strong>Vùng trọng điểm:</strong></p>
                                <table width="99%" border="0" cellspacing="1" cellpadding="1">
                                    <tr>
                                        <td width="11%" class="table5"><div align="center"></div></td>
                                        <td width="39%" id="nt1">20 - 30</td>
                                        <td width="11%" class="table7">&nbsp;</td>
                                        <td width="39%" id="nt2">10 - 15</td>
                                  </tr>
                                    <tr>
                                        <td class="table6">&nbsp;</td>
                                        <td id="nt3">15 - 20</td>
                                        <td class="table8">&nbsp;</td>
                                        <td id="nt4">5 - 10</td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>              
                                <p align="center">&nbsp;</p></td>
                            <td width="28%"><p align="center" class="style3"><strong>Tọa độ</strong></p>
                                <div align="center">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="51%" height="26">Kinh độ:</td>
                                            <td  id="coords" width="49%">&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td>Vĩ độ:</td>
                                            <td id="coords2">&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td>&nbsp;</td>
                                            <td id="coords6">&nbsp;</td>
                                        </tr>
                                        </p>
                                    </table>
                                </div>              <p align="center">&nbsp;</p></td>
                        </tr>
                    </table>
                </div>
                <!--Bắt đầu div footer-->
                <div id="footer">
                    <table width="100%" height="70" border="0">
                        <tr>
                            <td><p align="left" class="style4 style6 style8 style14" >Copyright (C) 2008-2011 Viện Công Nghệ Thông Tin-IOIT
                                    <br>Địa chỉ:18 đường Hoàng Quốc Việt-quận Cầu Giấy-Hà Nội
                                    <br>Tel:(84-4) 3 756 4405 -Fax:(84-4) 3 756 4217</p>            </td>
                            <td><p align="right"><a href="#head" class="style14" id="word">Về đầu trang</a>
                                    <br>
                                    <a href="<?php echo "$infpage" ?>" target="_blank" class="style14" id="word">Liên kết đến trang dịch bệnh</a></p></td>
                        </tr>
                    </table>
                </div>
            </div>
            <div id="phai">
                <form id="form1" class="form_textbox" name="form1" method="post" action="">
                    <div align="left">
                        <p>
                            <script type="text/javascript"></script>
                            <!--Đoạn code lấy csdl từ odbc lên select-->
                            <?php
                            $sql = "SELECT IdBenhDich, TenBenhDich from DichBenh";
                            $rs = sqlsrv_query( $connection, $sql, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
                            echo"<select name='vd' class='textbox' id='sltdiseasetype' onchange='change_DiseaseType()'>";
                            $diseasetypedata = array();
							$count = 0;
							$selecteddiseasetype = 1;
							while ($row = sqlsrv_fetch_array( $rs, SQLSRV_FETCH_BOTH)) {
                                if($count == 0) $selecteddiseasetype = $row["IdBenhDich"];
								$count++;
                                echo "<option value='".$row["IdBenhDich"]."'>".$row["TenBenhDich"]."</option>";
                            }
                            echo "</select>";
                            sqlsrv_free_stmt( $rs);
                            echo "</table>";
							echo "</p>";
							echo "<p>";
                            $sql = "SELECT TenFile, Idlocation, RootDir, TenBanDo, Loai_DichBenh from BD_BanDo where Loai_DichBenh=".$selecteddiseasetype;
                            $rs = sqlsrv_query( $connection, $sql, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
                            echo"<select name='ViewRegion' id='jumpMenu' onchange='changeMap(this.value)' name='jumpMenu' class='textbox'>";
							echo "<option value='-1'>--Chọn bản đồ--</option>";
							while ($row = sqlsrv_fetch_array( $rs, SQLSRV_FETCH_BOTH)) {
								echo "<option value='".$row['RootDir'].$row['TenFile'].".php?location=".$row['Idlocation']."&disease=".$row['Loai_DichBenh']."'>".$row['TenBanDo']."</option>";
                            }
                            echo "</select>";
                            sqlsrv_free_stmt( $rs);
                            echo "</table>";
                            ?>
                        </p>
                    </div>
                    <p align="left"> Bản đồ thu nhỏ </p>
                </form>
                <div id="form" class="hinhanh"> 
                </div>

                <!--Bắt đầu bảng thông tin về dịch bệnh-->
                <p align="left">Thông tin về dịch bệnh  </p>
                <table width="100%" height="155" border="1" cellpadding="1" cellspacing="1">
                    <tr>
                        <td style="text-align: left; vertical-align: top; font: bold 15px Tahoma, Arial, Helvetica, sans-serif;"><p align="left" class="style8">
                                <?php
									if(isset($_REQUEST['location']) && isset($_REQUEST['disease']))
									{
										$sumdeath = 0;
										$sumdisease = 0;
										$sum = 0;
										$sql = "select SoCabitruyennhiem, Socatuvong from Dulieudichbenh where idtinh = ".$_REQUEST['location']." and Iddichbenh = ".$_REQUEST['disease'];
										$rs = sqlsrv_query( $connection, $sql, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
										while($row = sqlsrv_fetch_array( $rs, SQLSRV_FETCH_BOTH)){
											$sumdeath += $row['Socatuvong'];
											$sumdisease += $row['SoCabitruyennhiem'];
										}
										$sum = $sumdeath+$sumdisease;
										echo "<br>Số liệu thống kê dịch bệnh:";
										echo "<br><br>Tổng số ca: ".$sum." (người)";
										echo "<br><br>Số ca mắc bệnh: ".$sumdisease." (người)";
										echo "<br><br>Số ca chết: ".$sumdeath." (người)";
									}
									if($rs) sqlsrv_free_stmt( $rs);
									sqlsrv_close( $connection);
                                ?>                
							</p>       
						</td>
                    </tr>
                </table>
            </div>
        </div>
        <div>
            <p align="left" class="footer">&nbsp;</p>
        </div>
    </body>
</html>

<script type="text/javascript">
	set_LevelColor(document.getElementById("sltdiseasetype").value);
	function set_LevelColor(diseasetype)
	{
		var tbldiseaselevel = document.getElementById("tbldiseaselevel");
		$.ajax({
			type: "POST",
		   	url: "/healthgismap/total/setlevelcolor.php",
		  	data: "diseasetype="+diseasetype,
		   	success: function(result)
			{
				if(result!='dberror')
				{	
					tbldiseaselevel.innerHTML = result;
				}
				else 
				{
					alert("Chương trình không lấy được dữ liệu các cấp độ. Vui lòng thử lại lần khác!");
				}
			}
		});
	}
	function change_DiseaseType()
	{
		var diseasetype = document.getElementById("sltdiseasetype").value;
		set_LevelColor(diseasetype);
		var jumpMenu = document.getElementById("jumpMenu");
		
		$.ajax({
			type: "POST",
		   	url: "/healthgismap/total/changemaplist.php",
		  	data: "diseasetype="+diseasetype,
		   	success: function(result)
			{
				if(result!='dberror')
				{	
					jumpMenu.innerHTML = result;
					//changeMap(document.getElementById("jumpMenu").value);
				}
				else 
				{
					alert("Chương trình không lấy được danh sách bản đồ. Vui lòng thử lại lần khác!");
				}
			}
		});
	}
	function changeMap(url)
	{
		window.location = url;
	}
</script>
