<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="callcenter.aspx.cs" Inherits="Adicom.Web.callcenter" Title="callcenter" %>
<%@ Register src="Controls/UCCallCenter.ascx" tagname="UCCallCenter" tagprefix="uc1" %>
<%@ Register src="Controls/UCCallCenterLeft.ascx" tagname="UCCallCenterLeft" tagprefix="uc2" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc2:UCCallCenterLeft ID="UCCallCenterLeft1" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UCCallCenter ID="UCCallCenter1" runat="server" />
</asp:Content>
