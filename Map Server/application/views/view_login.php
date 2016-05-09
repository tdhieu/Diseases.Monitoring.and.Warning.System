<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
	<meta http-equiv="content-type" content="text/html;charset:utf-8"/>
	<link rel="stylesheet" type="text/css" href="<?php echo $this->config->item('base_url');?>application/CSS/Styles.css" />
	<link rel="stylesheet" type="text/css" href="<?php echo $this->config->item('base_url');?>application/CSS/LoginStyles.css" />
	<link rel="icon" type="image/x-icon" href="<?php echo $this->config->item('base_url');?>application/Images/tabicon.ico" />
	<title>Desease Alert Login</title>
</head>
<body>
	<table id="tblbody">
		<tr><td><?php include("view_header.php");?></td></tr>
		<tr>
			<td>
				<div id="divlogin">
					<div id="loginbox">
						<form method="post" action="<?php echo $this->config->item('base_url');?>index.php/ctr_login/authorizeUser">
							<lable for="username">Đăng Nhập Người Dùng</lable><br>
							<lable for="username">Tài Khoản:</lable>
							<input type="text" maxlength="50" name="username" id="tbxloginusername"><br>
							<lable for="username">Mật Khẩu:</lable>
							<input type="password" maxlength="50" name="password" id="pbxloginpassword"><br>
							<input type="submit" name="loginsubmit" value="Đăng nhập" id="smtloginsubmit">
							<br/><br/>Quên mật khẩu hãy liên hệ với người quản trị hoặc <a href="http://www.iami.ac.vn">click vào đây</a>
						</form>
					</div>
				</div>
			</td>
		</tr>
		<tr><td><?php $page="login"; include("view_footer.php");?></td></tr>
	</table>
</body>
</html>