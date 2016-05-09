<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Adicom.Web.admin.home" Title="Untitled Page" %>

<%@ Register Src="Modules/HomeControl.ascx" TagName="HomeControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:HomeControl ID="HomeControl1" runat="server" />
</asp:Content>
