<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="BenhVienHome.aspx.cs" Inherits="Adicom.Web.admin.BenhVienHome" %>

<%@ Register src="Modules/BenhVienHome.ascx" tagname="BenhDichHome" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID=cph2 runat="server" ID="conten1">
    <uc1:BenhDichHome ID="BenhDichHome1" runat="server" />
</asp:Content>