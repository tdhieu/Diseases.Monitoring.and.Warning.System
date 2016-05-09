<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCContactUs.ascx.cs" Inherits="Adicom.Web.Controls.UCContactUs" %>
<%@ Register TagPrefix="Localized" Namespace="Localization" Assembly="Localization" %>
<div class=introduction>
<Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral5" Key="contactushelp"
            Colon="false" />
</div>
<div id=contact>
<table cellpadding=2 cellspacing=2>
<tr>
<td width=100><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral1" Key="fullname"
            Colon="false" /></td><td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td></tr>
<tr><td><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral2" Key="email"
            Colon="false" /></td><td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td></tr>
<tr><td><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral3" Key="tel"
            Colon="false" /></td><td><asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox></td></tr>
<tr><td><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral4" Key="company"
            Colon="false" /></td><td><asp:TextBox ID="textCompany" runat="server"></asp:TextBox></td></tr>
<tr><td><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral6" Key="city"
            Colon="false" /></td><td><asp:TextBox ID="txtCity" runat="server"></asp:TextBox></td></tr>
<tr><td><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral7" Key="country"
            Colon="false" /></td><td><asp:TextBox ID="txtCountry" runat="server"></asp:TextBox></td>
</tr>
<tr><td colspan=2><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral8" Key="request"
            Colon="false" /></td></tr>
<tr><td colspan=2><asp:TextBox ID="txtRequest" runat="server" TextMode=MultiLine Height=100 Width=450></asp:TextBox></td>
</tr>
<tr><td colspan=2><Localized:LocalizedLiteral runat="server" ID="LocalizedLiteral9" Key="hear"
            Colon="false" /><asp:DropDownList ID="dlReason" runat="server">
  
    </asp:DropDownList>
</td></tr>
<tr><td><asp:Button ID=btnSend runat=server Text=" Send " Width=100px 
        onclick="btnSend_Click"/></td><td><asp:Label ID=lbMessage runat=server ForeColor=Blue></asp:Label></td>
</tr>
    
</table>

</div>
<div style="height:30px;clear:both;"><br /></div>
