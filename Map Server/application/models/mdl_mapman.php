<?php if( ! defined('BASEPATH')) exit('No direct script access allowed');
class mdl_mapman extends CI_Model{
	function __construct()
	{
		parent::__construct();
	}
	
	function get_deseasetypes()
	{
		include('DBconnect.php');
		$kindofdesease = array();
		$count = 0;
		$sqlstr = "select IdBenhDich,TenBenhDich from DichBenh";
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		if (sqlsrv_num_rows($stmt) > 0)
		{
			while( $row = sqlsrv_fetch_object( $stmt))
			{
				$kindofdesease[$count++]= array('id'=>$row->IdBenhDich,'name'=>$row->TenBenhDich);
			}
		} 
		include('DBclose.php');
		return $kindofdesease;
	}

	function get_kindoflayer()
	{
		include('DBconnect.php');
		$layerlist = array();
		$count = 0;
		$sqlstr = "select MS_Loai_Layer,Ten_Loai_Layer from BD_LoaiLayer";
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		if (sqlsrv_num_rows($stmt) > 0)
		{
			while( $row = sqlsrv_fetch_object( $stmt))
			{
				$layerlist[$count++]= array('id'=>$row->MS_Loai_Layer,'name'=>$row->Ten_Loai_Layer);			  
			}
		}
		include('DBclose.php');
		return $layerlist;
	}
	function get_symbol()
	{
		include('DBconnect.php');
		$listsymbol = array();
		$count = 0;
		$sqlstr = "select MS_Symbol,Ten_Symbol from BD_Symbol";
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		if (sqlsrv_num_rows($stmt) > 0)
		{
			while( $row = sqlsrv_fetch_object( $stmt))
			{
			  $listsymbol[$count++]= array('id'=>$row->MS_Symbol,'name'=>$row->Ten_Symbol);			  
			}
		}
		include('DBclose.php');
		return $listsymbol;
	}
	function get_kindofmap()
	{
		include('DBconnect.php');
		$maplist = array();
		$count = 0;
		$sqlstr = "select MS_Loai_BD,TenLoai from BD_LoaiBD";
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		if (sqlsrv_num_rows($stmt) > 0)
		{
			while( $row = sqlsrv_fetch_object( $stmt))
			{
				$maplist[$count++]= array('id'=>$row->MS_Loai_BD,'name'=>$row->TenLoai);			  
			}
		}
		include('DBclose.php');
		return $maplist;
	}
	
	function getProvinces()
	{
		include('DBconnect.php');			
		$sqlstr = "SELECT ProvinceID, ProvinceName ";
		$sqlstr .= "FROM Provinces ";
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		$provinces = "";
		$provinces .= '<option class="sltevenelement" value="-1"> -- không chọn -- </option>';
		while( $row = sqlsrv_fetch_object( $stmt))
		{
			$provinces .= '<option class="sltevenelement" value="'.stripslashes(trim($row->ProvinceID)).'">'.stripslashes(trim($row->ProvinceName)).'</option>';
		}
		if($stmt) include('DBclose.php');
		return $provinces;
	}
	
	function loadDistricts($provinceID)
	{
		include('DBconnect.php');
		$sqlstr = "SELECT DistrictID, DistrictName ";
		$sqlstr .= "FROM Districts ";
		$sqlstr .= "WHERE ProvinceID = '".$provinceID."'";	
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		$result = "";
		$result .= '<option class="sltevenelement" value="-1"> -- không chọn -- </option>';
		if (sqlsrv_num_rows($stmt) > 0)
		{
			while( $row = sqlsrv_fetch_object( $stmt))
			{
				$result .= '<option class="sltevenelement" value="'.stripslashes(trim($row->DistrictID)).'">'.stripslashes(trim($row->DistrictName)).'</option>';
			}
		}
		include('DBclose.php');
		return $result;
	}
	
