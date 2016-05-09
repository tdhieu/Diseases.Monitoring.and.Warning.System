<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DanhSachDichBenhBenhVien.ascx.cs"
    Inherits="Adicom.Web.admin.Modules.DanhSachDichBenhBenhVien" %>
<%@ Register Assembly="DevExpress.XtraCharts.v8.2.Web, Version=8.2.4.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5"
    Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.XtraCharts.v8.2, Version=8.2.4.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5"
    Namespace="DevExpress.XtraCharts" TagPrefix="cc1" %>
<center>
    <p>
        Danh Sách Thống kê Và Biểu Đồ Giám Sát quản lý dịch bệnh truyền nhiễm
    </p>
    <table border="0" cellpadding="0" cellspacing="0" style="margin-bottom: 0px" width="100%">
        <tr>
            <td align="center">
                Từ Ngày
                <asp:TextBox ID="txtDateFrom" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td align="center">
                Đến Ngày
                <asp:TextBox ID="txtDateto" runat="server" Width="100px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                    Style="height: 26px" Text="Tìm Kiếm" />
            </td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" style="margin-bottom: 0px" width="100%">
        <tr>
            <td align="center">
                Tỉnh
                <asp:DropDownList ID="cbxTinh" runat="server" Width="90px" AutoPostBack="True" 
                    onselectedindexchanged="cbxTinh_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td align="center">
                Quận/Huyện
                <asp:DropDownList ID="cbxHuyen" runat="server" Width="90px" AutoPostBack="True" 
                    onselectedindexchanged="cbxHuyen_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td align="center">
                Bệnh Viện
                <asp:DropDownList ID="cbxbenhVien" runat="server" Width="90px" 
                    AutoPostBack="True" onselectedindexchanged="cbxbenhVien_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td align="center">
                Bệnh Dịch
                <asp:DropDownList ID="cbxBenhDich" runat="server" Width="90px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <p>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtDateFrom"
            ControlToValidate="txtDateto" Display="Dynamic" ErrorMessage="Bạn Chọn Ngày Không Hợp Lệ"
            Operator="GreaterThanEqual" Type="Date"></asp:CompareValidator>
    </p>
    <p>
        <asp:Literal ID="ltrDanhSach" runat="server"></asp:Literal>
    </p>
</center>
<asp:GridView ID="gvNews" runat="server" AllowPaging="True" AutoGenerateColumns="False"
    Width="100%" PageSize="30">
    <Columns>
        <asp:BoundField DataField="ThoiGian" HeaderText="Ngày" SortExpression="ThoiGian">
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="TruyenNhiem" HeaderText="Số Người Bị Truyền Nhiễm" SortExpression="TruyenNhiem">
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="TuVong" HeaderText="Số Người Tử Vong " SortExpression="TuVong">
            <FooterStyle HorizontalAlign="Right" />
            <HeaderStyle HorizontalAlign="Center" />
            <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
    </Columns>
    <EmptyDataTemplate>
        Chưa có dữ liệu nào
    </EmptyDataTemplate>
</asp:GridView>
&nbsp;&nbsp;
<p> Biểu đồ phát triển của dịch bệnh </p>
&nbsp;&nbsp;
<p>
    <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" ClientInstanceName="chart"
        DiagramTypeName="XYDiagram" Height="400px" Width="600px">
        <Titles>
            <cc1:ChartTitle Alignment="Near" Font="Tahoma, 10pt" Text="" />
            <cc1:ChartTitle Text="Biểu Đồ Số Bệnh Nhân Bị Truyền Nhiễm" />
        </Titles>
        <FillStyle FillOptionsTypeName="SolidFillOptions">
            <Options HiddenSerializableString="to be serialized" />
        </FillStyle>
        <BorderOptions Visible="False" />
        <Diagram>
            <axisx visibleinpanesserializable="-1">







<range sidemarginsenabled="False"></range>



</axisx>
            <axisy visibleinpanesserializable="-1">
