<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNews.ascx.cs" Inherits="Adicom.Web.Controls.UCNews" %>
<div>
    <ul class="newsList">
        <asp:Repeater ID="rptNew" runat="server" DataSourceID="NewDataSource" OnItemDataBound="rptNew_ItemDataBound">
            <ItemTemplate>
                <li><i>
                    <%#((DateTime)Eval("publish_date")).ToShortDateString() %></i> :
                    <asp:HyperLink runat="server" ID="hplMore" NavigateUrl="~/news.aspx?id={0}">
<%#Adicom.Web.Code.WebUtils.GetLanguageValue(Eval("title_vn").ToString(), Eval("title_en").ToString())%>
                    </asp:HyperLink>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td valign="top">
                                <asp:HyperLink runat="server" ID="hplImg" NavigateUrl="~/news.aspx?id={0}">
                                <img src='<%#Eval("picture")%>' width=150px /></asp:HyperLink>
                            </td>
                            <td valign="top">
                                <%#Adicom.Web.Code.WebUtils.GetLanguageValue(Eval("short_vn").ToString(), Eval("short_en").ToString())%>
                            </td>
                        </tr>
                    </table>
                    <br />
                </li>
            </ItemTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource ID="NewDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetNewsByCategory" TypeName="Adicom.Web.Code.NewsController">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="1" Name="category" QueryStringField="type"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </ul>
</div>
