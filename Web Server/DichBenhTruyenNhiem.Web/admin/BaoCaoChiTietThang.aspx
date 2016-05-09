<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="BaoCaoChiTietThang.aspx.cs" %>
<%@ Register src="Modules/BaoCaoChiTietThang.ascx" tagname="BaoCaoChiTietThang" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID="cph2" ID="conten1" runat="server">
    <uc1:BaoCaoChiTietThang ID="BaoCaoChiTietThang1" runat="server" />
</asp:Content>
