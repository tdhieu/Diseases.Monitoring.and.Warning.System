<?php if ( ! defined('BASEPATH')) exit('No direct script access allowed');

class ctr_admin extends CI_Controller {

	/**
	 * Index Page for this controller.
	 *
	 * Maps to the following URL
	 * 		http://example.com/index.php/welcome
	 *	- or -  
	 * 		http://example.com/index.php/welcome/index
	 *	- or -
	 * Since this controller is set as the default controller in 
	 * config/routes.php, it's displayed at http://example.com/
	 *
	 * So any other public methods not prefixed with an underscore will
	 * map to /index.php/welcome/<method_name>
	 * @see http://codeigniter.com/user_guide/general/urls.html
	 */
	public function index()
	{
		$this->load->model('mdl_mapman');
		$PAGEDATA['deseasetype'] = $this->mdl_mapman->get_deseasetypes();
		$PAGEDATA['kindoflayer'] = $this->mdl_mapman->get_kindoflayer();
		$PAGEDATA['listsymbol'] = $this->mdl_mapman->get_symbol();
		$PAGEDATA['kindofmap'] = $this->mdl_mapman->get_kindofmap();
		$this->load->view('view_admin',$PAGEDATA);
	}
	
	function loadProvinces()
	{
		$this->load->model('mdl_mapman');
		$result = $this->mdl_mapman->getProvinces();
		echo $result;
	}
	
	public function loadDistricts()
	{
		$this->load->model('mdl_mapman');
		$provinceID = $this->input->post('provinceID');
		$provinceID = stripslashes(trim($provinceID));
		$result = $this->mdl_mapman->loadDistricts($provinceID);
		echo $result;
	}
	public function get_nameofmap()
	{
		$this->load->model('mdl_mapman');
		$kindofdeseace = $this->input->post('kindofdeseace');
		$kindofdeseace = stripslashes(trim($kindofdeseace));
		$result = $this->mdl_mapman->get_nameofmap($kindofdeseace);
		echo $result;
	}
	public function loadLevelTable()
	{
		$this->load->model('mdl_mapman');
		$desease = $this->input->post('desease');
		$desease = stripslashes(trim($desease));
		$result = $this->mdl_mapman->loadLevelTable($desease);
		echo $result;
	}
	public function loadShapFile()
	{
		$this->load->model('mdl_mapman');
		$MS_BanDo = $this->input->post('MS_BanDo');
		$MS_BanDo = stripslashes(trim($MS_BanDo));
		$result = $this->mdl_mapman->loadShapFile($MS_BanDo);
		echo $result;
	}
	public function loadClass()
	{
		$this->load->model('mdl_mapman');
		$MS_Layer = $this->input->post('MS_Layer');
		$MS_Layer = stripslashes(trim($MS_Layer));
		$result = $this->mdl_mapman->loadClass($MS_Layer);
		echo $result;
	}
	public function loadVTD()
	{
		$this->load->model('mdl_mapman');
		$MS_BanDo = $this->input->post('MS_BanDo');
		$MS_BanDo = stripslashes(trim($MS_BanDo));
		$result = $this->mdl_mapman->loadVTD($MS_BanDo);
		echo $result;
	}
	public function addNewLevel()
	{
		$desease = $this->input->post('desease');
		$desease = stripslashes(trim($desease));
		$nameoflevel = $this->input->post('nameoflevel');
		$nameoflevel = stripslashes(trim($nameoflevel));
		$deseasedthreshold = $this->input->post('deseasedthreshold');
		$deseasedthreshold = stripslashes(trim($deseasedthreshold));
		$deaththreshold = $this->input->post('deaththreshold');
		$deaththreshold = stripslashes(trim($deaththreshold));
		$levelcolor = $this->input->post('levelcolor');
		$levelcolor = stripslashes(trim($levelcolor));
		$this->load->model('mdl_mapman');
		$result = $this->mdl_mapman->addNewLevel($desease,$nameoflevel,$deseasedthreshold,$deaththreshold,$levelcolor);
		echo $result;
	}
	