	function get_nameofmap($kindofdeseace)
	{
		include('DBconnect.php');
		$sqlstr	 = "SELECT MS_BanDo,TenBanDo ";
		$sqlstr .= "FROM BD_BanDo ";
		$sqlstr .= "WHERE Loai_DichBenh ='".$kindofdeseace."'";
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		$result ="";
		if (sqlsrv_num_rows($stmt) > 0)
		{
			while( $row = sqlsrv_fetch_object( $stmt))
			{
			  $result .= '<option class="sltevenelement" value="'.stripslashes(trim($row->MS_BanDo)).'">'.stripslashes(trim($row->TenBanDo)).'</option>';
			}
		}
		else  $result .= '<option class="sltevenelement" value="0" >Không có Bản đồ</option>';
		include('DBclose.php');
		return $result;
	}
	
	function get_MapDir($mapid)
	{
		include('DBconnect.php');
		$sqlstr	 = "SELECT RootDir ";
		$sqlstr .= "FROM BD_BanDo ";
		$sqlstr .= "WHERE MS_BanDo = ".$mapid;
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		$rootdir = "";
		if (sqlsrv_num_rows($stmt) > 0)
		{
			$row = sqlsrv_fetch_object( $stmt);
			$rootdir = $row->RootDir;
		}
		include('DBclose.php');
		return $rootdir;
	}
	
	function loadLevelTable($desease)
	{
		include('DBconnect.php');
		$sqlstr = "SELECT MS_CapDo, TenCapDo, NguongChet, NguongMacBenh, MauCapDo ";
		$sqlstr .= "FROM BD_CapDo ";
		$sqlstr .= "WHERE Loai_DichBenh = '".$desease."'";
				
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		$count = 0;
		$newlist = "";
		if (sqlsrv_num_rows($stmt) > 0)
		{
			$newlist = "<tr>";
			$newlist .= "<th>Tên Cấp Độ</th>";
			$newlist .= "<th>Số Ca Bệnh</th>";
			$newlist .= "<th>Số Ca Tử Vong</th>";
			$newlist .= "<th>Màu</th>";
			$newlist .= "<th>Cập Nhật</th>";
			$newlist .= "<th><input type='button' name='deletelevel' value='  Xóa  ' id='btndeletelevel' onclick='deleteLevel(".sqlsrv_num_rows($stmt).", \"cbxdeletelever\")'/></th>";
			$newlist .= "</tr>";
		   while( $row = sqlsrv_fetch_object( $stmt))
		   {
				$count++;
				$newlist .= "<tr>";
				$newlist .= "<td style='padding-left: 5px;'>".stripslashes(trim($row->TenCapDo))."</td>";
				$newlist .= "<td class='centeralign'>".Stripslashes(trim($row->NguongMacBenh))."</td>";
				$newlist .= "<td class='centeralign'>".Stripslashes(trim($row->NguongChet))."</td>";
				$newlist .= "<td style='Background-color:".Stripslashes(trim($row->MauCapDo)).";'></td>";
				$newlist .= "<td class='centeralign'><input type='button' name='updatelevel' value='Cập Nhật' id='smtupdatelevel' onclick='updateLevel(".stripslashes(trim($row->MS_CapDo)).", \"".stripslashes(trim($row->TenCapDo))."\", ".Stripslashes(trim($row->NguongMacBenh)).", ".Stripslashes(trim($row->NguongChet)).",\"".Stripslashes(trim($row->MauCapDo))."\")'></td>";
				$newlist .= "<td class='centeralign'><input type='checkbox' name='cbxdeletelevel' id='cbxdeletelever".$count."' value='".stripslashes(trim($row->MS_CapDo))."'/></td>";  
				$newlist .= "</tr>";
		   }
		}	
		include('DBclose.php');	
		return $newlist;
	}
	
	function addNewLevel($desease,$nameoflevel,$deseasedthreshold,$deaththreshold,$levelcolor)
	{
		include('DBconnect.php');
		$sqlstr = "INSERT INTO BD_CapDo (TenCapDo, MauCapDo, NguongChet, NguongMacBenh, Loai_DichBenh) VALUES(?,?,?,?,?)";
		$data = array(&$nameoflevel,&$levelcolor,&$deaththreshold,&$deseasedthreshold,&$desease);
		$stmt = sqlsrv_query( $conn, $sqlstr, $data);
		$result = "";
		if($stmt) 
		{
			$result = "sucess";
		}
		else $result = "dberror";
		include('DBclose.php');	
		return $result;
	}
	
