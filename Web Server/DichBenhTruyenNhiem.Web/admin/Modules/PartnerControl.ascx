<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PartnerControl.ascx.cs" Inherits="Adicom.Web.admin.Modules.PartnerControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<table class="adminContent">
    <tr>
        <td class="adminTitle">
            Đối tác
        </td>
        <td class="adminData">
            <asp:DropDownList ID="dltype" runat="server">
                <asp:ListItem Value="1">Đối tác trong nước</asp:ListItem>
                <asp:ListItem Value="2">Đối tác quốc tế</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            Tiêu đề tiếng Việt
        </td>
        <td class="adminData">
            <asp:TextBox runat="server" ID="txtTitleVn" CssClass="adminInput" TextMode="MultiLine"
                Height="70px" />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            Tiêu đề tiếng Anh
        </td>
        <td class="adminData">
            <asp:TextBox runat="server" ID="txtTitleEn" CssClass="adminInput" TextMode="MultiLine"
                Height="70px" />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            Nội dung tiếng Việt
        </td>
        <td class="adminData">
            <FCKeditorV2:FCKeditor ID="txtContentVn" runat="server" AutoDetectLanguage="false"
                Height="350">
            </FCKeditorV2:FCKeditor>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            Nội dung tiếng Anh
        </td>
        <td class="adminData">
            <FCKeditorV2:FCKeditor ID="txtContentEn" runat="server" AutoDetectLanguage="false"
                Height="350">
            </FCKeditorV2:FCKeditor>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            Hình Ảnh
        </td>
        <td class="adminData">
            <asp:FileUpload ID="FUpdImage" runat="server" />
        </td>
    </tr>
</table>