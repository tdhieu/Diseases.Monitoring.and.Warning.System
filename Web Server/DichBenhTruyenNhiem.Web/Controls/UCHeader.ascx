<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCHeader.ascx.cs" Inherits="Adicom.Web.Controls.UCHeader" %>
<%@ Register Src="UCLanguage.ascx" TagName="UCLanguage" TagPrefix="adicom" %>
<%@ Register TagPrefix="Localized" Namespace="Localization" Assembly="Localization" %>
<div class="inside">
        <div class="header_left">
            <asp:HyperLink id="home" runat="server" NavigateUrl="~/home.aspx" Text="Viện Khoa Học"><img src="./images/logo.png" alt="Viện Khoa Học" border="0" /></asp:HyperLink>
            <div class="header_text">
                <h1 class="site-name"><a href="home.aspx" title="Viện Khoa Học">
                <asp:Literal ID="ltHeaderSiteName" runat="server"/>
                </a></h1>
                <span class="site-slogan">
                <asp:Literal ID="ltHeaderSlogan" runat="server" />
                </span>
            </div>
        </div>
        <div class="header_right">
            <div id="topMenu">
                   <table cellpadding="0" cellspacing="0" border="0" width="100%">
                        <tr>
                        <td><a href="about.aspx" class=bottomMenu>
                                <Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral5" Key="about" Colon="false" /></a></td>
                        <td>|</td>
                        <td><a href="career.aspx" class=bottomMenu><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral1" Key="career" Colon="false" /></a></td>
                        <td>|</td>
                        <td><a href="contactus.aspx" class=bottomMenu><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral6" Key="contactus" Colon="false" />
                                </a></td>
                         <td>|</td>
                        <td><adicom:UCLanguage ID="ucLanguage" runat="server" /></td>
                        </tr>
                        
                     </table>
            </div>
            <div class="search">
                
            </div>
        </div>
    </div>