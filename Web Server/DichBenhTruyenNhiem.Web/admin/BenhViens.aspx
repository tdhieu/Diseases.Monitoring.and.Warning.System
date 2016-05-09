<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="BenhViens.aspx.cs" Inherits="Adicom.Web.admin.BenhViens" %>

<%@ Register Src="Modules/BenhViens.ascx" TagName="BenhViens" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:BenhViens id="BenhViens1" runat="server">
    </uc1:BenhViens>
</asp:Content>