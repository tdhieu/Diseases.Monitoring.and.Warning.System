<%@ Page Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="Adicom.Web.home" Title="home" %>
<%@ Register Src="~/Controls/UCServicesHome.ascx" TagName="UCServicesHome" TagPrefix="uc2" %>
<%@ Register Src="Controls/UCLatestNews.ascx" TagName="UCLatestNews" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class=introduction>
<asp:Literal ID=litHome runat=server></asp:Literal>
</div>
    <div style="height:10px;"></div>
    <uc1:UCLatestNews id="UCLatestNews1" runat="server">
    </uc1:UCLatestNews>
    <uc2:UCServicesHome id="UCServices1" runat="server">
    </uc2:UCServicesHome>
</asp:Content>
