<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCCallCenterLeft.ascx.cs" Inherits="Adicom.Web.Controls.UCCallCenterLeft" %>
<%@ Register TagPrefix="Localized" Namespace="Localization" Assembly="Localization" %>
<div class=headerleft>
<p>
<asp:HyperLink ID=HyperLink6 runat=server NavigateUrl="~/callcenter.aspx"><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral6" Key="callcenter" Colon="false" /></asp:HyperLink></p>
</div>
<div class=linkleft>
<ul>
<li><asp:HyperLink ID=link1 runat=server NavigateUrl="~/callcenter.aspx?name=callcenter1"><Localized:LocalizedLiteral runat="server" ID="lbMission" Key="callcenter1" Colon="false" /></asp:Hyperlink></li>
<li><asp:HyperLink ID=HyperLink1 runat=server NavigateUrl="~/callcenter.aspx?name=callcenter2"><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral1" Key="callcenter2" Colon="false" /></asp:Hyperlink></li>
<li><asp:HyperLink ID=HyperLink2 runat=server NavigateUrl="~/callcenter.aspx?name=callcenter3"><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral2" Key="callcenter3" Colon="false" /></asp:Hyperlink></li>
<li><asp:HyperLink ID=HyperLink3 runat=server NavigateUrl="~/callcenter.aspx?name=callcenter4"><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral3" Key="callcenter4" Colon="false" /></asp:Hyperlink></li>
</ul>
</div>