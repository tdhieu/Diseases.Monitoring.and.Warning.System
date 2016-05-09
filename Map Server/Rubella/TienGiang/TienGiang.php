<script type="text/javascript" src="../total/var.js"></script>
<?php
require '../total/dbconnect.php';
?>
<?php
$sql5 = "SELECT     SUM(socamacbenh) AS TongSoCaNhiemBenh
FROM         BC_SolieuBaocaoNam
WHERE     (iddichbenh = N'7')";
$rs5 = sqlsrv_query( $connection, $sql5, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));

$sql6 = "SELECT     SUM(socatuvong) AS TongSoCaTuVong
FROM         BC_SolieuBaocaoNam
WHERE     (iddichbenh = N'7')";
$rs6 = sqlsrv_query( $connection, $sql6, array(), array( "Scrollable" => SQLSRV_CURSOR_KEYSET ));

if($row = sqlsrv_fetch_array( $rs5, SQLSRV_FETCH_BOTH))
{
	$result5 = $row["TongSoCaNhiemBenh"];
}
if($row = sqlsrv_fetch_array( $rs6, SQLSRV_FETCH_BOTH))
{
	$result6 = $row["TongSoCaTuVong"];
}
?>
<?php
$url = "tg.JPG";
include("../total/template.php");
?>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<script type="text/javascript" src="../total/jscharts.js"></script>

<script type="text/javascript">
    var b=new Array("589060.700833","1126466.800951", "699537.549701", "1170725.042314");
    var b0=b[0];
    var b1=b[1];
    var b2=b[2];
    var b3=b[3];
	
    var mr=800;
	
    var mr1=900;
	
    var pro="EPSG:4236";
	
    var unit="m";
	
    var num= 12;
	
    var $str=serverweb+'/cgi-bin/mapserv.exe?map=';
    var $str0=serverOSGeo4W+'healthgismap/Rubella/TienGiang/TienGiang.map';
    var $str1=serverOSGeo4W+'healthgismap/Rubella/TienGiang/TGcopy.map';

	
