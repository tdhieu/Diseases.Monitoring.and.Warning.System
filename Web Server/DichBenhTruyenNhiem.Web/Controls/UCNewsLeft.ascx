<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNewsLeft.ascx.cs" Inherits="Adicom.Web.Controls.UCNewsLeft" %>
<%@ Register TagPrefix="Localized" Namespace="Localization" Assembly="Localization" %>
<div class=headerleft>
<p>
<Localized:LocalizedLiteral runat="server" ID="newlb" Key="news" Colon="false" /></p>
</div>
<div class=linkleft>
<ul>
<li><asp:HyperLink ID=link1 runat=server NavigateUrl="~/news.aspx?type=1"><Localized:LocalizedLiteral runat="server" ID="lbMission" Key="type1" Colon="false" /></asp:Hyperlink>
<p><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral3" Key="type1des" Colon="false" /></p>
</li>
<li><asp:HyperLink ID=HyperLink1 runat=server NavigateUrl="~/news.aspx?type=2"><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral1" Key="type2" Colon="false" /></asp:Hyperlink>
<p><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral4" Key="type2des" Colon="false" /></p>
</li>
<li><asp:HyperLink ID=HyperLink2 runat=server NavigateUrl="~/news.aspx?type=3"><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral2" Key="type3" Colon="false" /></asp:Hyperlink>
<p><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral5" Key="type3des" Colon="false" /></p>
</li>

</ul>
</div>