	public function updateLevel()
	{
		$desease = $this->input->post('desease');
		$desease = stripslashes(trim($desease));
		$nameoflevel = $this->input->post('nameoflevel');
		$nameoflevel = stripslashes(trim($nameoflevel));
		$deseasedthreshold = $this->input->post('deseasedthreshold');
		$deseasedthreshold = stripslashes(trim($deseasedthreshold));
		$deaththreshold = $this->input->post('deaththreshold');
		$deaththreshold = stripslashes(trim($deaththreshold));
		$levelcolor = $this->input->post('levelcolor');
		$levelcolor = stripslashes(trim($levelcolor));
		$MSCapDo = $this->input->post('MSCapDo');
		$MSCapDo = stripslashes(trim($MSCapDo));
		$this->load->model('mdl_mapman');
		$result = $this->mdl_mapman->updateLevel($MSCapDo,$desease,$nameoflevel,$deseasedthreshold,$deaththreshold,$levelcolor);
		echo $result;
	}
	public function deleteLevel()
	{
		$msCapDo = $this->input->post('msCapDo');
		$msCapDo = stripslashes(trim($msCapDo));
		$this->load->model('mdl_mapman');
		$result = $this->mdl_mapman->deleteLevel($msCapDo);
		echo $result;
	}
	
	public function createMap()
	{
		$kindofmap = $this->input->post('kindofmap');
		$kindofmap = stripslashes(trim($kindofmap));
		$nameofdirectory = $this->input->post('nameofdirectory');
		$nameofdirectory = stripslashes(trim($nameofdirectory));
		$nameofmap = $this->input->post('nameofmap');
		$nameofmap = stripslashes(trim($nameofmap));
		$kindofdeseace = $this->input->post('kindofdeseace');
		$kindofdeseace = stripslashes(trim($kindofdeseace));
		$sizeofmap = $this->input->post('sizeofmap');
		$sizeofmap = stripslashes(trim($sizeofmap));
		$unitofmap = $this->input->post('unitofmap');
		$unitofmap = stripslashes(trim($unitofmap));
		$extentofmap = $this->input->post('extentofmap');
		$extentofmap = stripslashes(trim($extentofmap));
		$colorofmap = $this->input->post('colorofmap');
		$colorofmap = stripslashes(trim($colorofmap));
		$colorofmap = str_replace("rgb(","",$colorofmap);
		$colorofmap = str_replace(")","",$colorofmap);
		$count = 2;
		$colorofmap = str_replace(",","",$colorofmap, $count);
		$projectionofmap = $this->input->post('projectionofmap');
		$projectionofmap = stripslashes(trim($projectionofmap));
		$this->load->model('mdl_mapman');
		$diseasename = $this->mdl_mapman->get_Disease($kindofdeseace);
		$directory = "healthgismap/".$diseasename."/".$nameofdirectory."/";
		$result = $this->mdl_mapman->createMap($kindofmap,$nameofdirectory, $directory,$nameofmap,$kindofdeseace,$sizeofmap,$unitofmap,$extentofmap,$colorofmap,$projectionofmap );
		if($result == "sucess") 
		{
			$directory = $diseasename."/".$nameofdirectory."/";
			mkdir($directory, 0777, true);
			$directory = $diseasename."/".$nameofdirectory."/shapefile/";
			mkdir($directory, 0777, true);
		}
		echo $result;
	}
	
	public function uploadShapfile()
	{
		$mapid = $this->input->post('nameofmap');
		$mapid = stripslashes(trim($mapid));
		$kindoflayer1 = $this->input->post('kindoflayer1');
		$kindoflayer1 = stripslashes(trim($kindoflayer1));
		$labelitem = $this->input->post('labelitem');
		$labelitem = stripslashes(trim($labelitem));
		$classitem = $this->input->post('classitem');
		$classitem = stripslashes(trim($classitem));
		$layertype = $this->input->post('layertype');
		$layertype = stripslashes(trim($layertype));
		
		$this->load->model('mdl_mapman');
		$mapdir = $this->mdl_mapman->get_MapDir($mapid);
		if($mapdir != "")
		{
			if ($_FILES["upshapfile"]["error"] > 0)
			{
				echo "Return Code: " . $_FILES["upshapfile"]["error"] . "<br />";
			}
			else
			{
				echo "Upload: " . $_FILES["upshapfile"]["name"] . "<br />";
				echo "Type: " . $_FILES["upshapfile"]["type"] . "<br />";
				echo "Size: " . ($_FILES["upshapfile"]["size"] / 1024) . " Kb<br />";
				echo "Temp file: " . $_FILES["upshapfile"]["tmp_name"] . "<br />";

				if (file_exists(substr($mapdir, 13)."shapefile/". $_FILES["upshapfile"]["name"]))
				{
					echo $_FILES["upshapfile"]["name"] . " already exists. ";
				}
				else
				{
					move_uploaded_file($_FILES["upshapfile"]["tmp_name"],
					substr($mapdir, 13)."shapefile/". $_FILES["upshapfile"]["name"]);
					echo "Stored in: " . substr($mapdir, 13)."shapefile/". $_FILES["upshapfile"]["name"];
					$result = $this->mdl_mapman->upShapFile($kindoflayer1,$_FILES["upshapfile"]["name"],$mapid, $labelitem, $classitem, $layertype);
					if($result == "sucess") echo "<br>Update information this shapfile sucessfully.";
					else echo "<br>Can't update information this shapfile.";
				}
			}
		}
		else echo "<br>Can't find the suitable directory to store this file.";
		echo '<br><br><input type="button" name="goback" value="Quay về trang trước"  onclick="javascript: history.go(-1)"/>';
	}
	
