<%@ Page Language="C#" MasterPageFile ="~/admin/admin.Master"  AutoEventWireup="true" CodeBehind="DuLieuBenhDichHome.aspx.cs" Inherits="Adicom.Web.admin.DuLieuBenhDichHome" %>
<%@ Register src="Modules/DuLieuBenhDichHome.ascx" tagname="DuLieuBenhDichHome" tagprefix="uc1" %>
<asp:Content ContentPlaceHolderID=cph2 ID="conten1" runat="server">
    <uc1:DuLieuBenhDichHome ID="DuLieuBenhDichHome1" runat="server" />
</asp:Content>