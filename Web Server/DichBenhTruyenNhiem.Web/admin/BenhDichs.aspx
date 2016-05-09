<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="BenhDichs.aspx.cs" Inherits="Adicom.Web.admin.BenhDichs" %>

<%@ Register src="Modules/BenhDich.ascx" tagname="BenhDichs" tagprefix="uc1" %>

<asp:Content ContentPlaceHolderID="cph2" ID="conten1" runat="server">
    <uc1:BenhDichs ID="BenhDichs1" runat="server" />
</asp:Content>