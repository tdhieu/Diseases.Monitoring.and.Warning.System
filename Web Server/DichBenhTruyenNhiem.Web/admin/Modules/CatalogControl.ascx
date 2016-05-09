<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CatalogControl.ascx.cs" Inherits="Adicom.Web.admin.Modules.CatalogControl" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<table class="adminContent">
    <tr>
        <td class="adminTitle">
            Cảnh Báo Dịch Bệnh
        </td>
        <td class="adminData">
            <asp:DropDownList ID=dlCategory runat=server Width="200px">
            <asp:ListItem Value=1>Dịch Bệnh </asp:ListItem>
            <asp:ListItem Value=2>Phòng Chống</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="adminTitle">
            Lĩnh Vực
        </td>
        <td class="adminData">
            <asp:DropDownList ID=dltype runat=server Width="200px">
            <asp:ListItem Value=1>Thông tin về dịch bệnh</asp:ListItem>
            <asp:ListItem Value=2>Biện pháp phòng chống</asp:ListItem>
            <asp:ListItem Value=3>Các câu hỏi thường gặp</asp:ListItem>
            <asp:ListItem Value=4>Lời Khuyên Bác Sỹ</asp:ListItem>
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