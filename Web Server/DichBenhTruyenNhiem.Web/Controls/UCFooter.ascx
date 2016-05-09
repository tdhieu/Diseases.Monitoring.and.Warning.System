<%@ Control Language="C#" AutoEventWireup="true" Codebehind="UCFooter.ascx.cs" Inherits="Adicom.Web.Controls.UCFooter" %>
<%@ Register TagPrefix="Localized" Namespace="Localization" Assembly="Localization" %>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td>
            <div id="copyRight" class="footer_left">
                <Localized:LocalizedLiteral runat="server" ID="footerLang" Key="footer" Colon="false"></Localized:LocalizedLiteral></div>
        </td>
        <td align="right">
            <div id="bottomMenu">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td>
                            <a href="home.aspx" class="bottomMenu">
                                <Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral5" Key="home" Colon="false" /></a></td>
                        <td>
                            |</td>
                        <td>
                            <a href="sitemap.aspx" class="bottomMenu">
                                <Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral1" Key="sitemap" Colon="false" /></a></td>
                        <td>
                            |</td>
                        <td>
                            <a href="about.aspx" class="bottomMenu">
                                <Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral6" Key="term" Colon="false" />
                            </a>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
        </td>
    </tr>
</table>
