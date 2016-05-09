<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin.Master" CodeBehind="GuiThongBao.aspx.cs" %>
<%@ Register src="Modules/GuiThongBao.ascx" tagname="GuiThongBao" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <uc1:GuiThongBao ID="GuiThongBao1" runat="server" />
</asp:Content>