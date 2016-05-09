<div id="divmainmenu">
	<table id="tblmainmenu">
		<tr>
			<td class="tdmainmenu" ><a class="lnkmainmenu" href="<?php echo $this->config->item('base_url');?>index.php/ctr_admin?func=intro">Giới thiệu</a></td>
			<td class="tdmainmenu" >
				<div id="divmainmenuparent2"><a class="lnkmainmenu" href="<?php echo $this->config->item('base_url');?>index.php/ctr_admin?func=intro">Bản đồ</a></div>
				<div id="divmainmenuchild2">
					<a class="lnkmainmenuchild" href="<?php echo $this->config->item('base_url');?>index.php/ctr_admin?func=mnew">Tạo bản đồ</a>
					<a class="lnkmainmenuchild" href="<?php echo $this->config->item('base_url');?>index.php/ctr_admin?func=mmod">Sửa bản đồ</a>
					<a class="lnkmainmenuchild" href="<?php echo $this->config->item('base_url');?>index.php/ctr_admin?func=mdel">Xóa bản đồ</a>
				</div>
			</td>
			<td class="tdmainmenu" ><a class="lnkmainmenu" href="<?php echo $this->config->item('base_url');?>index.php/ctr_admin?func=level">Cấp độ dịch bệnh</a></td>
			<td class="tdmainmenu" ><a class="lnkmainmenu" href="<?php echo $this->config->item('base_url');?>index.php/ctr_admin?func=vtd">Hướng dẫn</a></td>
		</tr>
	</table>
</div>

<script type="text/javascript">
	at_attach("divmainmenuparent2", "divmainmenuchild2", "hover", "y", "pointer");
</script>