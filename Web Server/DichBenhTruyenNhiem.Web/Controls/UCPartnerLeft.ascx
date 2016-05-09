<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPartnerLeft.ascx.cs" Inherits="Adicom.Web.Controls.UCPartnerLeft" %>
<%@ Register TagPrefix="Localized" Namespace="Localization" Assembly="Localization" %>
<div class=headerleft>
<p>
<a href="partner.aspx?type=1"> <Localized:LocalizedLiteral runat="server" ID="lbpartner" Key="partnertitle" Colon="false" /></a></p>
</div>
<div class=linkleft>
<ul>
<asp:Repeater ID=rptPartner runat=server DataSourceID="PartnerDataSource">
<ItemTemplate>
<li>
<%#Adicom.Web.Code.WebUtils.GetLanguageValue(Eval("Name_vn").ToString(), Eval("Name_en").ToString())%>
<p></p>
</li>

</ItemTemplate>
</asp:Repeater>
    <asp:ObjectDataSource ID="PartnerDataSource" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByType" 
        TypeName="Adicom.Web.Code.PartnerController">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="type" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</ul>
</div>
<div class=headerleft>
<p>
<a href="partner.aspx?type=2"><Localized:LocalizedLiteral runat="server" ID="lbclient" Key="client" Colon="false" /></a></p>
</div>
<div class=linkleft>
<ul>

<asp:Repeater ID=rptClient runat=server DataSourceID="ClientDataSource">
<ItemTemplate>
<li>
<%#Adicom.Web.Code.WebUtils.GetLanguageValue(Eval("Name_vn").ToString(), Eval("Name_en").ToString())%>
<p></p>
</li>

</ItemTemplate>
</asp:Repeater>
    <asp:ObjectDataSource ID="ClientDataSource" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByType" 
        TypeName="Adicom.Web.Code.PartnerController">
        <SelectParameters>
            <asp:Parameter DefaultValue="2" Name="type" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</ul>
</div>