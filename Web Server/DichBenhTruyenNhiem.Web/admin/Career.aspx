<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Career.aspx.cs" Inherits="Adicom.Web.admin.career" Title="Untitled Page" %>

<%@ Register Src="Modules/CareerControl.ascx" TagName="CareerControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:CareerControl id="CareerControl1" runat="server">
    </uc1:CareerControl>
</asp:Content>
