<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCAboutLeft.ascx.cs" Inherits="Adicom.Web.Controls.UCAboutLeft" %>
<%@ Register TagPrefix="Localized" Namespace="Localization" Assembly="Localization" %>
<div class=headerleft>
<p>
<asp:HyperLink ID=HyperLink6 runat=server NavigateUrl="~/about.aspx"><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral6" Key="about" Colon="false" /></asp:HyperLink></p>
</div>
<div class=linkleft>
<ul>
<li><asp:HyperLink ID=link1 runat=server NavigateUrl="~/about.aspx?name=Mission"><Localized:LocalizedLiteral runat="server" ID="lbMission" Key="Mission" Colon="false" /></asp:Hyperlink></li>
<li><asp:HyperLink ID=HyperLink1 runat=server NavigateUrl="~/about.aspx?name=Organization"><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral1" Key="Organization" Colon="false" /></asp:Hyperlink></li>
<li><asp:HyperLink ID=HyperLink2 runat=server NavigateUrl="~/about.aspx?name=Bod"><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral2" Key="Bod" Colon="false" /></asp:Hyperlink></li>
<li><asp:HyperLink ID=HyperLink3 runat=server NavigateUrl="~/about.aspx?name=Whyadicom"><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral3" Key="Whyadicom" Colon="false" /></asp:Hyperlink></li>
<li><asp:HyperLink ID=HyperLink4 runat=server NavigateUrl="~/career.aspx"><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral4" Key="career" Colon="false" /></asp:Hyperlink></li>
<li><asp:HyperLink ID=HyperLink5 runat=server NavigateUrl="~/contactus.aspx"><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral5" Key="contactus" Colon="false" /></asp:Hyperlink></li>
</ul>
</div>