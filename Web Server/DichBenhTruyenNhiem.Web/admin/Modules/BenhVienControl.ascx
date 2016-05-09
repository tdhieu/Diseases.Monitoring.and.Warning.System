<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BenhVienControl.ascx.cs"
    Inherits="Adicom.Web.admin.Modules.BenhVienControl" %>
<style type="text/css">
    .style1
    {
        width: 171px;
    }
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
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%; background-color: #fff">
    <tr>
        <td colspan="2" style="background-color: #afeeee; height: 1px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td align="left" colspan="2" style="padding-left: 30px; height: 35px">
            <img alt="" src="../Images/menu/icon5.jpg" style="width: 24px; border: 0px; vertical-align: bottom" />
            <asp:Label ID="Label1" runat="server" CssClass="admin_menu" Text="TẠO MỚI BỆNH VIỆN" />
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
            Tên Bệnh Viện :
        </td>
        <td align="left">
            <asp:TextBox ID="txtbenhvien" runat="server" MaxLength="250" Width="200px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtbenhvien"
                Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="admin" style="padding-left: 30px; height: 35px; width: 171px">
            Địa Chỉ :
        </td>
        <td align="left">
            <asp:TextBox ID="txtdiachi" runat="server" MaxLength="250" Width="400px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdiachi"
                Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="admin" style="padding-left: 30px; height: 35px; width: 171px">
            Tỉnh Thành :
        </td>
        
        <td align="left">
            <asp:DropDownList ID="drltinh" runat="server" Width="200px" 
                onselectedindexchanged="drltinh_SelectedIndexChanged1" AutoPostBack="True">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="admin" style="padding-left: 30px; height: 35px; width: 171px">
            Quận Huyện :
        </td>
        <td align="left">
            <asp:DropDownList ID="drlquanhuyen" runat="server" Width="200px" 
                onselectedindexchanged="drlquanhuyen_SelectedIndexChanged1" 
                AutoPostBack="True">
            </asp:DropDownList>
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
    <tr>
        <td class="admin" style="padding-left: 30px; height: 35px; width: 171px">
            Người Đại Diện :
        </td>
        <td align="left">
            <asp:TextBox ID="txtnguoidaidien" runat="server" MaxLength="250" Width="400px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtnguoidaidien"
                Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="admin" style="padding-left: 30px; height: 35px; width: 171px">
            Số Điên Thọi :
        </td>
        <td align="left">
            <asp:TextBox ID="txtsodienthoi" runat="server" MaxLength="250" Width="200px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtsodienthoi"
                Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorNumber" runat="server"
                ControlToValidate="txtsodienthoi" Display="Dynamic" ErrorMessage="&lt;br /&gt;kiểu số"
                meta:resourcekey="RegularExpressionValidator6" ValidationExpression="\d+([-+.']\d+)*"
                Width="90px"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="admin" style="padding-left: 30px; height: 35px; width: 171px">
            Email :
        </td>
        <td align="left">
            <asp:TextBox ID="txtmail" runat="server" MaxLength="250" Width="400px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtmail"
                Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                ControlToValidate="txtmail" Display="Dynamic" ErrorMessage="Email không đúng" 
                ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" />
        </td>
    </tr>
    <tr>
        <td class="style1" style="padding-left: 30px;">
            Fax :
        </td>
        <td align="left">
            <asp:TextBox ID="txtfax" runat="server" MaxLength="250" Width="200px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtfax"
                Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorNumber0" runat="server"
                ControlToValidate="txtfax" Display="Dynamic" ErrorMessage="&lt;br /&gt;kiểu số"
                meta:resourcekey="RegularExpressionValidator6" ValidationExpression="\d+([-+.']\d+)*"
                Width="90px"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="admin" style="padding-left: 30px; height: 35px; width: 171px">
            WebSite :
        </td>
        <td align="left">
            <asp:TextBox ID="txtweb" runat="server" MaxLength="250" Width="400px" />
        </td>
    </tr>
</table>