</script>
<script src="../OpenLayers/OpenLayers.js"></script>
<script src="TGcopy.js"></script>
<script src="TienGiang.js"></script>
<script type="text/javascript">
    function getAjax()
    {
        var xmlhttp=null;
        if (window.XMLHttpRequest)
        {// code for IE7+, Firefox, Chrome, Opera, Safari
            xmlhttp=new XMLHttpRequest();
        }
        else
        {// code for IE6, IE5
            xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
        }

        return xmlhttp;
    }

    function draw()
    {
        var tenhuyen = document.getElementById("tenhuyen").innerHTML;

        tenhuyen = tenhuyen.trim();
        tenhuyen = tenhuyen.replace(" ", "%20", tenhuyen);




        var result5, result6, tongsoca;
        var rs5_data = new Array();
        var rs6_data= new Array();

        xmlhttp = getAjax();
        xmlhttp.open("GET","../total/ajax.php?do=1&tenhuyen=" +tenhuyen,true);
        xmlhttp.send();

        xmlhttp.onreadystatechange = function()
        {
            if(xmlhttp.readyState == 4)
            {
                if(xmlhttp.status == 200){


                    response = xmlhttp.responseText;



                    r = response.split(";");


                    result5 = r[0];

                    if(result5 == undefined || result5.length == 0 ) result5 = 0;
                    result6 = r[1];
                    if(result6 == undefined || result6.length == 0) result6 = 0;
                    tongsoca = Number(result5) + Number(result6);

                    for(i = 2; i<=13;++i) {
                        rs5_data[i-2] = r[i];
                        if(rs5_data[i-2] == undefined || rs5_data[i-2].length == 0) rs5_data[i-2] = 0;
                        rs5_data[i-2] = Number(rs5_data[i-2]);
                    }
                    for(j = 2; j<=13;++j) {
                        rs6_data[j-2] = r[j];
                        if(rs6_data[j-2] == undefined || rs6_data[j-2].length == 0) rs6_data[j-2] = 0;
                        rs6_data[j-2] = Number(rs6_data[j-2]);
                    }
                    document.getElementById("sumdealth").innerHTML = "<b>Tong so ca : </b>"+ tongsoca;
                    document.getElementById("sick").innerHTML="<b>So ca bi mac benh: </b>"+result5;
                    document.getElementById("dealth").innerHTML = "<b>So ca tu vong: </b> " +result6;

                    var myData = new Array([1, rs5_data[0] ], [2, rs5_data[1]], [3, rs5_data[2]], [4, rs5_data[3]], [5, rs5_data[4]], [6, 0], [7, 0], [8, 0], [9, 0], [10, 0], [11, 0],[12,0]);
                    var myData1 = new Array([1, rs6_data[0]], [3, rs6_data[1]], [4, rs6_data[2]], [5, rs6_data[3]], [6, rs6_data[4]], [7, 0], [8, 0], [9, 0], [10, 0], [11, 0],[12,0]);

                    var myChart = new JSChart('drawchart', 'line');
                    myChart.setAxisNameX('Tháng');
                    myChart.setAxisNameY('Ca');
                    myChart.setGrid(false);
                    myChart.setAxisValuesPrefixX('T');
                    myChart.setAxisValuesNumberX(12);
                    myChart.setDataArray(myData,'line1');
                    myChart.setTitle('Ban do thong ke');
                    myChart.setDataArray(myData1,'line2');
                    myChart.setLineColor('#C71112','line1');
                    myChart.setLineColor('#7D7D7D','line2');
                    myChart.setLineWidth(2);
                    myChart.setTitleColor('#7D7D7D');
                    myChart.setAxisColor('#9F0505');
                    myChart.setGridColor('#a4a4a4');
                    myChart.setAxisValuesColor('#333639');
                    myChart.setAxisNameColor('#333639');
                    myChart.setTextPaddingLeft(0);
                    myChart.resize(300,250);
                    myChart.draw();
                }
                else
                    alert(xmlhttp.statusText);
            }
        }

    }
    function vungtrongdiem()
    {
        var tenhuyen = document.getElementById("tenhuyen").innerHTML;

        tenhuyen = tenhuyen.trim();
        tenhuyen = tenhuyen.replace(" ", "%20", tenhuyen);
        //alert(tenhuyen);
        var rsnt_data = new Array();
        var rsnd_data= new Array();

        //alert("ajax.php?do=2&tenhuyen=" +tenhuyen);
        xmlhttp = getAjax();
        xmlhttp.open("GET","../total/ajax.php?do=2&tenhuyen=" +tenhuyen,true);

        xmlhttp.send();

        xmlhttp.onreadystatechange = function()
        {
            if(xmlhttp.readyState == 4)
            {
                if(xmlhttp.status == 200)
                {


                    response = xmlhttp.responseText;

                    //alert(xmlhttp.responseText);

                    r = response.split(";");

                    rsnt_data = r[0].split("_");
                    rsnd_data = r[1].split("_");
                    //                    if(rsnt_data == undefined ||rsnt_data.length==0)
                    //                    {
                    //                        rsnt_data=0;
                    //                    }
                    //                    if(rsnd_data == undefined || rsnd_data.length==0)
                    //                    {
                    //                        rsnd_data=0;
                    //                    }
                    //
                    for(i = 0; i<=3;++i) {
                       // rsnt_data[i] = r[0].split("_");
                        if(rsnt_data[i] == undefined || rsnt_data[i].length == 0) rsnt_data[i] = 0;
                        //rsnt_data[i] = Number(rsnt_data[i]);
                    }
                    for(j = 0; j<=3;++j) {
                       // rsnd_data[j] = r[1].split("_");
                        if(rsnd_data[j] == undefined || rsnd_data[j].length == 0) rsnd_data[j] = 0;
                       // rsnd_data[j] = Number(rsnd_data[j]);
                    }

                    document.getElementById("nt1").innerHTML=rsnt_data[3]+ '-' +rsnd_data[3];
                    document.getElementById("nt2").innerHTML=rsnt_data[1]+ '-' + rsnd_data[1];
                    document.getElementById("nt3").innerHTML=rsnt_data[2]+'-'+rsnd_data[2];
                    document.getElementById("nt4").innerHTML=rsnt_data[0]+'-'+rsnd_data[0];
                }
            }
        }

    }

</script>

