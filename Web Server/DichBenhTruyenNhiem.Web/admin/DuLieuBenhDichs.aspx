<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="DuLieuBenhDichs.aspx.cs" Inherits="Adicom.Web.admin.DuLieuBenhDichs" %>
<%@ Register src="Modules/DulieudichbenhsAdmin.ascx" tagname="DuLieuDichBenhs" tagprefix="uc1" %>
<asp:Content ContentPlaceHolderID=cph2 ID="conten1" runat="server">
    <uc1:DuLieuDichBenhs ID="DuLieuDichBenhs1" runat="server" />
</asp:Content>
