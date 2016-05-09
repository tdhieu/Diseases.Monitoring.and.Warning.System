<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Configuration.aspx.cs" Inherits="Adicom.Web.admin.configuration" Title="Untitled Page" %>
<%@ Register src="Modules/ConfigurationControl.ascx" tagname="ConfigurationControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:ConfigurationControl ID="ConfigurationControl1" runat="server" />
</asp:Content>
