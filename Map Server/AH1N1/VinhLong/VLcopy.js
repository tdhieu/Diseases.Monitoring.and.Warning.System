var map1, layer1, mybounds1;
<!--Ham khoi tao ban do-->
function init1()
{
    <!--Tao vung bao quanh ban do-->
    var mapOptions = {
        maxExtent: new OpenLayers.Bounds(b0,b1,b2,b3),
        maxResolution: mr1,
        projection:pro,
        units:  unit,
        numZoomLevels:num,
        controls:[]
    };
    map1 =new OpenLayers.Map('form',mapOptions);
    var base=new OpenLayers.Layer("Lop nen",{
        isBaseLayer:true,
        displayInLayerSwitcher:false
    });
    map1.addLayer(base);

    layer1 = new OpenLayers.Layer.WMS("Vinh Long", $str+$str1, {
        layers: 'hanhchinh',
        format: 'image/png',
        isBaseLayer: false,
        transparent: true
    });
    map1.addLayer(layer1);
    mybounds1 = new OpenLayers.Bounds(b0,b1,b2,b3);
    map1.zoomToExtent(mybounds1);
    map1.addControl(new OpenLayers.Control.MousePosition({
        numdigits:1
    }));
    map1.events.register("mousemove",map,function(e){
        var mouseLoc=map.getLonLatFromPixel(e.xy);
    });
}