	function makeDiseaseMap()
	{
		$mapid = $this->input->post('mapid');
		$mapid = stripslashes(trim($mapid));
		$this->makeMapfile($mapid);
	}
	
	function makeMapfile($mapid)
	{
		$this->load->model('mdl_mapman');
		$mapdata = $this->mdl_mapman->get_MapData($mapid);
		$layerdata = $this->mdl_mapman->get_LayerData($mapid);
		$classdata;
		$content = "";
		/*-----------------------
		Create map file -------------------------------------------------------------------*/
		$filename = "mapfiletpl/mapheader.txt";
		$handle = fopen($filename, "r");
		if(!$handle) {echo 'error'; return;}
		$mapheader = fread($handle, filesize($filename));
		fclose($handle);
		$mapheader = str_replace("@#size#@",$mapdata["Size"],$mapheader);
		$mapheader = str_replace("@#symbolset#@",$mapdata["SymbolSet"],$mapheader);
		$mapheader = str_replace("@#extent#@",$mapdata["Extent"],$mapheader);
		$mapheader = str_replace("@#unit#@",$mapdata["Unit"],$mapheader);
		$mapheader = str_replace("@#fontset#@",$mapdata["FontSet"],$mapheader);
		$mapheader = str_replace("@#projection#@",$mapdata["Projection"],$mapheader);

		$filename = "mapfiletpl/mapoption.txt";
		$handle = fopen($filename, "r");
		if(!$handle) {echo 'error'; return;}
		$mapoption = fread($handle, filesize($filename));
		fclose($handle);
		
		$maplayer = "";
		$layer = "";
		$class = "";
		$num = 2;
		for($i=0;$i<count($layerdata);$i++)
		{
			$filename = "mapfiletpl/maplayer.txt";
			$handle = fopen($filename, "r");
			if(!$handle) {echo 'error'; return;}
			$layer = fread($handle, filesize($filename));
			fclose($handle);
			
			$layer = str_replace("@#type#@",$layerdata[$i]["Type"],$layer);
			$layer = str_replace("@#data#@",substr($layerdata[$i]["Data"], 0, strlen($layerdata[$i]["Data"])-4),$layer);
			$num = 2;
			$layer = str_replace("@#classitem#@",$layerdata[$i]["ClassItem"],$layer, $num);
			$layer = str_replace("@#template#@",$mapdata['TenFile'].".html",$layer);
			$layer = str_replace("@#labelitem#@",$layerdata[$i]["LabelItem"],$layer);
			
			$maplayer .= $layer;
			$classdata = $this->mdl_mapman->get_ClassData($layerdata[$i]["MS_Layer"],$layerdata[$i]["MS_Loai_Layer"],$mapid,$mapdata["Loai_DichBenh"]);
			for($j=0;$j<count($classdata);$j++)
			{
				$filename = "mapfiletpl/mapclass.txt";
				$handle = fopen($filename, "r");
				if(!$handle) {echo 'error'; return;}
				$class = fread($handle, filesize($filename));
				fclose($handle);
			
				$class = str_replace("@#fid#@",iconv("UTF-8", "ISO-8859-1", $classdata[$j]["ExpressionID"]),$class);
				$num = 2;
				$class = str_replace("@#color#@",$classdata[$j]["color"],$class, $num);
				
				$maplayer .= $class;
			}
			$maplayer .= " END";
		}
		$maplayer .= " END";
		
		$content = $mapheader.$mapoption.$maplayer;
		$filename = substr($mapdata["RootDir"],13).$mapdata['TenFile'].".map";
		$handle = fopen($filename,"w");
		if(!$handle) {echo 'error'; return;}
		fwrite($handle,$content);
		fclose($handle);
		
		$content = $mapheader.$maplayer;
		$filename = substr($mapdata["RootDir"],13).$mapdata['TenFile']."_sub.map";
		$handle = fopen($filename,"w");
		if(!$handle) {echo 'error'; return;}
		fwrite($handle,$content);
		fclose($handle);
		/*----------------------------------
		Create tamplate file ----------------------------------------------------------*/
		$filename = "mapfiletpl/tplmap.txt";
		$handle = fopen($filename, "r");
		if(!$handle) {echo 'error'; return;}
		$content = fread($handle, filesize($filename));
		fclose($handle);

		$content = str_replace("[TEN_HUYEN]",$layerdata[0]["ClassItem"],$content);
		$filename = substr($mapdata["RootDir"],13).$mapdata['TenFile'].".html";
		$handle = fopen($filename,"w");
		if(!$handle) {echo 'error'; return;}
		fwrite($handle,$content);
		fclose($handle);
		
		/*----------------------------------
		Create javascript file ----------------------------------------------------------*/
		if (!copy("mapfiletpl/jsmap.txt", substr($mapdata["RootDir"],13).$mapdata['TenFile'].".js")){
			echo "failed to copy $file...\n";
		}
		
		/*----------------------------------
		Create javascript  copy file ----------------------------------------------------------*/
		if (!copy("mapfiletpl/jsmap_sub.txt", substr($mapdata["RootDir"],13).$mapdata['TenFile']."_sub.js")){
			echo "failed to copy $file...\n";
		}
		
		/*----------------------------------
		Create php  file ----------------------------------------------------------*/
		$filename = "mapfiletpl/phpmap.txt";
		$handle = fopen($filename, "r");
		if(!$handle) {echo 'error'; return;}
		$content = fread($handle, filesize($filename));
		fclose($handle);
		
		$mapdata["Extent"] = stripslashes(trim($mapdata["Extent"]));
		$extentarray = explode(" ", $mapdata["Extent"]);
		$mapextent = "";
		for($i=0;$i<count($extentarray);$i++)
		{
			if($i<count($extentarray) - 1)
			{
				$mapextent .= "\"".$extentarray[$i]."\", ";
			}else{
				$mapextent .= "\"".$extentarray[$i]."\"";
			}
		}
		$content = str_replace("@#extent#@",$mapextent,$content);
		$content = str_replace("@#projection#@",$mapdata["Projection"],$content);
		$num = 2;
		$content = str_replace("@#director#@",$mapdata["RootDir"],$content, $num);
		$num = 4;
		$content = str_replace("@#tenfile#@",$mapdata['TenFile'],$content, $num);

		$filename = substr($mapdata["RootDir"],13).$mapdata['TenFile'].".php";
		$handle = fopen($filename,"w");
		if(!$handle) {echo 'error'; return;}
		fwrite($handle,$content);
		fclose($handle);
		
		echo 'sucess';
	}
	
