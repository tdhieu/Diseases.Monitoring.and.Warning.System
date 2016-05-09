<%@ Page Language="C#" MasterPageFile ="~/admin/admin.Master"  AutoEventWireup="true" CodeBehind="DanhSachBaoCao.aspx.cs" Inherits="Adicom.Web.admin.DanhSachBaoCao" %>
<%@ Register src="Modules/DanhSachBaoCao.ascx" tagname="DanhSachBaoCao" tagprefix="uc" %>
<asp:Content ContentPlaceHolderID=cph2 ID="content1" runat="server">
    <uc:DanhSachBaoCao ID="DanhSachBaoCao1" runat="server" />
</asp:Content>