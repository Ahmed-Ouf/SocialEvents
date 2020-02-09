function myMap() {
    var lat = "27.102379";
    var lng = "49.565335";
    //real jubail rcj location 
    var myCenter = new google.maps.LatLng(lat, lng);
  
    if ((dbLongitude != undefined && dbLongitude != null) && (dbLatitude != undefined && dbLatitude != null)) {
        myCenter = new google.maps.LatLng(dbLatitude, dbLongitude);
    } else {
        $("#Latitude").val(lat);
        $("#Longitude").val(lng);
    }
    var mapOptions = {
        center: myCenter,
        zoom: 17,
        panControl: false,
        zoomControl: true,
        mapTypeControl: false,
        scaleControl: true,
        streetViewControl: false,
        overviewMapControl: false,
        rotateControl: false,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }
    var map = new google.maps.Map(document.getElementById("googleMap"), mapOptions);

    var marker = new google.maps.Marker({
        position: myCenter,
        animation: google.maps.Animation.DROP,
        title: "RCJ"
    });
    marker.setMap(map);

    google.maps.event.addListener(map, 'click', function (event) {
        placeMarker(map, event.latLng);
    });

    function placeMarker(map, location) {
        marker.setPosition(location);
        setHiddenFiledsValue(location);
        //var infowindow = new google.maps.InfoWindow({
        //    content: 'Latitude: ' + location.lat() + '<br>Longitude: ' + location.lng()
        //});
        //infowindow.open(map, marker);
    }
    function setHiddenFiledsValue(location) {
        $("#Latitude").val(location.lat());
        $("#Longitude").val(location.lng());
    }

}

