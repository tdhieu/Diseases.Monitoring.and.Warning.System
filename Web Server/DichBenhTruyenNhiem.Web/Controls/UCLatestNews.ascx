<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCLatestNews.ascx.cs" Inherits="Adicom.Web.Controls.UCLatestNews" %>
<%@ Register TagPrefix="Localized" Namespace="Localization" Assembly="Localization" %>
<div id=lastestNew class=module>
<h2 class="grr">
<Localized:LocalizedLiteral runat="server" ID="latestNewLabel" Key="latestNew" Colon="false" />
</h2>
<ul class="news">
<asp:Repeater ID=rptLatestNew runat=server DataSourceID="LatestNewDataSource" OnItemDataBound="rptLatestNew_ItemDataBound">
<ItemTemplate>
<li>
<i><%#((DateTime)Eval("publish_date")).ToShortDateString() %></i> : 
<asp:HyperLink runat=server ID=hplMore NavigateUrl="~/news.aspx?id={0}">
<%#Adicom.Web.Code.WebUtils.GetLanguageValue(Eval("title_vn").ToString(), Eval("title_en").ToString())%>
</asp:HyperLink></li>
</ItemTemplate>
</asp:Repeater>
    <asp:ObjectDataSource ID="LatestNewDataSource" runat="server"
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetLatestNews" 
        TypeName="Adicom.Web.Code.NewsController">
    </asp:ObjectDataSource>
</ul>
<div id=readMoreNews class=readMore>
<asp:HyperLink runat=server ID=hplMore NavigateUrl="~/news.aspx">
<Localized:LocalizedLiteral runat=server ID="seeMore" Key="more" Colon=false></Localized:LocalizedLiteral>
</asp:HyperLink>
</div>
</div>