	function updateLevel($MSCapDo,$desease,$nameoflevel,$deseasedthreshold,$deaththreshold,$levelcolor)
	{
		include('DBconnect.php');
		$sqlstr = "UPDATE BD_CapDo ";
		$sqlstr .= "SET TenCapDo = (?), MauCapDo = (?), NguongChet = (?), NguongMacBenh = (?), Loai_DichBenh = (?) ";
		$sqlstr .= "WHERE MS_CapDo = (?)";
		$data = array(&$nameoflevel,&$levelcolor,&$deaththreshold,&$deseasedthreshold,&$desease,&$MSCapDo);
		$stmt = sqlsrv_query( $conn, $sqlstr, $data);
		$result = "";
		if($stmt) 
		{
			$result = "sucess";	
		}
		else $result = "dberror";
		include('DBclose.php');
		return $result;
	}
	function deleteLevel($msCapDo)
	{
		include('DBconnect.php');
		$sqlstr = "DELETE BD_CapDo ";
		$sqlstr .= "WHERE MS_CapDo = (?)";
		$data = array(&$msCapDo);
		$stmt = sqlsrv_query( $conn, $sqlstr, $data);
		$result = "";
		if($stmt) 
		{
			$result = "sucess";
		}
		else $result = "dberror";
		include('DBclose.php');	
		return $result;
	}
	
	function get_Disease($MS_disease)
	{
		include('DBconnect.php');
		$sqlstr = "SELECT TenBenhDich ";
		$sqlstr .= "FROM DichBenh ";
		$sqlstr .= "WHERE IdBenhDich = ".$MS_disease;		
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		$diseasename = "";
		if (sqlsrv_num_rows($stmt) > 0)
		{
			$row = sqlsrv_fetch_object( $stmt);
			$diseasename = $row->TenBenhDich;
		}
		include('DBclose.php');
		return $diseasename;
	}
	
	function createMap($kindofmap,$directory,$nameofdirectory,$nameofmap,$kindofdeseace,$sizeofmap,$unitofmap,$extentofmap,$colorofmap,$projectionofmap )
	{
		include('DBconnect.php');
		$sqlstr = "INSERT INTO BD_BanDo ";
		$sqlstr .= "(MS_Loai_BD, TenBanDo, TenFile, RootDir, Size, SymbolSet, Extent, Unit, ImageColor, FontSet, Projection, Loai_DichBenh)";
		$sqlstr .= "VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
		$data = array(&$kindofmap,&$nameofmap,&$directory, &$nameofdirectory,&$sizeofmap, "../total/etc/symbols.sym", &$extentofmap,&$unitofmap,&$colorofmap,"../total/etc/fonts.txt", &$projectionofmap,&$kindofdeseace);
		$stmt = sqlsrv_query( $conn, $sqlstr, $data);
		$result = "";
		if($stmt) 
		{
			$result = "sucess";
		}
		else $result = "dberror";
		include('DBclose.php');	
		return $result;
	}
	
	function get_MapData($mapid)
	{
		include('DBconnect.php');
		$sqlstr = "SELECT * ";
		$sqlstr .= "FROM BD_BanDo ";
		$sqlstr .= "WHERE MS_BanDo = ".$mapid;		
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		$data = array();
		if (sqlsrv_num_rows($stmt) > 0)
		{
			$row = sqlsrv_fetch_object( $stmt);
			$data['MS_BanDo'] = $row->MS_BanDo;
			$data['TenBanDo'] = $row->TenBanDo;
			$data['TenFile'] = $row->TenFile;
			$data['RootDir'] = $row->RootDir;
			$data['Size'] = $row->Size;
			$data['SymbolSet'] = $row->SymbolSet;
			$data['Extent'] = $row->Extent;
			$data['Unit'] = $row->Unit;
			$data['ImageColor'] = $row->ImageColor;
			$data['FontSet'] = $row->FontSet;
			$data['Projection'] = $row->Projection;
			$data['Loai_DichBenh'] = $row->Loai_DichBenh;
		}
		include('DBclose.php');
		return $data;
	}
	
