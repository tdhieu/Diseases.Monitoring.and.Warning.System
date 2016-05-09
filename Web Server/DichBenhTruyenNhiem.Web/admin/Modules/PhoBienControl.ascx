<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PhoBienControl.ascx.cs"
    Inherits="Adicom.Web.admin.Modules.PhoBienControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<table class="adminContent">
    <tr>
        <td class="adminTitle">
            Phổ Biến Loại Dịch Bệnh
        </td>
        <td class="adminData">
            <asp:DropDownList ID="dlPhoBien" runat="server" Width="200px">
                <asp:ListItem Value="1">Bệnh Nhi</asp:ListItem>
                    <asp:ListItem Value="2">Bệnh Da Liễu</asp:ListItem>
                    <asp:ListItem Value="3">Bệnh 1</asp:ListItem>
                    <asp:ListItem Value="4">Bệnh 2</asp:ListItem>
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
            Mô tả ngắn tiếng Việt
        </td>
        <td class="adminData">
            <asp:TextBox runat="server" ID="txtShortVn" CssClass="adminInput" TextMode="MultiLine"
                Height="150px" />
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            Mô tả ngắn tiếng Anh
        </td>
        <td class="adminData">
            <asp:TextBox runat="server" ID="txtShortEn" CssClass="adminInput" TextMode="MultiLine"
                Height="150px" />
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
