<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="newsadd.aspx.cs" Inherits="Adicom.Web.admin.newsadd" Title="Untitled Page" %>

<%@ Register Src="Modules/NewsAdd.ascx" TagName="NewsAdd" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:NewsAdd id="NewsAdd1" runat="server" OnLoad="NewsAdd1_Load">
    </uc1:NewsAdd>
</asp:Content>