	function get_ClassColor($classid, $mapid, $diseasetype)
	{
		include('DBconnect.php');
		$sqlstr = "SELECT * ";
		$sqlstr .= "FROM BD_CapDo ";
		$sqlstr .= "WHERE Loai_DichBenh = ".$diseasetype;	
		$sqlstr .= "ORDER BY TenCapDo";
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		$level;
		$count = 0;
		$loop = 2;
		$color = "";
		if (sqlsrv_num_rows($stmt) > 0)
		{
			$level = array(sqlsrv_num_rows($stmt));
			while($row = sqlsrv_fetch_object($stmt))
		    {
				$level[$count] = array(5);
				$level[$count]["TenCapDo"] = $row->TenCapDo;
				$color = $row->MauCapDo;
				$color = str_replace("rgb(","",$color);
				$color = str_replace(")","",$color);
				$color = str_replace(","," ",$color, $loop);
				$level[$count]["MauCapDo"] = $color;
				$level[$count]["NguongChet"] = $row->NguongChet;
				$level[$count]["NguongMacBenh"] = $row->NguongMacBenh;
				$level[$count]["Loai_DichBenh"] = $row->Loai_DichBenh;
				$count++;
			}
		}
		$maptype = $this->get_MapType($mapid);
		include('DBclose.php');
		return $level[$classid%count($level)]["MauCapDo"];
	}
	
	function get_ClassData($layerid,$loailayer,$mapid,$diseasetype)
	{
		include('DBconnect.php');
		$sqlstr = "SELECT * ";
		$sqlstr .= "FROM BD_Class ";
		$sqlstr .= "WHERE MS_Layer = ".$layerid;		
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		
		$classdata;
		$count = 0;
		if (sqlsrv_num_rows($stmt) > 0)
		{
			$classdata = array(sqlsrv_num_rows($stmt));
			while( $row = sqlsrv_fetch_object( $stmt))
		    {
				$classdata[$count] = array(4);
				$classdata[$count]['MS_Class'] = $row->MS_Class;
				$classdata[$count]['MS_Layer'] = $row->MS_Layer;
				$classdata[$count]['ExpressionID'] = $row->ExpressionID;
				if($loailayer == 1)
					$classdata[$count]['color'] = $this->get_ClassColor($classdata[$count]['MS_Class'],$mapid,$diseasetype);
				$count++;
			}
		}
		include('DBclose.php');
		return $classdata;
	}
	
	function get_LoaiLayer()
	{
		include('DBconnect.php');
		$sqlstr = "SELECT MS_Loai_Layer ";
		$sqlstr .= "FROM BD_LoaiLayer ";	
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		$loailayer;
		$count = 0;
		if (sqlsrv_num_rows($stmt) > 0)
		{
			$loailayer = array(sqlsrv_num_rows($stmt));
			while( $row = sqlsrv_fetch_object( $stmt))
		    {
				$loailayer[$count++] = $row->MS_Loai_Layer;
			}
		}
		include('DBclose.php');
		return $loailayer;
	}
	
	function is_selectedLayer($MS_Layer)
	{
		include('DBconnect.php');
		$result;
		$sqlstr = "SELECT MS_Class ";
		$sqlstr .= "FROM BD_Class ";
		$sqlstr .= "WHERE MS_Layer = ".$MS_Layer;		
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		if (sqlsrv_num_rows($stmt) > 0)  $result = 1;
		else $result = 0;
		include('DBclose.php');
		return $result;
	}
	
