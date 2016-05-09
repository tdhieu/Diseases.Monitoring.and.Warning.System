<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="news.aspx.cs" Inherits="Adicom.Web.news" Title="news" %>
<%@ Register src="Controls/UCNewsLeft.ascx" tagname="UCNewsLeft" tagprefix="uc1" %>
<%@ Register src="Controls/UCNews.ascx" tagname="UCNews" tagprefix="uc2" %>
<%@ Register src="Controls/UCNewsDetail.ascx" tagname="UCNewsDetail" tagprefix="uc3" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <uc1:UCNewsLeft ID="UCNewsLeft1" runat="server" />
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc2:UCNews ID="UCNews1" runat="server" />
    <uc3:UCNewsDetail ID="UCNewsDetail1" runat="server" />
</asp:Content>
