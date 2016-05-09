<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="XemBaoCaoChiTietThang.aspx.cs" Inherits="Adicom.Web.admin.XemBaoCaoChiTietThang" %>

<%@ Register src="Modules/XemBaoCaoChiTietThang.ascx" tagname="XemBaoCaoChiTietThang" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID="cph2" ID="conten1" runat="server">
    <uc1:XemBaoCaoChiTietThang ID="XemBaoCaoChiTietThang1" runat="server" />
</asp:Content>
