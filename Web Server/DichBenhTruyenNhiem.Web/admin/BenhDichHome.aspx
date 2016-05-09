<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin.Master" CodeBehind="BenhDichHome.aspx.cs" Inherits="Adicom.Web.admin.BenhDichHome" %>

<%@ Register src="Modules/BenhDichHome.ascx" tagname="BenhDichHome" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID=cph2 runat="server" ID="conten1">
    <uc1:BenhDichHome ID="BenhDichHome1" runat="server" />
</asp:Content>