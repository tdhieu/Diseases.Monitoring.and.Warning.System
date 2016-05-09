<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Listcatalog.aspx.cs" Inherits="Adicom.Web.admin.listcatalog" Title="Untitled Page" %>
<%@ Register Src="Modules/Catalogs.ascx" TagName="News" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:News id="Catalogs" runat="server">
    </uc1:News>
</asp:Content>
