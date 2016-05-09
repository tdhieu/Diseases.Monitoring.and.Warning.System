<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Listnews.aspx.cs" Inherits="Adicom.Web.admin.listnews" Title="Untitled Page" %>

<%@ Register Src="Modules/News.ascx" TagName="News" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:News id="News1" runat="server">
    </uc1:News>
</asp:Content>
