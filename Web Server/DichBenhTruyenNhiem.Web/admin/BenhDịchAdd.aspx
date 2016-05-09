<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="BenhDịchAdd.aspx.cs" Inherits="Adicom.Web.admin.BenhDịchAdd" %>
<%@ Register src="Modules/BenhDichAdd.ascx" tagname="BenhDichAdd" tagprefix="uc1" %>
<asp:Content ContentPlaceHolderID="cph2" ID="conten1" runat="server">
    <uc1:BenhDichAdd ID="BenhDichAdd1" runat="server" />
</asp:Content>