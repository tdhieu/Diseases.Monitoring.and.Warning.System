<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
	<meta http-equiv="content-type" content="text/html;charset:utf-8"/>
	<link rel="stylesheet" type="text/css" href="<?php echo $this->config->item('base_url');?>application/CSS/Styles.css" />
	<link rel="stylesheet" type="text/css" href="<?php echo $this->config->item('base_url');?>application/CSS/LevelMan.css" />
	<link rel="stylesheet" type="text/css" href="<?php echo $this->config->item('base_url');?>application/CSS/MapMan.css" />
	<!--------------------------------------------------- Include jquery library area ---------------------------------------------------------------------->
	<link type="text/css" rel="stylesheet" href="<?php echo $this->config->item('base_url');?>jquery1.4.2/css/ui-lightness/jquery-ui-1.8.custom.css" />
	<script src="<?php echo $this->config->item('base_url');?>jquery1.4.2/js/jquery-1.4.2.min.js"></script>
	<script src="<?php echo $this->config->item('base_url');?>jquery1.4.2/js/jquery-1.4.2.js"></script>
	<script src="<?php echo $this->config->item('base_url');?>jquery1.4.2/js/jquery-ui-1.8.custom.min.js"></script>
	<!--------------------------------------------- End of include jquery library area ------------------------------------------------------------------>
	<script language="javascript" src="<?php echo $this->config->item('base_url');?>application/JS/dropdown.js"></script>
	<script language="javascript" src="<?php echo $this->config->item('base_url');?>application/JS/getWindowsSize.js"></script>
	<script type="text/javascript" src="<?php echo $this->config->item('base_url');?>mColorPicker/javascripts/mColorPicker.min.js" charset="UTF-8"></script>
	<link rel="icon" type="image/x-icon" href="<?php echo $this->config->item('base_url');?>application/Images/tabicon.ico" />
	<title>Desease Alert Managemer</title>
</head>
<body onload="load();" >
	<div id="confirmdialog" title="Xác nhận hành động!" class="widget">
		<span class="ui-icon ui-icon-alert" style="float:left; margin:0 7px 20px 0;"></span><p id="confirmmessage">Thông báo</p>
	</div>
	<table id="tblbody">
		<tr>
			<td>
				<?php 
					include("view_header.php");
					include("view_mainmenu.php"); 
				?>
			</td>
		</tr>
		<tr id="trcontent">
			<td>
				<?php
					if(isset($_GET["func"]))
					{
						if($_GET["func"]=="intro") include("ctn_introduction.php"); 
						else if($_GET["func"]=="level") include("ctn_levelman.php"); 
						else if($_GET["func"]=="mdel") include("ctn_mapdelete.php");
						else if($_GET["func"]=="mmod") include("ctn_mapupdate.php");
						else if($_GET["func"]=="mnew") include("ctn_mapcreate.php"); 
						else if($_GET["func"]=="vtd") include("ctn_vtdman.php");
					}
					else
					{
						include("ctn_introduction.php");
					}
				?>
			</td>
		</tr>
		<tr><td><?php $page="admin"; include("view_footer.php");?></td></tr>
	</table>