	function get_LayerData($mapid)
	{
		include('DBconnect.php');
		$loailayer = $this->get_LoaiLayer();
		$layerdata = array(count($loailayer));
		for($i=0;$i<count($loailayer);$i++)
		{
			$sqlstr = "SELECT * ";
			$sqlstr .= "FROM BD_Layer ";
			$sqlstr .= "WHERE MS_BanDo = ".$mapid." and MS_Loai_Layer = ".$loailayer[$i];		
			$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
			if (sqlsrv_num_rows($stmt) > 0)
			{
				while($row = sqlsrv_fetch_object( $stmt))
				{
					$isselectedlayer = $this->is_selectedLayer($row->MS_Layer);
					if($isselectedlayer == 1)
					{
						$layerdata[$i] = array(9);
						$layerdata[$i]['MS_Layer'] = $row->MS_Layer;
						$layerdata[$i]['TenShapfile'] = $row->TenShapfile;
						$layerdata[$i]['MetaData'] = $row->MetaData;
						$layerdata[$i]['Template'] = $row->Template;
						$layerdata[$i]['Type'] = $row->Type;
						$layerdata[$i]['Data'] = $row->Data;
						$layerdata[$i]['LabelItem'] = $row->LabelItem;
						$layerdata[$i]['ClassItem'] = $row->ClassItem;
						$layerdata[$i]['MS_Loai_Layer'] = $row->MS_Loai_Layer;
					}
				}
			}
		}
		include('DBclose.php');
		return $layerdata;
	}
	
