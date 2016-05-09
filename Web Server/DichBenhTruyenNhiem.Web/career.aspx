<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="career.aspx.cs" Inherits="Adicom.Web.career" Title="career" %>
<%@ Register src="Controls/UCAboutLeft.ascx" tagname="UCAboutLeft" tagprefix="uc1" %>
<%@ Register src="Controls/UCCareer.ascx" tagname="UCCareer" tagprefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:UCAboutLeft ID="UCAboutLeft1" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:UCCareer ID="UCCareer1" runat="server" />
</asp:Content>
