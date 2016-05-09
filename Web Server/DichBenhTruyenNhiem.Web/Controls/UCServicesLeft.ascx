<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCServicesLeft.ascx.cs"
    Inherits="Adicom.Web.Controls.UCServicesLeft" %>
<%@ Register TagPrefix="Localized" Namespace="Localization" Assembly="Localization" %>
<div class="headerleft">
    <p>
        <Localized:LocalizedLiteral runat="server" ID="lbproduct" Key="product" Colon="false" /></p>
</div>
<div class="linkleft">
    <ul>
        <li>
            <asp:HyperLink ID="link1" runat="server" NavigateUrl="~/services.aspx?type=1&cat=1">
                <Localized:LocalizedLiteral runat="server" ID="lbprod1" Key="productcat1" Colon="false" /></asp:HyperLink>
            <p>
            </p>
        </li>
        <li>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/services.aspx?type=1&cat=2">
                <Localized:LocalizedLiteral runat="server" ID="lbprod2" Key="productcat2" Colon="false" /></asp:HyperLink>
            <p>
            </p>
        </li>
        
    </ul>
</div>
<div class="headerleft">
    <p>
        <Localized:LocalizedLiteral runat="server" ID="lbService" Key="service" Colon="false" /></p>
</div>
<div class="linkleft">
    <ul>
        <li>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/services.aspx?type=2&cat=1">
                <Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral3" Key="servicecat1"
                    Colon="false" /></asp:HyperLink>
            <p>
            </p>
        </li>
        <li>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/services.aspx?type=2&cat=2">
                <Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral4" Key="servicecat2"
                    Colon="false" /></asp:HyperLink>
            <p>
            </p>
        </li>
    </ul>
</div>
