<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="Adicom.Web.admin.catalog" Title="Untitled Page" %>
<%@ Register src="Modules/CatalogAdd.ascx" tagname="Catologcontro" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:Catologcontro ID="Catalog11" runat="server" />
</asp:Content>