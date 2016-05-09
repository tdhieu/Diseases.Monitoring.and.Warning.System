<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="CatalogHome.aspx.cs" Inherits="Adicom.Web.admin.CatalogHome" %>

<%@ Register src="Modules/CatalogHome.ascx" tagname="UserHome" tagprefix="uc1" %>
<asp:Content ContentPlaceHolderID="cph2" runat="server" ID="conten1">
    <uc1:UserHome ID="userHome" runat="server" ></uc1:UserHome>
</asp:Content>