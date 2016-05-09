<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Whyadicom.aspx.cs" Inherits="Adicom.Web.admin.Whyadicom" %>

<%@ Register Src="Modules/WhyadicomControl.ascx" TagName="CallCenterControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:CallCenterControl id="CallCenterControl1" runat="server">
    </uc1:CallCenterControl>
</asp:Content>
