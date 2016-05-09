<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="about.aspx.cs" Inherits="Adicom.Web.about" Title="about" %>
<%@ Register src="Controls/UCAbout.ascx" tagname="UCAbout" tagprefix="uc1" %>
<%@ Register src="Controls/UCAboutLeft.ascx" tagname="UCAboutLeft" tagprefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc2:UCAboutLeft ID="UCAboutLeft1" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCAbout ID="UCAbout1" runat="server" />
</asp:Content>
