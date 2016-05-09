<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="Adicom.Web.admin.news" Title="Untitled Page" %>
<%@ Register src="Modules/NewsHome.ascx" tagname="NewsHome" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:NewsHome ID="NewsHome1" runat="server" />
</asp:Content>
