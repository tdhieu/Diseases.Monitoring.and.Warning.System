<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="PhoBienHome.aspx.cs" Inherits="Adicom.Web.admin.PhoBienHome" %>

<%@ Register src="Modules/PhobienHome.ascx" tagname="UserHome" tagprefix="uc1" %>
<asp:Content ContentPlaceHolderID="cph2" runat="server" ID="conten1">
    <uc1:UserHome ID="userHome" runat="server" ></uc1:UserHome>
</asp:Content>