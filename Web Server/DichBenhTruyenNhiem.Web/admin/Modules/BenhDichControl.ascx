<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BenhDichControl.ascx.cs" Inherits="Adicom.Web.admin.Modules.BenhDichControl" %>
<style type="text/css">

    .style2
    {
        width: 171px;
        height: 35px;
    }
    .style3
    {
        height: 35px;
    }
    </style>
<style type="text/css">

    .style2
    {
        width: 171px;
        height: 35px;
    }
    .style3
    {
        height: 35px;
    }
</style>
<table border="0" cellpadding="0" cellspacing="0" 
    style="width: 100%; background-color: #fff">
    <tr>
        <td colspan="2" style="background-color: #afeeee; height: 1px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="left" colspan="2" style="padding-left: 30px; height: 35px">
            <img alt="" src="../Images/menu/icon5.jpg" 
                style="width: 24px; border: 0px; vertical-align: bottom" />
            <asp:Label ID="Label1" runat="server" CssClass="admin_menu" 
                Text="TẠO MỚI DỊCH BỆNH " />
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
            Tên Dịch Bệnh :
        </td>
        <td align="left">
            <asp:TextBox ID="txtbenhvien" runat="server" MaxLength="250" Width="200px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtbenhvien" Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="admin" style="padding-left: 30px; height: 35px; width: 171px">
            Thời gian bùng phát dịch
        </td>
        <td align="left">
            <asp:TextBox ID="txtdate" runat="server" MaxLength="250" Width="200px" 
                Enabled="False" />
        </td>
    </tr>
    <tr>
        <td class="style2" style="padding-left: 30px;">
            Ghi Chú :
        </td>
        <td align="left" class="style3">
            <asp:TextBox ID="txtghichu" runat="server" MaxLength="250" Width="400px" />
        </td>
    </tr>
    </table>
