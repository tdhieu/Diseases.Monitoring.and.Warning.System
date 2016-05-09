<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="BenhVienAdd.aspx.cs" Inherits="Adicom.Web.admin.BenhVienAdd" %>


<%@ Register Src="Modules/BenhVienAdd.ascx" TagName="BenhVienAdd" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:BenhVienAdd id="BenhVienAdd1" runat="server">
    </uc1:BenhVienAdd>
</asp:Content>