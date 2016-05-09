<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCServicesHome.ascx.cs" Inherits="Adicom.Web.Controls.UCServicesHome" %>
<%@ Register TagPrefix="Localized" Namespace="Localization" Assembly="Localization" %>
<div id=service class=module>
<h2 class="grr">
<Localized:LocalizedLiteral runat="server" ID="servicesLabel" Key="services" Colon="false" />
</h2>
<ul class="news">
<asp:Repeater ID=rptRandomServices runat=server DataSourceID="rptRandomServicesDataSource" OnItemDataBound="rptRandomServices_ItemDataBound">
<ItemTemplate>
<li>
<asp:HyperLink runat=server ID=hplMore NavigateUrl="~/services.aspx?id={0}">
<%#Adicom.Web.Code.WebUtils.GetLanguageValue(Eval("Name_vn").ToString(), Eval("Name_en").ToString())%>
</asp:HyperLink></li>
</ItemTemplate>
</asp:Repeater>
    <asp:ObjectDataSource ID="rptRandomServicesDataSource" runat="server"
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="GetRandomServices" 
        TypeName="Adicom.Web.Code.ProductController">
    </asp:ObjectDataSource>
</ul>
<div id=readMoreNews class=readMore>
<asp:HyperLink runat=server ID=hplMore NavigateUrl="~/services.aspx">
<Localized:LocalizedLiteral runat=server ID="seeMore" Key="more" Colon=false></Localized:LocalizedLiteral>
</asp:HyperLink>
</div>
</div>