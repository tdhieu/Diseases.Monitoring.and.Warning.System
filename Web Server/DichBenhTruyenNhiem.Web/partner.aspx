<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="partner.aspx.cs" Inherits="Adicom.Web.product" Title="partner" %>
<%@ Register src="Controls/UCPartnerLeft.ascx" tagname="UCPartnerLeft" tagprefix="uc1" %>
<%@ Register src="Controls/UCPartner.ascx" tagname="UCPartner" tagprefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:UCPartnerLeft ID="UCPartnerLeft1" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:UCPartner ID="UCPartner1" runat="server" />
</asp:Content>
