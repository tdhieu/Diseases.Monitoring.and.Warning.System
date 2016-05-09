<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCServicesDetail.ascx.cs" Inherits="Adicom.Web.Controls.UCServicesDetail" %>
<div class=introduction>
<div class=productDetails>  
 <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td valign="top">
                                <asp:Image ID="imgProduct" runat="server"/>
                                <%--<img src="./images/en/Products_Clarity_02.jpg" width="780" height="153" wmode="opaque" quality="high" />--%>
                            </td></tr>
  </table>
</div>
<p>
<asp:Literal ID=litContent runat=server></asp:Literal></p>
</div>