<range sidemarginsenabled="True"></range>
</axisy>
        </Diagram>
        <SeriesTemplate LabelTypeName="PointSeriesLabel" PointOptionsTypeName="PointOptions"
            SeriesViewTypeName="SplineAreaSeriesView">
            <PointOptions HiddenSerializableString="to be serialized">
                <ValueNumericOptions Format="Number" />
            </PointOptions>
            <Label HiddenSerializableString="to be serialized" Visible="False" 
                OverlappingOptionsTypeName="PointOverlappingOptions">
                <FillStyle FillOptionsTypeName="SolidFillOptions">
                    <Options HiddenSerializableString="to be serialized" />
                </FillStyle>
            </Label>
            <View HiddenSerializableString="to be serialized" Transparency="0">
            </View>
            <LegendPointOptions HiddenSerializableString="to be serialized">
                <ValueNumericOptions Format="Number" />
            </LegendPointOptions>
        </SeriesTemplate>
        <SeriesSerializable>
            <cc1:Series ArgumentDataMember="ProductName" LabelTypeName="PointSeriesLabel" Name="Truyền Nhiễm "
                PointOptionsTypeName="PointOptions" SeriesPointsSorting="Ascending" SeriesPointsSortingKey="Value_1"
                SeriesViewTypeName="SplineAreaSeriesView" 
                ValueDataMembersSerializable="UnitPrice">
                <View HiddenSerializableString="to be serialized" Transparency="0">
                </View>
                <DataFilters>
                    <cc1:DataFilter ColumnName="ThoiGian" DataType="System.Int32" />
                    <cc1:DataFilter ColumnName="TruyenNhiem" DataType="System.Int32"></cc1:DataFilter>
                    <cc1:DataFilter ColumnName="TuVong" DataType="System.Int32"></cc1:DataFilter>
                    <cc1:DataFilter ColumnName="TruyenNhiem" DataType="System.Int32"></cc1:DataFilter>
                    <cc1:DataFilter ColumnName="TuVong" DataType="System.Int32"></cc1:DataFilter>
                    <cc1:DataFilter ColumnName="TruyenNhiem" DataType="System.Int32"></cc1:DataFilter>
                    <cc1:DataFilter ColumnName="TuVong" DataType="System.Int32"></cc1:DataFilter>
<cc1:DataFilter ColumnName="TruyenNhiem" DataType="System.Int32"></cc1:DataFilter>
<cc1:DataFilter ColumnName="TuVong" DataType="System.Int32"></cc1:DataFilter>
<cc1:DataFilter ColumnName="TruyenNhiem" DataType="System.Int32"></cc1:DataFilter>
<cc1:DataFilter ColumnName="TuVong" DataType="System.Int32"></cc1:DataFilter>
<cc1:DataFilter ColumnName="TruyenNhiem" DataType="System.Int32"></cc1:DataFilter>
<cc1:DataFilter ColumnName="TuVong" DataType="System.Int32"></cc1:DataFilter>
                </DataFilters>
                <DataFilters>
                    <cc1:DataFilter ColumnName="TruyenNhiem" DataType="System.Int32" />
                </DataFilters>
                <DataFilters>
                    <cc1:DataFilter ColumnName="TuVong" DataType="System.Int32" />
                </DataFilters>
                <Label HiddenSerializableString="to be serialized" 
                    OverlappingOptionsTypeName="PointOverlappingOptions">
                    <FillStyle FillOptionsTypeName="SolidFillOptions">
                        <Options HiddenSerializableString="to be serialized"></Options>
                    </FillStyle>
                </Label>
                <PointOptions HiddenSerializableString="to be serialized">
                </PointOptions>
                <LegendPointOptions HiddenSerializableString="to be serialized">
                </LegendPointOptions>
            </cc1:Series>
        </SeriesSerializable>
    </dxchartsui:WebChartControl>
