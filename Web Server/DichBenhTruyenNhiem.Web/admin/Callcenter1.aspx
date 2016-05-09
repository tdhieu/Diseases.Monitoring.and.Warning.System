<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Callcenter1.aspx.cs" Inherits="Adicom.Web.admin.callcenter1" %>
<%@ Register Src="~/admin/Modules/callcenter1.ascx" TagName="AboutControlascx" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:AboutControlascx id="AboutControlascx1" runat="server">
    </uc1:AboutControlascx>
</asp:Content>