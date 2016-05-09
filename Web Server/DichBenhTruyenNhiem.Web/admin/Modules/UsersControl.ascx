<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UsersControl.ascx.cs"
    Inherits="Adicom.Web.admin.Modules.UsersContro" %>
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%; background-color: #fff">
    <tr>
        <td colspan="2" style="background-color: #afeeee; height: 1px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="left" colspan="2" style="padding-left: 30px; height: 35px">
            <img alt="" src="../Images/menu/icon5.jpg" style="width: 24px; border: 0px; vertical-align: bottom" />
            <asp:Label ID="Label1" runat="server" CssClass="admin_menu" 
                Text="TẠO MỚI NGƯỜI QUẢN LÝ " />
        </td>
    </tr>
    <tr>
        <td class="admin_thongtin" colspan="2" style="padding-left: 30px">
            <div style="background-color: #2B55A3; width: 100%">
                ADD NEW</div>
        </td>
    </tr>
    <tr>
        <td align="left" colspan="2" style="padding-left: 30px">
            Lưu ý : ( <font color="red">*</font> ) Bạn phải nhập thông tin !.
        </td>
    </tr>
    <tr>
        <td class="admin" style="padding-left: 30px; height: 35px; width: 171px">
            Tên Đăng Nhập :
        </td>
        <td align="left">
            <asp:TextBox ID="txtUser" runat="server" Width="200px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUser"
                Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="admin" style="padding-left: 30px; height: 35px; width: 171px">
            Mật Khẩu :
        </td>
        <td align="left">
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" Width="200px" />
        </td>
    </tr>
    <tr>
        <td class="admin" style="padding-left: 30px; height: 35px; width: 171px">
            Phân quyền :
        </td>
        <td align="left">
            <asp:DropDownList ID="drlrole" runat="server" Width="200px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="admin" style="padding-left: 30px; height: 35px; width: 171px">
            Bệnh Viện
        </td>
        <td align="left">
            <asp:DropDownList ID="drlBenhvien" runat="server" Width="200px">
            </asp:DropDownList>
        </td>
    </tr>
</table>
<center>
    <asp:Literal ID="LtrEror" runat="server" Text="Bạn chưa nhập mật khẩu"></asp:Literal>
</center>
