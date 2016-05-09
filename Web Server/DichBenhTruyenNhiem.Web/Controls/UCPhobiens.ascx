<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCPhobiens.ascx.cs" Inherits="Adicom.Web.Controls.UCPhobiens" %>
<div>
    <ul class="newsList">
        <asp:Repeater ID="rptServices" runat="server" DataSourceID="ServicesDataSource" OnItemDataBound="rptServices_ItemDataBound">
            <ItemTemplate>
                <li>
                    
                    <br />
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    <asp:ObjectDataSource ID="ServicesDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="GetPhoBienByType" TypeName="Adicom.Web.Code.PhoBienController">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="1" Name="type" 
                QueryStringField="phobien" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>