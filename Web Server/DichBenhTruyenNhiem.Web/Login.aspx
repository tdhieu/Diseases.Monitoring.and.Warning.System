<%@ Page Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Adicom.Web.admin.Login" Title="Untitled Page"  Theme="admin"%>
<asp:Content ID="Content1" ContentPlaceHolderID="cph2" runat="server">
    <div align=center>
    <asp:Login ID="Login1" runat="server" BackColor="#EFF3FB" BorderColor="#B5C7DE" 
        BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
        Font-Size="12px" ForeColor="#333333" 
        FailureText="Sai tên đăng nhập hoặc mật khẩu" 
        DestinationPageUrl="~/admin/admin.aspx" onauthenticate="Login1_Authenticate">
        <TextBoxStyle Font-Size="12px" />
        <LoginButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid" 
            BorderWidth="1px" Font-Names="Verdana" Font-Size="12px" ForeColor="#284E98" />
        <LayoutTemplate>
            <table border="0" cellpadding="4" cellspacing="2" 
                style="border-collapse:collapse;" width=300px>
                <tr>
                    <td>
                        <table border="0" cellpadding="2" width=100%>
                           
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Tên đăng nhập:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server" Font-Size="13px" Width=150px></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                        ControlToValidate="UserName" ErrorMessage="Vui lòng nhập tên đăng nhập." 
                                        ToolTip="Vui lòng nhập tên đăng nhập." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Mật khẩu:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" Font-Size="13px" TextMode="Password" Width=150px></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                        ControlToValidate="Password" ErrorMessage="Vui lòng nhập tên mật khẩu." 
                                        ToolTip="Vui lòng nhập tên mật khẩu." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." Visible=false />
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:Button ID="LoginButton" runat="server" BackColor="White" 
                                        BorderColor="#507CD1" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" 
                                        Font-Names="Verdana" Font-Size="12px" ForeColor="#284E98" Text="Đăng nhập" 
                                        ValidationGroup="Login1" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <TitleTextStyle BackColor="#507CD1" Font-Bold="True" Font-Size="12px" 
            ForeColor="White" />
</asp:Login>
</div>
</asp:Content>
