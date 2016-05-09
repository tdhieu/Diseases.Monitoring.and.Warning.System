<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MailContent.ascx.cs" Inherits="Adicom.Web.admin.Modules.MailContent" %>
<table class="adminContent" border="0">
    <tr>
        <td class="adminTitle">
            <font style="font-size:medium;">Chủ đề:</font>
        </td>
        <td class="style4" colspan="5">
            <asp:TextBox runat="server" ID="txtSubject" CssClass="adminInput" Width="100%" Height="25px" />                
        </td>
    </tr>
    <tr>
        <td class="adminTitle" >
            <font style="font-size:medium;">Ngày thông báo:</font>
        </td>
        <td class="adminData">
            <asp:TextBox ID="txtNgayThongBao" runat="server" CssClass="adminInput" Enabled="true" Height="25px" Width="200px" />
        </td> 
        <td class="adminTitle" style="padding-left:50px">
            <font style="font-size:medium;">Độ ưu tiên:
        </td>
        <td class="adminData">
            <asp:TextBox ID="txtDoUuTien" runat="server" CssClass="adminInput" Enabled="true" Height="25px" Width="200px" />
        </td>               
    </tr>
    <tr>
        <td class="adminTitle">
            <font style="font-size:medium;">Nơi gửi:</font>
        </td>
        <td class="style4">
            <asp:TextBox runat="server" ID="txtNoiGui" CssClass="adminInput" Enabled="true" Width="200px" Height="25px" />                
        </td>
        <td class="adminTitle" style="padding-left:50px">
            <font style="font-size:medium;">Nơi nhận:</font>
        </td>
        <td class="adminData">
            <asp:TextBox ID="txtNoiNhan" runat="server" CssClass="adminInput" Enabled="true" Height="25px" Width="200px" />
        </td> 
    </tr>
    <tr>
        <td class="adminTitle">
            <font style="font-size:medium;">Tập tin đính kèm:</font>
        </td>
        <td class="adminData">
            <asp:Button ID="ButtonDownload" runat="server" Text="Lưu về máy" Height="25px" 
                Width="200px" Font-Names="Arial" Font-Size="Medium" 
                onclick="ButtonDownload_Click"/>
        </td>               
        <td class="adminTitle"></td>
        <td class="adminData">
            <asp:Button ID="ButtonPrint" runat="server" Enabled="true" Width="200px" 
                Height="25px" Text="Print" Font-Names="Times New Roman" Font-Size="Medium" />        
        </td>               
        
    </tr>
    <tr><td><br /></td></tr>
    <tr>
        <td class="adminTitle">
            <font style="font-size:medium;">Nội dung:</font>
        </td>
 
        </td>
        <td class="style4" colspan="6">
            <asp:Panel ID="Panel1" runat="server" Enabled="true" BorderWidth="1" BorderStyle="Solid" Width="100%" Height="500px">
                <font style="font-size:medium; font-family:Times New Roman;">
                <asp:Literal ID="ltContent" runat="server"/>
                </font>
            </asp:Panel>
        </td>
    </tr>
</table>