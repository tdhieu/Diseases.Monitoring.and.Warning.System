<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="contactus.aspx.cs" Inherits="Adicom.Web.contactus" Title="contactus" %>
<%@ Register src="Controls/UCContactUs.ascx" tagname="UCContactUs" tagprefix="uc1" %>
<%@ Register src="Controls/UCContactUsLeft.ascx" tagname="UCContactUsLeft" tagprefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc2:UCContactUsLeft ID="UCContactUsLeft1" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCContactUs ID="UCContactUs1" runat="server" />
</asp:Content>
