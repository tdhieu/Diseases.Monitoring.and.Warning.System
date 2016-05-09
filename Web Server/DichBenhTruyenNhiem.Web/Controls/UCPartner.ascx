<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPartner.ascx.cs" Inherits="Adicom.Web.Controls.UCPartner" %>
<div>
    <ul class="newsList">
        <asp:Repeater ID="rptPartner" runat="server" DataSourceID="ParrnerDataSource" OnItemDataBound="rptPartner_ItemDataBound">
            <ItemTemplate>
                <li>
                    <table cellpadding="0" cellspacing="0" width="100%" border="0">
                        <tr>
                            <td valign="top" align=left width=150px>
                                
                                <img src='<%#Eval("logo")%>' width=150px />
                            </td>
                            <td valign="top" align=left>
                                                
                                <h3> <%#Adicom.Web.Code.WebUtils.GetLanguageValue(Eval("Name_vn").ToString(), Eval("Name_en").ToString())%></h3>
                                <br />
                                <%#Adicom.Web.Code.WebUtils.GetLanguageValue(Eval("Description_vn").ToString(), Eval("Description_en").ToString())%>
                            </td>
                        </tr>
                    </table>
                    <br />
                </li>
            </ItemTemplate>
        </asp:Repeater>
     </ul>
     <asp:ObjectDataSource ID="ParrnerDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
            SelectMethod="GetDataByType" 
        TypeName="Adicom.Web.Code.PartnerController">
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="1" Name="type" QueryStringField="type" 
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    
</div>
