<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BaoCaoDichBenhTheoNam.ascx.cs" Inherits="Adicom.Web.admin.Modules.BaoCaoDichBenhTheoNam" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.2" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v8.2" namespace="DevExpress.Web.ASPxGridView" tagprefix="dxwgv" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<style type="text/css">
    .dxeTextBox, .dxeMemo
{
    background-color: white;
    border: solid 1px #9f9f9f;
}
.dxeEditArea 
{
	font-family: Tahoma;
	font-size: 9pt;
	border: 1px solid #A0A0A0;
}
.dxgvControl,
.dxgvDisabled
{
	border: Solid 1px #9F9F9F;
	font: 11px Tahoma;
	background-color: #F2F2F2;
	color: Black;
	cursor: default;
}

.dxgvTable
{
	background-color: White;
	border: 0;
	border-collapse: separate!important;
	overflow: hidden;
	font: 9pt Tahoma;
	color: Black;
}

.dxgvHeader {
	cursor: pointer;
	white-space: nowrap;
	padding: 4px 6px 5px 6px;
	border: Solid 1px #9F9F9F;
	background-color: #DCDCDC;
	overflow: hidden;
	-moz-user-select: none;
}
.dxgvCommandColumn
{
	padding: 2px 2px 2px 2px;
}
.dxgvControl a 
{
	color: #5555FF;
}
.dxgvControl .dxpControl, .dxgvDisabled .dxpControl
{
	padding-top: 4px;    
}

.dxpControl
{
	font: 9pt Tahoma;
	color: black;
	padding: 5px 2px 5px 2px;
}
.dxpSummary
{
	font: 9pt Tahoma;
	color: black;
	white-space: nowrap;
	text-align: center;
	vertical-align: middle;
	padding: 1px 4px 0px 4px;
}
.dxpDisabled
{
	color: #acacac;
	border-color: #808080;
	cursor: default;
}

.dxpDisabledButton
{
	font: 9pt Tahoma;
	color: black;
	text-decoration: none;
}
.dxpButton
{
	font: 9pt Tahoma;
	color: #394EA2;
	text-decoration: underline;
	white-space: nowrap;
	text-align: center;
	vertical-align: middle;
}
.dxpCurrentPageNumber
{
	font: 9pt Tahoma;
	color: black;
	font-weight: bold;
	text-decoration: none;
	padding: 1px 3px 0px 3px;
}
.dxpPageNumber
{
	font: 9pt Tahoma;
	color: #394EA2;
	text-decoration: underline;
	text-align: center;
	vertical-align: middle;
	padding: 1px 5px 0px 5px;
}
    
.dxeButtonEdit
{
    background-color: white;
    border: solid 1px #9F9F9F;
    width: 170px;
}
.dxeButtonEditButton,

.dxeButtonEditButton, .dxeCalendarButton,
.dxeSpinIncButton, .dxeSpinDecButton,
.dxeSpinLargeIncButton, .dxeSpinLargeDecButton
{	
	vertical-align: middle;
	border: solid 1px #7f7f7f;
	cursor: pointer;
	cursor: hand;
} 
    </style>
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-news.gif" alt="Tin tức" /> Báo cáo tình hình dịch bệnh (theo 
        năm)
    </div>
    <div class="options">
        <asp:Button ID="ButtonSave" runat="server" Text="Save" 
            CssClass="adminButtonBlue" onclick="ButtonSave_Click" />
    </div>
</div>
<br />
<table border="0" cellpadding="0" cellspacing="0" style="width: 100%; ">
<tr>
    <td align="left" colspan="2" style="padding-left: 50px; height: 35px;">
        Lưu ý : ( <font color="red">*</font> ) Bạn phải nhập thông tin !<br />
        <asp:Literal ID="lrWarning" runat="server"/><br /><br />
    </td>
