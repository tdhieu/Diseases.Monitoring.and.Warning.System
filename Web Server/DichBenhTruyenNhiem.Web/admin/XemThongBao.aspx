<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin.Master" CodeBehind="XemThongBao.aspx.cs" %>
<%@ Register Src="Modules/MailContent.ascx" TagName="MailContent" TagPrefix="uc2" %>
<%@ Register Src="Modules/MailList.ascx" TagName="MailList" TagPrefix="uc1" %>
<asp:Content ContentPlaceHolderID="cph2" runat="server" ID="conten1">
<div class="section-header">
    <div class="title">
        <img alt="Tin tức" src="Common_Img/ico-news.gif" /> 
        Xem Thông Báo
    </div>
</div>

<table border="1" width="100%">
<tr>
    <td style="width:25%">
        <uc1:MailList id="MailList1" runat="server" />
    </td>
    <td style="width:85%">
        <uc2:MailContent id="MailContent1" runat="server"/>  
    </td>
</tr>
</table>
</asp:Content>