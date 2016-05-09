<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin.Master" CodeBehind="PhoBienAdd.aspx.cs" Inherits="Adicom.Web.admin.PhoBienAdd" %>

<%@ Register src="Modules/PhoBienAdd.ascx" tagname="PhoBienAdd" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:PhoBienAdd ID="Catalog11" runat="server" />
</asp:Content>