</tr>
<tr>     
    <td>
        <table border="0" cellpadding="2" cellspacing="2" style="width:100%; ">
        <tr>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Năm Báo Cáo:
            </td>
            <td align="left" style="height: 35px;">
                <asp:DropDownList ID="ddlNam" runat="server" Enabled="true" MaxLength="250" 
                    Width="200px" />
            </td>                    
            <td align="left" style="padding-left: 50px; height: 35px;">
                Ngày Báo Cáo:
            </td>
            <td align="left" style="height: 35px;">
                <dxe:ASPxDateEdit ID="cldNgayBaoCao" runat="server" Enabled="true" Width="200px" />  
            </td>
            <td align="left" style="padding-left: 50px; height: 35px;">
                &nbsp;</td>
            <td align="left" style="height: 35px;">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Mã Số:
            </td>
            <td align="left" style="height: 35px;">
                <asp:TextBox ID="txtMaBaoCao" runat="server" Enabled="true" MaxLength="250" Width="200px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMaBaoCao"
                     Display="Dynamic" ErrorMessage="*"/>            
            </td>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Nơi Báo Cáo
            </td>
            <td align="left" style="height: 35px;">
                <asp:DropDownList ID="ddlBenhVien" runat="server" Enabled="true" MaxLength="250" Width="200px" />                            
            </td>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Người Lập Báo Cáo:
            </td>
            <td align="left" colspan="5" style="height: 35px;">
                <asp:TextBox ID="txtNguoiBaoCao" runat="server" Enabled="true" MaxLength="250" Width="200px" />
            </td>            
        </tr>  
        <tr>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Các Nhận Xét / Đề Nghị:
            </td>
            <td colspan="6" class="adminData">
                <fckeditorv2:fckeditor ID="txtDeNghi" runat="server" AutoDetectLanguage="true" Height="350" />                    
            </td>                
        </tr>
        <tr>
            <td align="left" style="padding-left: 50px; height: 35px;">
                Các Biện Pháp Triển Khai:        
            </td>
            <td colspan="6" class="adminData">
                <fckeditorv2:fckeditor ID="txtBienPhapTrienKhai" runat="server" AutoDetectLanguage="false" Height="350" />                    
            </td>        
        </tr>         
        </table>
    </td>    
</tr>
<tr>
    <td align="left" style="padding-left: 50px; height: 35px;">
        <br /><br />
        Bảng Số Liệu Chi Tiết:
        <br /><br />
    </td>
</tr>
<tr>
    <td>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%;" >
        <tr>
            <th valign="center" rowspan="2" bgcolor="#122f66" align="center" style="width:7.1%">
                <font color="white">Ðịa Phương</font>
            </th>
            <th valign="center" rowspan="2" bgcolor="#122f66" align="center" style="width:7.1%">
                <font color="white">Dịch Bệnh</font>
            </th>            
            <th colspan="2" bgcolor="#122f66"><font color="white">Tháng1</font></th>
            <th colspan="2" bgcolor="#122f66"><font color="white">Tháng2</font></th>
            <th colspan="2" bgcolor="#122f66"><font color="white">Tháng3</font></th>
            <th colspan="2" bgcolor="#122f66"><font color="white">Tháng4</font></th>
            <th colspan="2" bgcolor="#122f66"><font color="white">Tháng5</font></th>
            <th colspan="2" bgcolor="#122f66"><font color="white">Tháng6</font></th>
            <th colspan="2" bgcolor="#122f66"><font color="white">Tháng7</font></th>
            <th colspan="2" bgcolor="#122f66"><font color="white">Tháng8</font></th>
            <th colspan="2" bgcolor="#122f66"><font color="white">Tháng9</font></th>
            <th colspan="2" bgcolor="#122f66"><font color="white">Tháng10</font></th>
            <th colspan="2" bgcolor="#122f66"><font color="white">Tháng11</font></th>
            <th colspan="2" bgcolor="#122f66"><font color="white">Tháng12</font></th>
        </tr>    
        <tr>
            <td align="center" bgcolor="#122f66"><font color="white">M</font></td>      
            <td align="center" bgcolor="#122f66"><font color="white">C</font></td>
            <td align="center" bgcolor="#122f66"><font color="white">M</font></td>      
            <td align="center" bgcolor="#122f66"><font color="white">C</font></td>
            <td align="center" bgcolor="#122f66"><font color="white">M</font></td>      
            <td align="center" bgcolor="#122f66"><font color="white">C</font></td>
            <td align="center" bgcolor="#122f66"><font color="white">M</font></td>      
            <td align="center" bgcolor="#122f66"><font color="white">C</font></td>
            <td align="center" bgcolor="#122f66"><font color="white">M</font></td>      
            <td align="center" bgcolor="#122f66"><font color="white">C</font></td>
            <td align="center" bgcolor="#122f66"><font color="white">M</font></td>      
            <td align="center" bgcolor="#122f66"><font color="white">C</font></td>
            <td align="center" bgcolor="#122f66"><font color="white">M</font></td>      
            <td align="center" bgcolor="#122f66"><font color="white">C</font></td>
            <td align="center" bgcolor="#122f66"><font color="white">M</font></td>      
            <td align="center" bgcolor="#122f66"><font color="white">C</font></td>
            <td align="center" bgcolor="#122f66"><font color="white">M</font></td>      
            <td align="center" bgcolor="#122f66"><font color="white">C</font></td>
            <td align="center" bgcolor="#122f66"><font color="white">M</font></td>      
            <td align="center" bgcolor="#122f66"><font color="white">C</font></td>
            <td align="center" bgcolor="#122f66"><font color="white">M</font></td>      
            <td align="center" bgcolor="#122f66"><font color="white">C</font></td>
            <td align="center" bgcolor="#122f66"><font color="white">M</font></td>      
            <td align="center" bgcolor="#122f66"><font color="white">C</font></td>
        </tr>    
        <tr>
            <td style="width:7.1%"><asp:DropDownList ID="ddlDiaPhuong" runat="server" Enabled="true" Width="100%" Height="100%"/></td>
            <td style="width:7.1%"><asp:DropDownList ID="ddlDichBenh" runat="server" Enabled="true" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T1_M" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T1_C" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T2_M" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T2_C" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T3_M" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T3_C" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T4_M" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T4_C" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T5_M" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T5_C" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T6_M" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T6_C" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T7_M" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T7_C" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T8_M" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T8_C" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T9_M" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T9_C" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T10_M" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T10_C" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T11_M" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T11_C" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T12_M" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
            <td style="width:3.55%"><asp:TextBox ID="T12_C" runat="server" Enabled="true" MaxLength="250" Width="100%" Height="100%"/></td>
        </tr>            
        <tr>
            <th align="left" colspan="23" style="height:40px">Ghi chú: (M: số ca mắc bệnh; C: số ca tử vong; Mi: số ca mắc tháng i; Ci: số ca 
                tử vong tháng i)</th>
            <th align="right" colspan="3" style="height:40px"><asp:Button ID="ButtonAdd" 
                    runat="server" Enabled="true" Text="Thêm Vào Bảng" 
                    CssClass="adminButtonBlue" onclick="ButtonAdd_Click"/></th>
        </tr>  
        <tr>
            <th align="left" colspan="23" style="height:40px">
                <asp:Literal ID="ltError" runat="server"/>
            </th>
        </tr>      
        </table>
    </td>
