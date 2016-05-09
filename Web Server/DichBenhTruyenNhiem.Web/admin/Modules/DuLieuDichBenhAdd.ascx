<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DuLieuDichBenhAdd.ascx.cs" Inherits="Adicom.Web.admin.Modules.DuLieuDichBenhAdd" %>
<%@ Register Src="DuLieuDichBenhControl.ascx" TagName="DulieuDichBenhControl" TagPrefix="uc1" %>
<div class="section-header">
    <div class="title">
        <img src="./Common_Img/ico-news.gif" alt="" />
        Thêm mới dữ liệu nhập bệnh <a href="DuLieuBenhDichs.aspx" title="Quay lại danh sách dữ liệu nhập bệnh">(Quay lại danh sách dữ liệu nhập bệnh)</a>
    </div>
    <div class="options">
        <asp:Button ID="SaveButton" runat="server" Text="Save" CssClass="adminButtonBlue"
             ToolTip="Save news item" onclick="SaveButton_Click" />
        
    </div>
</div>

<uc1:DulieuDichBenhControl ID="DulieuDichBenhControl1" runat="server" />