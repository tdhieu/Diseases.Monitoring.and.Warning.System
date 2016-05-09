<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="Adicom.Web.admin.main" Title="Untitled Page" %>

<%@ Register Src="Modules/MainHome.ascx" TagName="MainHome" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:MainHome id="MainHome1" runat="server">
    </uc1:MainHome>
</asp:Content>
