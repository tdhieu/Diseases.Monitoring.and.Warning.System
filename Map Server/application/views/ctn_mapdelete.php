<div id="divmapdel">
	<form method="post" action="'.$this->config->item('base_url').'index.php/ctrlogin/authorizeUser">
		<fieldset id="fstmapdel">
			<legend id="lgdmapdel">Xóa bản đồ</legend>
			<lable class="block" for="kindofdesease">Loại dịch bệnh:</lable>
			<select name="kindofdesease" size="1" id="sltkindofdesease" style="width: 30%; margin: 5px 10px 5px 20px;" onchange = "get_nameofmap('mapdelete')">
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
			<lable class="block" for="nameofmap">Tên bản đồ:</lable>
			<select name="nameofmap" size="1" id="sltnameofmap" style="width: 30%; margin: 5px 10px 5px 20px;">
				<?php
					for($index = 0; $index < count($maplist); $index++)
					{
						if($index % 2 == 0)
						{
							echo '<option class="sltevenelement evenrow" value="'.trim($maplist[$index]['id']).'">'.trim($maplist[$index]['name']).'</option>';
						}
						else
						{
							echo '<option class="sltevenelement oddrow" value="'.trim($maplist[$index]['id']).'">'.trim($maplist[$index]['name']).'</option>';
						}
					}
				?>				
			</select>
			<br/><input type="submit" name="delmap" value="Xóa" id="smtdelmap">
		</fieldset>
	</form>
</div>