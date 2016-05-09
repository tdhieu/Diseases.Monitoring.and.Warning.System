var map, layer, mybounds,popup;
<!--Ham khoi tao ban do-->
function init()
{
    <!--Tao vung bao quanh ban do-->
    var mapOptions = {
        maxExtent: new OpenLayers.Bounds(b0,b1,b2,b3),
		maxResolution: mr,
        projection:pro,
        units:  unit,
        numZoomLevels:num,
        controls:[]
    };
    map =new OpenLayers.Map('abowtrai',mapOptions);
    var base=new OpenLayers.Layer("Lop nen",{
        isBaseLayer:true,
        displayInLayerSwitcher:false
    });
    map.addLayer(base);

    layer1 = new OpenLayers.Layer.WMS("Tra Vinh", $str+$str0, {
        layers: 'hanhchinh',
        format: 'image/png',
        isBaseLayer: false,
        transparent: true
    });
    map.addLayer(layer1);
//    layer2 = new OpenLayers.Layer.WMS("�uong", $str+$str0, {
//        layers: 'duong',
//        format: 'image/png',
//        isBaseLayer: false,
//        transparent: true
//    });
//    map.addLayer(layer2);
    mybounds = new OpenLayers.Bounds(b0,b1,b2,b3);
    map.zoomToExtent(mybounds);
    map.addControl(new OpenLayers.Control.LayerSwitcher() );
    map.addControl(new OpenLayers.Control.PanZoomBar({
        'zoomWorldIcon':true
    }));
    map.addControl(new OpenLayers.Control.Navigation());
    map.addControl(new OpenLayers.Control.ScaleLine());
    map.addControl(new OpenLayers.Control.MousePosition({
        numdigits:1
    }));
    <!--Lay toa do vi tri chuot khi click-->
    map.events.register("click",map,function(e)
    {
        var mouseLoc=map.getLonLatFromPixel(e.xy).toString().split(",");
        var coords = OpenLayers.Util.getElement("coords");
        var coords2 = OpenLayers.Util.getElement("coords2");
        var a=mouseLoc[0].toString().split("=");
        coords.innerHTML= a[1];
        var b=mouseLoc[1].toString().split("=");
        coords2.innerHTML= b[1];
    });
    map.events.register("mousemove",map,function(e){
        var mouseLoc=map.getLonLatFromPixel(e.xy);
    });
    <!--Lay toa do tai vi tri click chuot truy van len mapfile dua thong tin doi tuong ra popup-->
    map.events.register("click",map,function(evt)
    {
        var theInformat='text/html';
        var url=getURL_GetFeatureInfo(evt,layer1,theInformat);
        OpenLayers.loadURL(url,'',map,function(response)
        {
            if(popup!=null)
            {
                popup.destroy();
                popup=null;
            }
            var mouseLoc=map.getLonLatFromPixel(evt.xy);
            var popup_info=response.responseText;
            if(popup_info!="")
            {
                popup=new OpenLayers.Popup.FramedCloud("Thong tin",mouseLoc,new OpenLayers.Size(250,120),
                    popup_info,
                    null,
                    true
                    );
                popup.setOpacity(.50);
                popup.setBackgroundColor("#bcd2ee");
                map.addPopup(popup);
            }
        });
    }
    );
}
function getURL_GetFeatureInfo(evt, theLayer, theInformat)
{

    var url =  theLayer.getFullRequestString({
        REQUEST: "GetFeatureInfo",
        EXCEPTIONS: "application/vnd.ogc.se_xml",
        BBOX: theLayer.map.getExtent().toBBOX(),
        X: evt.xy.x,
        Y: evt.xy.y,
        INFO_FORMAT: theInformat,
        QUERY_LAYERS: theLayer.params.LAYERS,
        WIDTH: theLayer.map.size.w,
        HEIGHT: theLayer.map.size.h
    });

    return url;
};
<!--Nhay toi url chi dinh trong csdl-->
function gotopage(url)
{ 
    if(url!='')
        window.location=url;
}