</p>
<p>
    <dxchartsui:WebChartControl ID="WebChartControltruyennhiem" runat="server" ClientInstanceName="chart"
        DiagramTypeName="XYDiagram" Height="400px" Width="600px">
        <Titles>
            <cc1:ChartTitle Alignment="Near" Font="Tahoma, 10pt" Text="" />
            <cc1:ChartTitle Text="Biểu Đồ Số Bệnh Nhân Bị Tử Vong" />
        </Titles>
        <FillStyle FillOptionsTypeName="SolidFillOptions">
            <Options HiddenSerializableString="to be serialized" />
        </FillStyle>
        <BorderOptions Visible="False" />
        <Diagram>
            <axisx visibleinpanesserializable="-1">





<range sidemarginsenabled="False"></range>
</axisx>
            <axisy visibleinpanesserializable="-1">
<range sidemarginsenabled="True"></range>
</axisy>
        </Diagram>
        <SeriesTemplate LabelTypeName="PointSeriesLabel" PointOptionsTypeName="PointOptions"
            SeriesViewTypeName="SplineAreaSeriesView">
            <PointOptions HiddenSerializableString="to be serialized">
                <ValueNumericOptions Format="Number" />
            </PointOptions>
            <Label HiddenSerializableString="to be serialized" Visible="False" OverlappingOptionsTypeName="PointOverlappingOptions">
                <FillStyle FillOptionsTypeName="SolidFillOptions">
                    <Options HiddenSerializableString="to be serialized" />
                </FillStyle>
            </Label>
            <View HiddenSerializableString="to be serialized" transparency="0">
            </View>
            <LegendPointOptions HiddenSerializableString="to be serialized">
                <ValueNumericOptions Format="Number" />
            </LegendPointOptions>
        </SeriesTemplate>
        <SeriesSerializable>
            <cc1:Series ArgumentDataMember="ProductName" LabelTypeName="PointSeriesLabel" Name="Tử Vong "
                PointOptionsTypeName="PointOptions" SeriesPointsSorting="Ascending" SeriesPointsSortingKey="Value_1"
                SeriesViewTypeName="SplineAreaSeriesView" ValueDataMembersSerializable="UnitPrice">
                <View HiddenSerializableString="to be serialized" transparency="0">
                </View>
                <DataFilters>
                    <cc1:DataFilter ColumnName="ThoiGian" DataType="System.Int32" />
                    <cc1:DataFilter ColumnName="TruyenNhiem" DataType="System.Int32"></cc1:DataFilter>
                    <cc1:DataFilter ColumnName="TuVong" DataType="System.Int32"></cc1:DataFilter>
                    <cc1:DataFilter ColumnName="TruyenNhiem" DataType="System.Int32"></cc1:DataFilter>
                    <cc1:DataFilter ColumnName="TuVong" DataType="System.Int32"></cc1:DataFilter>
                    <cc1:DataFilter ColumnName="TruyenNhiem" DataType="System.Int32"></cc1:DataFilter>
                    <cc1:DataFilter ColumnName="TuVong" DataType="System.Int32"></cc1:DataFilter>
                </DataFilters>
                <DataFilters>
                    <cc1:DataFilter ColumnName="TruyenNhiem" DataType="System.Int32" />
                </DataFilters>
                <DataFilters>
                    <cc1:DataFilter ColumnName="TuVong" DataType="System.Int32" />
                </DataFilters>
                <Label HiddenSerializableString="to be serialized" OverlappingOptionsTypeName="PointOverlappingOptions">
                    <FillStyle FillOptionsTypeName="SolidFillOptions">
                        <Options HiddenSerializableString="to be serialized"></Options>
                    </FillStyle>
                </Label>
                <PointOptions HiddenSerializableString="to be serialized">
                </PointOptions>
                <LegendPointOptions HiddenSerializableString="to be serialized">
                </LegendPointOptions>
            </cc1:Series>
        </SeriesSerializable>
    </dxchartsui:WebChartControl>
</p>
