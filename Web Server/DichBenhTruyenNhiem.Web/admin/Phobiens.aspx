<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Phobiens.aspx.cs" Inherits="Adicom.Web.admin.Phobiens" %>

<%@ Register src="Modules/PhoBiens.ascx" tagname="PhoBiens" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:PhoBiens ID="Catalog11" runat="server" />
</asp:Content>