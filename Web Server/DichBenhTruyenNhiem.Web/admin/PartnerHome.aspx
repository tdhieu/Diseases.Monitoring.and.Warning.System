<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="PartnerHome.aspx.cs" Inherits="Adicom.Web.admin.PartnerHome" %>

<%@ Register src="Modules/PartnerHome.ascx" tagname="UserHome" tagprefix="uc1" %>
<asp:Content ContentPlaceHolderID="cph2" runat="server" ID="conten1">
    <uc1:UserHome ID="userHome" runat="server" ></uc1:UserHome>
</asp:Content>