	public function deleteLayer()
	{
		$MS_Layer = $this->input->post('mslayer');
		$MS_Layer = stripslashes(trim($MS_Layer));
		$this->load->model('mdl_mapman');
		$result = $this->mdl_mapman->deleteLayer($MS_Layer);
		echo $result;
	}
	
	public function addClass()
	{
		$mapid = $this->input->post('mapid');
		$mapid = stripslashes(trim($mapid));
		
		$layerid = $this->input->post('layerid');
		$layerid = stripslashes(trim($layerid));
		
		$kindoflayer = $this->input->post('kindoflayer');
		$kindoflayer = stripslashes(trim($kindoflayer));
		
		$provinceID = $this->input->post('provinceID');
		$provinceID = stripslashes(trim($provinceID));
		
		$districID = $this->input->post('districID');
		$districID = stripslashes(trim($districID));
		
		$FID  = $this->input->post('FID');
		$FID = stripslashes(trim($FID));
		
		$this->load->model('mdl_mapman');
		$mapkind = $this->mdl_mapman->get_MapType($mapid);
		if($mapkind == 1) $provinceID = -1;
		else $districID = -1;
		if($kindoflayer != 1) 
		{
			$provinceID = -1;
			$districID = -1;
		}
		$result = $this->mdl_mapman->addClass($layerid,$provinceID,$districID,$FID);
		echo $result;
	}
	
	function deleteClass()
	{
		$msclass = $this->input->post('msclass');
		$msclass = stripslashes(trim($msclass));
		$this->load->model('mdl_mapman');
		$result = $this->mdl_mapman->deleteClass($msclass);
		echo $result;
	}
	
}
/* End of file welcome.php */
/* Location: ./application/controllers/welcome.php */