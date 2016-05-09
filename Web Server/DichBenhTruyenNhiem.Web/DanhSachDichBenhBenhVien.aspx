<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DanhSachDichBenhBenhVien.aspx.cs"
    Inherits="Adicom.Web.DanhSachDichBenhBenhVien" %>

<%@ Register Src="Controls/UCServicesLeft.ascx" TagName="UCServicesLeft" TagPrefix="uc1" %>
<%@ Register Src="Controls/UCServices.ascx" TagName="UCServices" TagPrefix="uc2" %>
<%@ Register Src="admin/Modules/DanhSachDichBenhBenhVien.ascx" TagName="DanhSachDichBenhBenhVien" TagPrefix="uc4" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:UCServicesLeft ID="UCServicesLeft1" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc4:DanhSachDichBenhBenhVien ID="DanhSachDichBenhBenhVien1" runat="server" />
</asp:Content>