	function loadShapFile($MS_BanDo)
	{
		include('DBconnect.php');
		$sqlstr = "SELECT A.MS_Layer, A.TenShapfile, B.Ten_Loai_Layer ";
		$sqlstr .= "FROM BD_Layer A,BD_LoaiLayer B ";
		$sqlstr .= "WHERE A.MS_Loai_Layer = B.MS_Loai_Layer and A.MS_BanDo ='".$MS_BanDo."'";
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		
		$newlist = "";
		$count = 0;
		if (sqlsrv_num_rows($stmt) > 0)
		{
			$newlist = "<tr>";
			$newlist .= "<th>Xem class</th>";
			$newlist .= "<th>Layer</th>";
			$newlist .= "<th>Loại</th>";
			$newlist .= "<th><input type='button' name='deletelayer' value='  Xóa  ' id='btndeletelayer' onclick='deleteLayer(".sqlsrv_num_rows($stmt).", \"cbxdellayer\")'/></th>";
			$newlist .= "</tr>";
			
			while( $row = sqlsrv_fetch_object( $stmt))
			{
				$count++;
				$newlist .= "<tr>";
				$newlist .= "<td style='text-align: center; width: 100px;'><input type='radio' name='Layer' value='".stripslashes(trim($row->MS_Layer))."' onchange='loadClass(".stripslashes(trim($row->MS_Layer)).")'/></td>";
				$newlist .= "<td style='padding-left: 5px;'>".stripslashes(trim($row->TenShapfile))."</td>";
				$newlist .= "<td class='centeralign'>".Stripslashes(trim($row->Ten_Loai_Layer))."</td>";
				$newlist .= "<td class='centeralign'><input type='checkbox' name='deletelayer' id='cbxdellayer".$count."' value='".stripslashes(trim($row->MS_Layer))."'>"."</td>";
				$newlist .= "</tr>";	  
			}
		}
		include('DBclose.php');
		return $newlist;
	}
	function loadClass($MS_Layer)
	{
		include('DBconnect.php');
		$newlist = "";
		$count = 0;
		$sqlstr = "SELECT A.MS_Class, A.ExpressionID, B.TenShapfile ";
		$sqlstr .= "FROM BD_Class A, BD_Layer B ";
		$sqlstr .= "WHERE A.MS_Layer = B.MS_Layer and B.MS_Layer ='".$MS_Layer."'";
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		
		if (sqlsrv_num_rows($stmt) > 0)
		{
			$newlist = "<tr>";
			$newlist .= "<th>FID</th>";
			$newlist .= "<th>Layer</th>";
			$newlist .= "<th><input type='button' name='deleteclass' value='  Xóa  ' id='btndeleteclass' onclick='deleteClass(".$MS_Layer.",".sqlsrv_num_rows($stmt).", \"cbxdelclass\")'/></th>";
			$newlist .= "</tr>";
			while( $row = sqlsrv_fetch_object( $stmt))
			{
				$count++;
				$newlist .= "<tr>";
				$newlist .= "<td style='padding-left: 5px;'>".stripslashes(trim($row->ExpressionID))."</td>";
				$newlist .= "<td  class='centeralign'>".Stripslashes(trim($row->TenShapfile))."</td>";
				$newlist .= "<td  class='centeralign'><input type='checkbox' name='delclass' id='cbxdelclass".$count."' value='".stripslashes(trim($row->MS_Class))."'></td>";
				$newlist .= "</tr>";	  
			}
		}
		include('DBclose.php');
		return $newlist;
	}
	function loadVTD($MS_BanDo)
	{
		include('DBconnect.php');
		$newlist = "<tr>";
		$newlist .= "<th>Tên</th>";
		$newlist .= "<th>Tọa độ</th>";
		$newlist .= "<th>Bán kính</th>";
		$newlist .= "<th><input type='button' name='deleteVTD' value='  Xóa  ' id='btndeleteVTD' onclick='deleteVTD()'/></th>";
		$newlist .= "</tr>";
		
		$sqlstr = "SELECT A.Ten_Symbol, B.MS_VTD, B.ToaDo, B.BanKinh ";
		$sqlstr .= "FROM BD_Symbol A,BD_VungTrongDiem B ";
		$sqlstr .= "WHERE A.MS_Symbol = B.MS_Symbol and B.MS_BanDo ='".$MS_BanDo."'";
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		if (sqlsrv_num_rows($stmt) > 0)
		{
			while( $row = sqlsrv_fetch_object( $stmt))
			{
				$newlist .= "<tr>";
				$newlist .= "<td style='padding-left: 5px;'>".stripslashes(trim($row->Ten_Symbol))."</td>";
				$newlist .= "<td class='centeralign'>".Stripslashes(trim($row->ToaDo))."</td>";
				$newlist .= "<td class='centeralign'>".Stripslashes(trim($row->BanKinh))."</td>";
				$newlist .= "<td  class='centeralign'><input type='checkbox' name='deleteVTD' value='".stripslashes(trim($row->MS_VTD))."'></td>";
				$newlist .= "</tr>";	  
			}
		}
		include('DBclose.php');
		return $newlist;
	}
	function upShapFile($kindoflayer,$nameofshapfile,$MS_Map,$labelitem, $classitem, $layertype)
	{
		include('DBconnect.php');
		$template = substr($nameofshapfile, 0, strlen($nameofshapfile)-4)."_tpl.html";
		$sqlstr = "INSERT INTO BD_Layer (MS_BanDo, TenShapfile, MetaData, Template, Type, Data, LabelItem, ClassItem, MS_Loai_Layer) VALUES(?,?,?,?,?,?,?,?,?)";
		$data = array(&$MS_Map,&$nameofshapfile, &$classitem, &$template , &$layertype, &$nameofshapfile, &$labelitem, &$classitem, &$kindoflayer);
		$stmt = sqlsrv_query( $conn, $sqlstr, $data);
		$result = "";
		if($stmt)
		{
			$result = "sucess";	
		}
		else 
		{	
			$result = "dberror";
		}
		include('DBclose.php');
		return $result;
	}
	
	function deleteLayer($MS_Layer)
	{
		include('DBconnect.php');
		$sqlstr = "DELETE BD_Layer ";
		$sqlstr .= "WHERE MS_Layer = (?)";
		$data = array(&$MS_Layer);
		$stmt = sqlsrv_query( $conn, $sqlstr, $data);
		$result = "";
		if($stmt) 
		{
			$result = "sucess";
		}
		else $result = "dberror";
			include('DBclose.php');	
		return $result;
	}
	
	function get_MapType($mapid)
	{
		include('DBconnect.php');
		$sqlstr	 = "SELECT MS_Loai_BD ";
		$sqlstr .= "FROM BD_BanDo ";
		$sqlstr .= "WHERE MS_BanDo = ".$mapid;
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		$kind = "";
		if (sqlsrv_num_rows($stmt) > 0)
		{
			$row = sqlsrv_fetch_object( $stmt);
			$kind = $row->MS_Loai_BD;
		}
		include('DBclose.php');
		return $kind;
	}
	
