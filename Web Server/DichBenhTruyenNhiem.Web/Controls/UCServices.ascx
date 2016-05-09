<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCServices.ascx.cs"
    Inherits="Adicom.Web.Controls.UCServices" %>
<div>
    <ul class="newsList">
        <asp:Repeater ID="rptServices" runat="server" DataSourceID="ServicesDataSource" OnItemDataBound="rptServices_ItemDataBound">
            <ItemTemplate>
                <li>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td valign="top" align="left" width="150px">
                                <asp:HyperLink runat="server" ID="hplImg" NavigateUrl="~/services.aspx?id={0}">
                                <img src='<%#Eval("picture")%>' width=150px /></asp:HyperLink>
                            </td>
                            <td valign="top" align="left">
                                <asp:HyperLink runat="server" ID="hplMore" NavigateUrl="~/services.aspx?id={0}">
<%#Adicom.Web.Code.WebUtils.GetLanguageValue(Eval("Name_vn").ToString(), Eval("Name_en").ToString())%>
                                </asp:HyperLink><br />
                                <%#Adicom.Web.Code.WebUtils.GetLanguageValue(Eval("Short_vn").ToString(), Eval("Short_en").ToString())%>
                            </td>
                        </tr>
                    </table>
                    <br />
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <asp:ObjectDataSource ID="ServicesDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetDataByTypeAndCategory" TypeName="Adicom.Web.Code.ProductController">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="1" Name="type" QueryStringField="type" Type="Int32" />
            <asp:QueryStringParameter DefaultValue="1" Name="category" QueryStringField="cat"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>
