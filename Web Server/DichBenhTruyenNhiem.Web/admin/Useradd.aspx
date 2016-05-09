<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin.Master" CodeBehind="Useradd.aspx.cs" Inherits="Adicom.Web.admin.Useradd" %>

<%@ Register Src="Modules/UserAdd.ascx" TagName="UsersAdd" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:UsersAdd id="UsersAdd1" runat="server">
    </uc1:UsersAdd>
</asp:Content>
