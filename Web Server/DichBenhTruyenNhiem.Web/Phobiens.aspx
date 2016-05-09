<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Phobiens.aspx.cs" Inherits="Adicom.Web.Phobiens" %>
<%@ Register src="Controls/UCPhobienleft.ascx" tagname="UCServicesLeft" tagprefix="uc1" %>
<%@ Register src="Controls/UCPhobiens.ascx" tagname="UCServices" tagprefix="uc2" %>
<%@ Register src="Controls/UCPhobienDetail.ascx" tagname="UCServicesDetail" tagprefix="uc3" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:UCServicesLeft ID="UCServicesLeft1" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc3:UCServicesDetail ID="UCServicesDetail1" runat="server" />
    <uc2:UCServices ID="UCServices1" runat="server" />
</asp:Content>
