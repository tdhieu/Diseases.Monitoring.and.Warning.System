<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DuLieuDichBenhControl.ascx.cs" Inherits="Adicom.Web.admin.Modules.DuLieuDichBenhControl" %>
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
            <asp:Label ID="Label1" runat="server" CssClass="admin_menu" 
                Text="Thêm số ca bị dịch bệnh" />
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
            <asp:TextBox ID="txtbenhvien" runat="server" MaxLength="250" Width="200px" 
                Enabled="False" />
        </td>
    </tr>
    <tr>
        <td class="admin" style="padding-left: 30px; height: 35px; width: 171px">
            Tên Dịch Bệnh :
        </td>
        <td align="left">
            <asp:DropDownList ID="drldichbenh" runat="server" Width="200px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style2" style="padding-left: 30px;">
            Ngày Cập Nhập :
        </td>
        <td align="left" class="style3">
            <asp:TextBox ID="txtdate" runat="server" MaxLength="250" Width="200px" />
            <asp:Calendar ID="Calendar1" runat="server" CssClass="style1" 
                onselectionchanged="Calendar1_SelectionChanged"></asp:Calendar>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtdate"
                Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="admin" style="padding-left: 30px; height: 35px; width: 171px">
            Số người bị truyền nhiễm&nbsp; :
        </td>
        <td align="left">
            <asp:TextBox ID="txtbitruyennhiem" runat="server" MaxLength="250" 
                Width="200px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtbitruyennhiem"
                Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorNumber1" runat="server"
                ControlToValidate="txtbitruyennhiem" Display="Dynamic" ErrorMessage="&lt;br /&gt;kiểu số"
                meta:resourcekey="RegularExpressionValidator6" ValidationExpression="\d+([-+.']\d+)*"
                Width="90px"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="admin" style="padding-left: 30px; height: 35px; width: 171px">
            Số người tử vong :
        </td>
        <td align="left">
            <asp:TextBox ID="txttuvong" runat="server" MaxLength="250" Width="200px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txttuvong"
                Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorNumber" runat="server"
                ControlToValidate="txttuvong" Display="Dynamic" ErrorMessage="&lt;br /&gt;kiểu số"
                meta:resourcekey="RegularExpressionValidator6" ValidationExpression="\d+([-+.']\d+)*"
                Width="90px"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="admin" style="padding-left: 30px; height: 35px; width: 171px">
            Các biện pháp triển khai:
        </td>
        <td align="left">
            <asp:TextBox ID="txtcacbienphaptrienkhai" runat="server" MaxLength="250" 
                Width="400px" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtcacbienphaptrienkhai"
                Display="Dynamic" ErrorMessage="*" Width="1px"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style1" style="padding-left: 30px;">
            Các đề nghị :
        </td>
        <td align="left">
            <asp:TextBox ID="txtcacdenghi" runat="server" MaxLength="250" Width="400px" />
        </td>
    </tr>
    </table>