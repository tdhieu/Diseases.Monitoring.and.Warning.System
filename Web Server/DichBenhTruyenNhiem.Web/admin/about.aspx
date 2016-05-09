<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="Adicom.Web.admin.about" Title="Untitled Page" %>

<%@ Register Src="Modules/AboutControl.ascx" TagName="AboutControlascx" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:AboutControlascx id="AboutControlascx1" runat="server">
    </uc1:AboutControlascx>
</asp:Content>
