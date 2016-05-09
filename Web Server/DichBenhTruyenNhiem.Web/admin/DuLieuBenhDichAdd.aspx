<%@ Page Language="C#" MasterPageFile ="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="DuLieuBenhDichAdd.aspx.cs" Inherits="Adicom.Web.admin.DuLieuBenhDichAdd" %>

<%@ Register src="Modules/DuLieuDichBenhAdd.ascx" tagname="DuLieuDichBenhAdd" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID ="cph2" ID="conten1" runat="server" >
    <uc1:DuLieuDichBenhAdd ID="DuLieuDichBenhAdd1" runat="server" />
</asp:Content>