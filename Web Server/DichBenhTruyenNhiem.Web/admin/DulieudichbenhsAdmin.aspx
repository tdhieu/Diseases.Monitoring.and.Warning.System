<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="DulieudichbenhsAdmin.aspx.cs" Inherits="Adicom.Web.admin.DulieudichbenhsAdmin" %>
<%@ Register src="Modules/DulieudichbenhsAdmin.ascx" tagname="DuLieuDichBenhs" tagprefix="uc1" %>
<asp:Content ContentPlaceHolderID=cph2 ID="conten1" runat="server">
    <uc1:DuLieuDichBenhs ID="DuLieuDichBenhs1" runat="server" />
</asp:Content>

