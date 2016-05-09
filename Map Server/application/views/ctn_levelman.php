<div id="divlevelman" >
	<form method="post" action="" >
		<fieldset id="fstlevelman">
			<legend id="lgdlevelman">Quản lý cấp độ dịch bệnh</legend>
			<lable class="block" for="kindofdesease">Loại dịch bệnh:</lable>
			<select name="kindofdesease" size="1" id="sltkindofdesease" onchange="loadLevelTable()">
				<?php
					for($index = 0; $index < count($deseasetype); $index++)
					{
						if($index % 2 == 0)
						{
							echo '<option class="sltevenelement evenrow" value="'.trim($deseasetype[$index]['id']).'">'.trim($deseasetype[$index]['name']).'</option>';
						}
						else
						{
							echo '<option class="sltevenelement oddrow" value="'.trim($deseasetype[$index]['id']).'">'.trim($deseasetype[$index]['name']).'</option>';
						}
					}
				?>
			</select>
			<fieldset id="fstnewlevel">
				<legend id="lgdnewlevel">Thêm cấp độ mới:</legend>
				<lable for="nameoflevel">Tên:</lable>
				<input type="text" maxlength="100" name="nameoflevel" id="tbxnameoflevel" >
				<lable for="deseasedthreshold">Số ca bệnh:</lable>
				<input type="text" maxlength="10" name="deseasedthreshold" id="tbxdeseasedthreshold" >
				<lable for="deaththreshold">Số ca tử vong:</lable>
				<input type="text" maxlength="10" name="deaththreshold" id="tbxdeaththreshold">
				<lable for="colorpicker">Màu:</lable>
				<input type="color" name="colorpicker" id="tbxlevelcolor" readonly="readonly" style="width: 60px;"/></input>
				<input type="button" name="addnewlevel" value="Thêm" id="smtaddnewlevel" onclick="addNewLevel()">
			</fieldset>
			<lable class="block" for="nameoflevel">Danh sách các cấp độ dịch bệnh:</lable>
			<table border="1" id="tbllistoflevel">
			</table>
		</fieldset>
	</form>
	<div id="levelupdate" title="Quản lý cấp độ dịch bệnh" class="widget">
		<p class="validatetips"> CẬP NHẬT THÔNG TIN CẤP ĐỘ DỊCH BỆNH</p>
		<br>
		<form>
			<lable for="modnameoflevel">Tên:</lable>
			<input type="text" maxlength="100" name="modnameoflevel" id="tbxmodnameoflevel" style="width: 150px; margin-right: 10px;">
			<lable for="moddeseasedthreshold">Số ca bệnh:</lable>
			<input type="text" maxlength="10" name="moddeseasedthreshold" id="tbxmoddeseasedthreshold" style="width: 50px; margin-right: 10px;">
			<lable for="moddeaththreshold">Số ca tử vong:</lable>
			<input type="text" maxlength="10" name="moddeaththreshold" id="tbxmoddeaththreshold" style="width: 50px; margin-right: 10px;">
			<lable for="modolorpicker">Màu:</lable>
			<input type="color" name="modcolorpicke" id="tbxmodlevelcolor" readonly="readonly" style="width: 60px;"/></input>
		</form>
	</div>
</div>