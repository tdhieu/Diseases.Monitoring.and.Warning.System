<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MailList.ascx.cs" Inherits="Adicom.Web.admin.Modules.MailList" %>
<%@ Register TagPrefix="Localized" Namespace="Localization" Assembly="Localization" %>
<asp:Panel ID="Panel1" runat="server">
</asp:Panel>
<%--<div id="Announce" class="module">
<h2 class="grr">
<Localized:LocalizedLiteral runat="server" ID="MailList" Key="MailList" Colon="false" />
</h2>
<ul class="news">
    <asp:Repeater ID="rptAnnounce" runat="server">
        <ItemTemplate>
        <li>
            <i><%#((DateTime)Eval("ngaygui")).ToShortDateString() %></i> : 
            <asp:HyperLink runat="server" ID="linkItem" NavigateUrl="~/MailContent.ascx?id={0}">
                <%#Adicom.Web.Code.WebUtils.GetLanguageValue(Eval("title_vn").ToString(), Eval("title_en").ToString())%>
            </asp:HyperLink>
        </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
</div>--%>