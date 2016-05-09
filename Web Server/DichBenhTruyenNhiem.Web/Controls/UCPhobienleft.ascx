<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPhobienleft.ascx.cs"
    Inherits="Adicom.Web.Controls.UCPhobienleft" %>
<%@ Register TagPrefix="Localized" Namespace="Localization" Assembly="Localization" %>
<div class="headerleft">
    <p>
        <Localized:LocalizedLiteral runat="server" ID="newlb" Key="phobien" Colon="false" /></p>
</div>
<div class="linkleft">
    <ul>
        <li>
            <asp:HyperLink ID="link1" runat="server" NavigateUrl="~/Phobiens.aspx?phobien=1">
                <Localized:LocalizedLiteral runat="server" ID="lbMission" Key="phobien1" Colon="false" /></asp:HyperLink>
            <p>
                &nbsp;</p>
        </li>
        <li>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Phobiens.aspx?phobien=2">
                <Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral1" Key="phobien2"
                    Colon="false" /></asp:HyperLink>
            <p>
                &nbsp;</p>
        </li>
        <li>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Phobiens.aspx?phobien=3">
                <Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral2" Key="phobien3"
                    Colon="false" /></asp:HyperLink>
            <p>
                &nbsp;</p>
        </li>
        <li>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Phobiens.aspx?phobien=4">
                <Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral6" Key="phobien4"
                    Colon="false" /></asp:HyperLink>
            <p>
                &nbsp;</p>
        </li>
    </ul>
</div>