</tr>
<tr>
    <td>
    <asp:GridView ID="grvDuLieu" runat="server" AutoGenerateColumns="False" 
             Width="100%" HorizontalAlign="Center" 
             onrowdeleting="grvDuLieu_RowDeleting" >                         
             <Columns>
                 <asp:TemplateField ShowHeader="False">
                     <ItemTemplate>
                         <asp:LinkButton ID="lnkDelete" runat="server" Enabled="true" CausesValidation="False" 
                             CommandName="Delete" Text="Delete"  OnClientClick="return confirm('Bạn có chắc chắn xóa không?')"/>
                     </ItemTemplate>
                 </asp:TemplateField>
                <asp:BoundField DataField="DiaPhuong" HeaderText="Địa Phương" /> <%--field dùng để đổ dữ liệu vào--%>
                <asp:BoundField DataField="DichBenh" HeaderText="Dịch Bệnh" />                    
                <asp:BoundField DataField="T1_M" HeaderText="M 1" /> 
                <asp:BoundField DataField="T1_C" HeaderText="C 1" />                                        
                <asp:BoundField DataField="T2_M" HeaderText="M 2" /> <%--field dùng để đổ dữ liệu vào--%>
                <asp:BoundField DataField="T2_C" HeaderText="C 2" />                    
                <asp:BoundField DataField="T3_M" HeaderText="M 3" /> 
                <asp:BoundField DataField="T3_C" HeaderText="C 3" />                                        
                <asp:BoundField DataField="T4_M" HeaderText="M 4" /> <%--field dùng để đổ dữ liệu vào--%>
                <asp:BoundField DataField="T4_C" HeaderText="C 4" />                    
                <asp:BoundField DataField="T5_M" HeaderText="M 5" /> 
                <asp:BoundField DataField="T5_C" HeaderText="C 5" />                                        
                <asp:BoundField DataField="T6_M" HeaderText="M 6" /> <%--field dùng để đổ dữ liệu vào--%>
                <asp:BoundField DataField="T6_C" HeaderText="C 6" />                    
                <asp:BoundField DataField="T7_M" HeaderText="M 7" /> 
                <asp:BoundField DataField="T7_C" HeaderText="C 7" />                                        
                <asp:BoundField DataField="T8_M" HeaderText="M 8" /> <%--field dùng để đổ dữ liệu vào--%>
                <asp:BoundField DataField="T8_C" HeaderText="C 8" />                    
                <asp:BoundField DataField="T9_M" HeaderText="M 9" /> 
                <asp:BoundField DataField="T9_C" HeaderText="C 9" />                                        
                <asp:BoundField DataField="T10_M" HeaderText="M 10" /> <%--field dùng để đổ dữ liệu vào--%>
                <asp:BoundField DataField="T10_C" HeaderText="C 10" />                    
                <asp:BoundField DataField="T11_M" HeaderText="M 11" /> 
                <asp:BoundField DataField="T11_C" HeaderText="C 11" />                                        
                <asp:BoundField DataField="T12_M" HeaderText="M 12" /> 
                <asp:BoundField DataField="T12_C" HeaderText="C 12" />                                                         
             </Columns>
             <RowStyle HorizontalAlign="Center" />             
            <EmptyDataTemplate>
                Chưa nhập dữ liệu dịch bệnh
            </EmptyDataTemplate>
             <EditRowStyle HorizontalAlign="Center" />
        </asp:GridView>
        
     </td>
</tr>
</table>
