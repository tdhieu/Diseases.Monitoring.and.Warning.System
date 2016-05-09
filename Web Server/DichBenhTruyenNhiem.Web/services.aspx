<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="services.aspx.cs" Inherits="Adicom.Web.services" Title="services" %>
<%@ Register src="Controls/UCServicesLeft.ascx" tagname="UCServicesLeft" tagprefix="uc1" %>
<%@ Register src="Controls/UCServices.ascx" tagname="UCServices" tagprefix="uc2" %>
<%@ Register src="Controls/UCServicesDetail.ascx" tagname="UCServicesDetail" tagprefix="uc3" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:UCServicesLeft ID="UCServicesLeft1" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc3:UCServicesDetail ID="UCServicesDetail1" runat="server" />
    <uc2:UCServices ID="UCServices1" runat="server" />
</asp:Content>