	function get_ClassID($layerid, $FID)
	{
		include('DBconnect.php');
		$sqlstr = "SELECT MS_Class ";
		$sqlstr .= "FROM BD_Class ";
		$sqlstr .= "WHERE MS_Layer=".$layerid." and ExpressionID ='".$FID."'";
		$stmt = sqlsrv_query( $conn, $sqlstr, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));
		$classid = "";
		if (sqlsrv_num_rows($stmt) > 0)
		{
			$row = sqlsrv_fetch_object( $stmt);
			$classid = $row->MS_Class;
		}
		include('DBclose.php');
		return $classid;
	}
	
	function add_Class_Tinh($classid, $provineid)
	{
		include('DBconnect.php');
		$sqlstr = "INSERT INTO BD_ClassTinh (MS_Class, MS_Tinh) VALUES(?,?)";
		$data = array(&$classid, &$provineid);
		$stmt = sqlsrv_query( $conn, $sqlstr, $data);
		$result = "";
		if($stmt) 
		{
			$result = "sucess";
		}
		else 
		{
			$result = "dberror";
		}
		include('DBclose.php');
		return $result;	
	}
	
	function add_Class_Huyen($classid, $districtid)
	{
		include('DBconnect.php');
		$sqlstr = "INSERT INTO BD_ClassHuyen (MS_Class, MS_Huyen) VALUES(?,?)";
		$data = array(&$classid, &$districtid);
		$stmt = sqlsrv_query( $conn, $sqlstr, $data);
		$result = "";
		if($stmt) 
		{
			$result = "sucess";
		}
		else $result = "dberror";
		include('DBclose.php');	
		return $result;
	}
	
	function addClass($layerid,$provinceID,$districID,$FID)
	{
		include('DBconnect.php');
		$sqlstr = "INSERT INTO BD_Class (MS_Layer, ExpressionID) VALUES(?,?)";
		$data = array(&$layerid, &$FID);
		$stmt = sqlsrv_query( $conn, $sqlstr, $data);
		$classid = "";
		if($stmt)
		{
			if(($provinceID != -1) || ($districID != -1))
			{
				$classid = $this->get_ClassID($layerid, $FID);
			}
			if($provinceID != -1)
			{
				$this->add_Class_Tinh($classid, $provinceID);
			}
			if($districID != -1)
			{
				$this->add_Class_Huyen($classid, $districID);
			}
			$result = "sucess";
		}
		else 
		{	
			$result = "dberror";
		}
		include('DBclose.php');	
	}
	
	function deleteClassTinh($msclass)
	{
		include('DBconnect.php');
		$sqlstr = "DELETE BD_ClassTinh ";
		$sqlstr .= "WHERE MS_Class = (?)";
		$data = array(&$msclass);
		$stmt = sqlsrv_query( $conn, $sqlstr, $data);
		$result = "";
		if($stmt) 
		{
			$result = "sucess";
		}
		else $result = "dberror";
			include('DBclose.php');	
		return $result;
	}	
	
	function deleteClassHuyen($msclass)
	{
		include('DBconnect.php');
		$sqlstr = "DELETE BD_ClassHuyen ";
		$sqlstr .= "WHERE MS_Class = (?)";
		$data = array(&$msclass);
		$stmt = sqlsrv_query( $conn, $sqlstr, $data);
		$result = "";
		if($stmt) 
		{
			$result = "sucess";
		}
		else $result = "dberror";
			include('DBclose.php');	
		return $result;
	}
	
	function deleteClass($msclass)
	{
		$this->deleteClassTinh($msclass);
		$this->deleteClassHuyen($msclass);
		include('DBconnect.php');
		$sqlstr = "DELETE BD_Class ";
		$sqlstr .= "WHERE MS_Class = (?)";
		$data = array(&$msclass);
		$stmt = sqlsrv_query( $conn, $sqlstr, $data);
		$result = "";
		if($stmt) 
		{
			$result = "sucess";
		}
		else $result = "dberror";
			include('DBclose.php');	
		return $result;
	}
}