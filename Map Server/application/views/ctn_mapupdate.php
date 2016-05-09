<div id="divmapmod">
		<fieldset id="fstmapmod">
			<legend id="lgdmapmod">Cập nhật bản đồ</legend>
			<table id="tblmapmod">
				<tr id="trmapmodhead">
					<td>
						<table style="width: 100%;">
							<tr>
								<td class="mapoverheadtabletd">
									<lable for="kindofdesease" >Loại dịch bệnh:</lable>
									<select name="kindofdesease" size="1" id="sltkindofdesease" class="mapoverheadinputelement" onchange ="get_nameofmap('mapupdate')">
										<?php
											for($index = 0; $index < count($deseasetype); $index++)
											{
												if($index % 2 == 0)
												{
													echo '<option class="sltevenelement" value="'.trim($deseasetype[$index]['id']).'">'.trim($deseasetype[$index]['name']).'</option>';
												}
												else
												{
													echo '<option class="sltevenelement oddrow" value="'.trim($deseasetype[$index]['id']).'">'.trim($deseasetype[$index]['name']).'</option>';
												}
											}
										?>
									</select>
								</td>
								<td class="mapoverheadtabletd">
									<lable for="nameofmap">Tên Bản Đồ:</lable>
									<select name="nameofmap" size="1" id="sltnameofmap2" class="mapoverheadinputelement" onchange ="loadShapFile()">
									</select>
								</td>
							</tr>
							<tr>
								<td class="mapoverheadtabletd">
									<lable for="newnameofdirectory">Thư mục :</lable>
									<input type="text" maxlength="200" name="nnameofdirectory" id="tbxnnameofdirectory" class="mapoverheadinputelement">
								</td>
								<td class="mapoverheadtabletd">
									<lable for="newnameofmap">Tên :</lable>
									<input type="text" maxlength="150" name="nameofmap" id="tbxnameofmap" class="mapoverheadinputelement">
								</td>
							</tr>
							<tr>
								<td class="mapoverheadtabletd">
									<lable for="sizeofmap">Size :</lable>
									<input type="text" maxlength="50" name="sizeofmap" id="tbxsizeofmap" class="mapoverheadinputelement">
								</td>
								<td class="mapoverheadtabletd">
									<lable for="unitofmap">Unit :</lable>
									<select size="1" name="unitofmap" id="tbxunitofmap" class="mapoverheadinputelement">
										<option value="METERS">METERS</option>
										<option value="KILOMETERS">KILOMETERS</option>
									</select>
								</td>
							</tr>
							<tr>
								<td class="mapoverheadtabletd">
									<lable for="projectionofmap">Projection :</lable>
									<input type="text" maxlength="100" name="projectionofmap" id="tbxprojectionofmap" class="mapoverheadinputelement">
								</td>
								<td class="mapoverheadtabletd">
									<lable for="extentofmap">Extent :</lable>
									<input type="text" maxlength="200" name="extentofmap" id="tbxextentofmap" class="mapoverheadinputelement">
								</td>
							</tr>
							<tr>
								<td class="mapoverheadtabletd">
									<lable for="colorofmap">Imagecolor :</lable>
									<input type="color" name="colorofmap" id="tbxcolorofmap" readonly="readonly" class="mapoverheadinputelement"/></input>
								</td>
								<td class="mapoverheadtabletd">
									<input type="button" name="savemap" value="Sửa danh mục Bản đồ"  id="btncreatemap" class="mapoverheadinputelement" onclick ="createMap()"/>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<fieldset id="fstlayer">
							<legend id="lgdlayer">Quản lý layer</legend>
							<form enctype="multipart/form-data" action="uploadphppath" method="post">
								<table id="tblupshapefile" style="width: 100%">
									<tr>
										<td class="tdupshapefiletable30">
											<label for="nameofmap2" >Bản Đồ:</label>
											<select name="nameofmap" size="1" id="sltnameofmap" class="upshapefileinputelement" onchange ="loadShapFile()">
											</select>
										</td>
										<td class="tdupshapefiletable40">
											<label for="maptype">Labelitem :</label>
											<input type="text" maxlength="100" name="labelitem" id="tbxlabelitem" class="upshapefileinputelement">
										</td>
										<td class="tdupshapefiletable30">
											<label for="maptype">Classitem :</label>
											<input type="text" maxlength="100" name="classitem" id="tbxclassitem" class="upshapefileinputelement">
										</td>
									</tr>
									<tr>
										<td class="tdupshapefiletable30">
											<label for="maptype">Type :</label>
											<select size="1" name="maptype" id="sltmaptype" class="upshapefileinputelement"">
												<option value="POLYGON">POLYGON</option>
												<option value="REGION">REGION</option>
											</select>
										</td>
										<td class="tdupshapefiletable40">
											<label for="upshapfile" >Shapfile:</label>
											<input type="file" name="upshapfile" id="tbxupshapfile" style="margin-top: 10px;"/> 
										</td>
										<td class="tdupshapefiletable30">
											<label for="kindoflayer1" >Loại layer:</label>
											<select name="kindoflayer1" size="1" id="sltkindoflayer1" style="width: 60%; margin: 5px;" class="upshapefileinputelement">
												<?php
													for($index = 0; $index < count($kindoflayer); $index++)
													{
														if($index % 2 == 0)
															{
																echo '<option class="sltevenelement" value="'.trim($kindoflayer[$index]['id']).'">'.trim($kindoflayer[$index]['name']).'</option>';
															}
														else
															{
																echo '<option class="sltevenelement oddrow" value="'.trim($kindoflayer[$index]['id']).'">'.trim($kindoflayer[$index]['name']).'</option>';
															}
													}
												?>
											</select>
										</td>
									</tr>
									<tr> 
										<td colspan=3>
											<input type="submit" name="uploadshapfile" value="    Tải lên    " style="float:right;"/> 
										</td>
									</tr>
								</table>
							</form>
							<lable class="block" for="listoflayer">Danh sách các Layer:</lable>
							<table border="1" name="listoflayer" id="tbllistoflayer">
								<tr>
									<th>Xem class</th>
									<th>Layer</th>
									<th>Loại</th>
									<th><input type='button' name='deletelayer' value='  Xóa  ' id='btndeletelayer' onclick='deleteLayer()'/></th>
								</tr>
							</table>
						</fieldset>
						<fieldset id="fstclass">
							<legend id="lgdclass">Quản lý các class</legend>
							<input type="hidden" maxlength="50" name="electedlayerid" id="hdnselectedlayerid" >
							<lable class="block" for="kindoflayer">Loại layer:</lable>
							<select name="kindoflayer" size="1" id="sltkindoflayer2" onchange ="loadProvince()">
								<?php
										for($index = 0; $index < count($kindoflayer); $index++)
										{
											if($index % 2 == 0)
												{
													echo '<option class="sltevenelement" value="'.trim($kindoflayer[$index]['id']).'">'.trim($kindoflayer[$index]['name']).'</option>';
												}
											else
												{
													echo '<option class="sltevenelement oddrow" value="'.trim($kindoflayer[$index]['id']).'">'.trim($kindoflayer[$index]['name']).'</option>';
												}
										}
								?>
							</select>
							<lable for="listofprovince">Tỉnh:</lable>
							<select name="listofprovince" size="1" id="sltlistofprovince" onchange ="loadDistricts()">
							</select>
							<lable for="listofdistrict">Huyện:</lable>
							<select name="listofdistrict" size="1" id="sltlistofdistrict">
							</select>
							<lable for="classFID">FID:</lable>
							<input type="text" maxlength="50" name="classFID" id="tbxclassFID" >
							<input type="button" name="addnewclass" value="Thêm" id="smtaddnewclass" onclick="addClass()">
							<lable class="block" for="listofclass">Danh sách các class:</lable>
							<table border="1" id="tbllistofclass">
								<tr>
									<th>FID</th>
									<th>Layer</th>
									<th><input type='button' name='deleteclass' value='  Xóa  ' id='btndeleteclass' onclick='deleteClass()'/></th>
								</tr>
							</table>
						</fieldset>
						<fieldset id="fstsymbol">
							<legend id="lgdsymbol">Quản lý các symbol</legend>
							<lable for="listofsymbol">Danh sách symbol:</lable>
							<select name="listofsymbol" size="1" id="sltlistofsymbol">
								<?php
										for($index = 0; $index < count($listsymbol); $index++)
										{
											if($index % 2 == 0)
												{
													echo '<option class="sltevenelement " value="'.trim($listsymbol[$index]['id']).'">'.trim($listsymbol[$index]['name']).'</option>';
												}
											else
												{
													echo '<option class="sltevenelement oddrow" value="'.trim($listsymbol[$index]['id']).'">'.trim($listsymbol[$index]['name']).'</option>';
												}
										}
								?>
							</select>
							<lable for="long">Kinh độ:</lable>
							<input type="text" maxlength="50" name="long" id="tbxlong" ><br>
							<lable for="radius">Bán kính:</lable>
							<input type="text" maxlength="50" name="radius" id="tbxradius" >
							<lable for="la">Vĩ độ:</lable>
							<input type="text" maxlength="50" name="la" id="tbxla" >
							<input type="button" name="addnewsymbol" value="Thêm" id="smtaddnewsymbol">
							<lable class="block" for="listofsymbol">Danh sách các symbol:</lable>
							<table border="1" id="tbllistofsymbol">
								<tr>
									<th>Tên</th>
									<th>Tọa độ</th>
									<th>Bán kính</th>
									<th><input type='button' name='deleteVTD' value='  Xóa  ' id='btndeleteVTD' onclick='deleteVTD()'/></th>
								</tr>
							</table>
						</fieldset>
					</td>
				</tr>
			</table>
		</fieldset>
</div>