<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UCMainMenu.ascx.cs"
    Inherits="Adicom.Web.Controls.UCMainMenu" %>
<asp:Menu ID="mnuMain" runat="server" DataSourceID="smdsMenuMain" Orientation="Horizontal"
    cssselectorclass="MainMenu" OnMenuItemDataBound="mnuMain_MenuItemDataBound">
</asp:Menu>
<asp:SiteMapDataSource ID="smdsMenuMain" runat="server" ShowStartingNode="false"
    SiteMapProvider="AdicomMenuSiteMapProvider" />
