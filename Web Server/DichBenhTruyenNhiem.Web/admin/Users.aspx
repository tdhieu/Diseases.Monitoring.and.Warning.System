<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="Adicom.Web.admin.Users" %>


<%@ Register Src="Modules/Users.ascx" TagName="Users" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:Users id="Users1" runat="server">
    </uc1:Users>
</asp:Content>