</body>
</html>
<script type="text/javascript">
	 function load()
	 {
		setContentSize('trcontent');
		<?php
			if(isset($_GET["func"]))
			{
				if($_GET["func"]=="level")
				{
					echo "loadLevelTable();";
				}
				else if($_GET["func"]=="mnew")
				{
					echo "loadProvince();";
					echo "get_nameofmap('mapupdate');";
				}
				else if($_GET["func"]=="mmod") 
				{
					echo "loadProvince();";
					echo "get_nameofmap('mapupdate');";
				}
				else if($_GET["func"]=="mdel")
				{
					echo "get_nameofmap('mapdelete');";
				}
			}
		?>
	}
	
	function get_nameofmap(page)
	{
		var kindofdeseace = document.getElementById("sltkindofdesease").value;
		$.ajax({
			type: "POST",
		   	url: "<?php echo $this->config->item('base_url');?>index.php/ctr_admin/get_nameofmap",
		  	data: "kindofdeseace="+kindofdeseace,
		   	success: function(result)
			{
				if(result!='dberror')
				{
					var sltnameofmap = document.getElementById("sltnameofmap");
					sltnameofmap.innerHTML = result;
					if(page == "mapupdate")
					{
						var sltnameofmap2 = document.getElementById("sltnameofmap2");
						sltnameofmap2.innerHTML = result;
					}
					if(page != "mapdelete")
					{
						loadShapFile();
						loadVTD();
					}
				}
				else 
				{
					alert("Không lấy được danh sách các bản đồ. Vui lòng thử lại lần khác!");
				}
			}
		});
	}

	function loadProvince()
	{
		var layer = document.getElementById("sltkindoflayer2").value;
		var sltlistofprovince = document.getElementById("sltlistofprovince");
		var sltlistofdistrict = document.getElementById("sltlistofdistrict");

		if(layer == 1 )
		{
			sltlistofprovince.disabled = false;
			sltlistofdistrict.disabled = false;
			$.ajax({
				type: "POST",
				url: "<?php echo $this->config->item('base_url');?>index.php/ctr_admin/loadProvinces",
				success: function(result)
				{
					if(result!='dberror')
					{	
						sltlistofprovince.innerHTML = result;
						loadDistricts()
					}
					else 
					{
						alert("Chương trình không lấy được danh sách các tỉnh. Vui lòng thử lại lần khác!");
					}
				}
			});
		}
		else
		{
				sltlistofprovince.disabled = true;
				sltlistofdistrict.disabled = true;
		}
	}
	
	function loadDistricts()
	{
		var provinceID = document.getElementById("sltlistofprovince").value;
		var sltlistofdistrict = document.getElementById("sltlistofdistrict");
		$.ajax({
			type: "POST",
		   	url: "<?php echo $this->config->item('base_url');?>index.php/ctr_admin/loadDistricts",
		  	data: "provinceID="+provinceID,
		   	success: function(result)
			{
				if(result!='dberror')
				{	
					sltlistofdistrict.innerHTML = result;
				}
				else 
				{
					alert("Chương trình không lấy được danh sách các huyện của tỉnh được chọn. Vui lòng thử lại lần khác!");
				}
			}
		});
	}
	
	function loadShapFile()
	{
		var MS_Map = document.getElementById("sltnameofmap").value; 
		$.ajax({
			type: "POST",
		   	url: "<?php echo $this->config->item('base_url');?>index.php/ctr_admin/loadShapFile",
		  	data: "MS_BanDo="+MS_Map,
		   	success: function(result)
			{
				if(result!='dberror')
				{
					var tbllistoflayer = document.getElementById("tbllistoflayer");
					tbllistoflayer.innerHTML = result;
				}
				else 
				{
					alert("Chương trình không lấy được danh sách các shapefile. Vui lòng thử lại lần khác!");
				}
			}
		});
	}
	
	function loadClass(MS_Layer)
	{
		document.getElementById("hdnselectedlayerid").value = MS_Layer;
		$.ajax({
			type: "POST",
		   	url: "<?php echo $this->config->item('base_url');?>index.php/ctr_admin/loadClass",
		  	data: "MS_Layer="+MS_Layer,
		   	success: function(result)
			{
				if(result!='dberror')
				{
					var tbllistofclass = document.getElementById("tbllistofclass");
					tbllistofclass.innerHTML = result;
				}
				else 
				{
					alert("Chương trình không lấy được danh sách các class của layer được chọn. Vui lòng thử lại lần khác!");
				}
			}
		});
	}
	
	function loadVTD()
	{
		var MS_Map = document.getElementById("sltnameofmap").value; 
		$.ajax({
			type: "POST",
		   	url: "<?php echo $this->config->item('base_url');?>index.php/ctr_admin/loadVTD",
		  	data: "MS_BanDo="+MS_Map,
		   	success: function(result)
			{
				if(result!='dberror')
				{
					var tbllistofVTD = document.getElementById("tbllistofsymbol");
					tbllistofVTD.innerHTML = result;
					//alert(result);
				}
				else 
				{
					alert("Chương trình không lấy được danh sách các vùng trọng điểm của bản đồ. Vui lòng thử lại lần khác!");
				}
			}
		});
	}
	
	function loadLevelTable()
	{
		var desease = document.getElementById("sltkindofdesease").value;		
		$.ajax({
			type: "POST",
		   	url: "<?php echo $this->config->item('base_url');?>index.php/ctr_admin/loadLevelTable",
		  	data: "desease="+desease,
		   	success: function(result)
			{
				if(result!='dberror')
				{
					var tbllistoflevel = document.getElementById("tbllistoflevel");
					tbllistoflevel.innerHTML = result;
					//alert(result);
				}
				else 
				{
					alert("Chương trình không lấy được dữ liệu cấp độ dịch bệnh. Vui lòng thử lại lần khác!");
				}
			}
		});
	}
	
	function deleteLayer(size, idstring)
	{
		document.getElementById('confirmdialog').title = "Xác nhận xóa các layer của bản đồ";
		document.getElementById('confirmmessage').innerHTML = 'Dữ liệu về layer bản đồ bị xóa sẽ không phục hồi được. Nếu chắc chắn muốn xóa hãy chọn nút "Xóa", ngược lại chọn nút "Đóng không xóa"?';
		$("#confirmdialog").dialog("destroy");
		$("#confirmdialog").dialog({
			resizable: false,
			height:200,
			width: 400,
			modal: true,
			buttons: {
				'Xóa': function() {
					$(this).dialog('close');
					for(i=1;i<=size;i++)
					{
						var elementid = idstring+i;
						if(document.getElementById(elementid).checked == true)
						{
							var mslayer = document.getElementById(elementid).value;
							$.ajax({
								type: "POST",
								url: "<?php echo $this->config->item('base_url');?>index.php/ctr_admin/deleteLayer",
								data: "mslayer="+mslayer,
								success: function(result)
								{
									if(result == 'dberror')
										alert("Một layer bản đồ không thể xóa được. Đóng thông báo để tiếp tục!");
								}
							});
						}
					}
					loadShapFile();
				},
				'Đóng không xóa': function() {
					$(this).dialog('close');
				}
			}
		});					
	}

	function createMap()
	{
		var kindofmap =  document.getElementById("sltkindofmap").value;
		var kindofdeseace = document.getElementById("sltkindofdesease").value;
		var nameofdirectory = document.getElementById("tbxnnameofdirectory").value; 
		var nameofmap = document.getElementById("tbxnameofmap").value; 
		var sizeofmap =  document.getElementById("tbxsizeofmap").value;
		var unitofmap = document.getElementById("tbxunitofmap").value;
		var extentofmap = document.getElementById("tbxextentofmap").value;  
		var colorofmap = document.getElementById("tbxcolorofmap").value; 
		var projectionofmap = document.getElementById("tbxprojectionofmap").value;  
		
		$.ajax({
			type: "POST",
		   	url: "<?php echo $this->config->item('base_url');?>index.php/ctr_admin/createMap",
		  	data: "kindofmap="+kindofmap +"&kindofdeseace="+kindofdeseace+"&nameofdirectory="+nameofdirectory+"&nameofmap="+nameofmap+"&sizeofmap="+sizeofmap+"&unitofmap="+unitofmap+"&extentofmap="+extentofmap+"&colorofmap="+colorofmap+"&projectionofmap="+projectionofmap,
		   	success: function(result)
			{
				if(result == 'sucess')
				{
					get_nameofmap('mapupdate');
					alert("Đã tạo bản đồ mới thành công.");
				}
				else 
				{
					alert("Việc tạo bản đồ mới không thành công. Vui lòng thử lại lần khác!");
				}
			}
		});
	}
	
	function addClass()
	{
		var mapid = document.getElementById("sltnameofmap").value;
		var layerid = document.getElementById("hdnselectedlayerid").value;
		var kindoflayer = document.getElementById("sltkindoflayer2").value;
		var provinceID = document.getElementById("sltlistofprovince").value;
		var districID = document.getElementById("sltlistofdistrict").value;
		var FID = document.getElementById("tbxclassFID").value;
		
		$.ajax({
			type: "POST",
		   	url: "<?php echo $this->config->item('base_url');?>index.php/ctr_admin/addClass",
		  	data: "mapid="+mapid+"&layerid="+layerid+"&kindoflayer="+kindoflayer+"&provinceID="+provinceID+"&districID="+districID +"&FID="+FID,
		   	success: function(result)
			{
				if(result != 'dberror')
				{
					loadClass(layerid);
					alert("Thêm class mới vào bản đồ thành công.");
				}
				else 
				{
					alert("Thêm một class vào bản đồ không thành công. Vui lòng thử lại lần khác!");
				}
			}
		});
	}

	function deleteClass(layerid, size, idstring)
	{
		document.getElementById('confirmdialog').title = "Xác nhận xóa class của bản đồ";
		document.getElementById('confirmmessage').innerHTML = 'Dữ liệu về class bản đồ bị xóa sẽ không phục hồi được. Nếu chắc chắn muốn xóa hãy chọn nút "Xóa", ngược lại chọn nút "Đóng không xóa"?';
		$("#confirmdialog").dialog("destroy");
		$("#confirmdialog").dialog({
			resizable: false,
			height:200,
			width: 400,
			modal: true,
			buttons: {
				'Xóa': function() {
					$(this).dialog('close');
					for(i=1;i<=size;i++)
					{
						var elementid = idstring+i;
						if(document.getElementById(elementid).checked == true)
						{
							var msclass = document.getElementById(elementid).value;
							$.ajax({
								type: "POST",
								url: "<?php echo $this->config->item('base_url');?>index.php/ctr_admin/deleteClass",
								data: "msclass="+msclass,
								success: function(result)
								{
									if(result == 'dberror')
										alert("Một class bản đồ không thể xóa được. Đóng thông báo để tiếp tục!");
								}
							});
						}
					}
					loadClass(layerid);
				},
				'Đóng không xóa': function() {
					$(this).dialog('close');
				}
			}
		});					
	}
	
	function addNewLevel()
	{
		var desease = document.getElementById("sltkindofdesease").value;	
		var nameoflevel = document.getElementById("tbxnameoflevel").value;
		var deseasedthreshold = document.getElementById("tbxdeseasedthreshold").value;
		var deaththreshold = document.getElementById("tbxdeaththreshold").value;
		var levelcolor = document.getElementById("tbxlevelcolor").value;
		if(isNaN(deseasedthreshold)||isNaN(deaththreshold))
			alert("Dữ liệu nhập vào phải là số. Vui lòng thử lại!");
		else
		{
			$.ajax({
				type: "POST",
				url: "<?php echo $this->config->item('base_url');?>index.php/ctr_admin/addNewLevel",
				data: "desease="+desease+"&nameoflevel="+nameoflevel+"&deseasedthreshold="+deseasedthreshold+"&deaththreshold="+deaththreshold+"&levelcolor="+levelcolor,
				success: function(result)
				{
					if(result =='sucess')
					{
						loadLevelTable();
					}
					else 
					{
						alert("Chương trình thêm cấp độ mới không thành công. Vui lòng thử lại lần khác!");
					}
				}
			});
		}
	}
	
	function updateLevel(MS_CapDo, TenCapDo, NguongMacBenh, NguongChet, Mau)
	{
		document.getElementById("tbxmodnameoflevel").value = TenCapDo;
		document.getElementById("tbxmoddeseasedthreshold").value = NguongMacBenh;
		document.getElementById("tbxmoddeaththreshold").value = NguongChet;
		document.getElementById("tbxmodlevelcolor").value = Mau;
		$("#levelupdate").dialog("destroy");
		$("#levelupdate").dialog({
			resizable: false,
			height:200,
			width: 700,
			modal: true,
			buttons: 
			{
				'Cập nhật': function() {
					var desease = document.getElementById("sltkindofdesease").value;	
					var nameoflevel = document.getElementById("tbxmodnameoflevel").value;
					var deseasedthreshold = document.getElementById("tbxmoddeseasedthreshold").value;
					var deaththreshold = document.getElementById("tbxmoddeaththreshold").value;
					var levelcolor = document.getElementById("tbxmodlevelcolor").value;
					
					if(isNaN(deseasedthreshold)||isNaN(deaththreshold))
						alert("Dữ liệu nhập vào phải là số. Vui lòng thử lại!");
					else
					{
						$.ajax({
							type: "POST",
							url: "<?php echo $this->config->item('base_url');?>index.php/ctr_admin/updateLevel",
							data: "desease="+desease+"&nameoflevel="+nameoflevel+"&deseasedthreshold="+deseasedthreshold+"&deaththreshold="+deaththreshold+"&levelcolor="+levelcolor+"&MSCapDo="+MS_CapDo,
							success: function(result)
							{
								if(result =='sucess')
								{
									loadLevelTable();
								}
								else 
								{
									alert("Chương trình cập nhật cấp độ mới không thành công. Vui lòng thử lại lần khác!");
								}
							}
						});
					}
					$(this).dialog('close');
				},
				'Đóng không cập nhật': function() {
					$(this).dialog('close');
				}
			}
		});
	}
	
	function deleteLevel(size, idstring)
	{	
		document.getElementById('confirmdialog').title = "Xác nhận xóa cấp độ dịch bệnh";
		document.getElementById('confirmmessage').innerHTML = 'Dữ liệu về cấp độ dịch bệnh bị xóa sẽ không phục hồi được. Nếu chắc chắn muốn xóa hãy chọn nút "Xóa", ngược lại chọn nút "Đóng không xóa"?';
		$("#confirmdialog").dialog("destroy");
		$("#confirmdialog").dialog({
			resizable: false,
			height:200,
			width: 400,
			modal: true,
			buttons: {
				'Xóa': function() {
					$(this).dialog('close');
					for(i=1;i<=size;i++)
					{
						var elementid = idstring+i;
						if(document.getElementById(elementid).checked == true)
						{
							var msCapDo = document.getElementById(elementid).value;
							$.ajax({
								type: "POST",
								url: "<?php echo $this->config->item('base_url');?>index.php/ctr_admin/deleteLevel",
								data: "msCapDo="+msCapDo,
								success: function(result)
								{
									if(result == 'dberror')
										alert("Một cấp độ dịch bệnh không thể xóa được. Đóng thông báo để tiếp tục!");
								}
							});
						}
					}
					loadLevelTable();
				},
				'Đóng không xóa': function() {
					$(this).dialog('close');
				}
			}
		});					
	}
	
	function makeDiseaseMap()
	{
		var mapid = document.getElementById("sltnameofmap").value;
		$.ajax({
			type: "POST",
			url: "<?php echo $this->config->item('base_url');?>index.php/ctr_admin/makeDiseaseMap",
			data: "mapid="+mapid,
			success: function(result)
			{
				if(result == 'sucess') alert("Đã tạo bản đồ dịch bệnh thành công");
				else alert("Tạo bản đồ dịch bệnh không thành công. Vui lòng thử lại lần khác!");
			}
		});
	}
</script>