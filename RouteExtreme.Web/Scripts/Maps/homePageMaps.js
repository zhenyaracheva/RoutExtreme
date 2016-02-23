var map;

function initMap() {
    styles = [
{
    "featureType": "administrative",
    "elementType": "geometry.fill",
    "stylers": [{ "color": "#7f2200" }, { "visibility": "off" }]
},
{
    "featureType": "administrative",
    "elementType": "geometry.stroke",
    "stylers": [{ "visibility": "on" }, { "color": "#87ae79" }]
},
{
    "featureType": "administrative",
    "elementType": "labels.text.fill",
    "stylers": [{ "color": "#495421" }]
},
{
    "featureType": "administrative",
    "elementType": "labels.text.stroke",
    "stylers": [{ "color": "#ffffff" }, { "visibility": "on" }, { "weight": 4.1 }]
},
{
    "featureType": "administrative.province",
    "elementType": "labels.text",
    "stylers": [{ "visibility": "simplified" }]
},
{
    "featureType": "administrative.locality",
    "elementType": "labels",
    "stylers": [{ "visibility": "on" }]
},
{
    "featureType": "administrative.neighborhood",
    "elementType": "labels",
    "stylers": [{ "visibility": "off" }]
},
{
    "featureType": "landscape",
    "elementType": "geometry.fill",
    "stylers": [{ "color": "#abce83" }]
},
{
    "featureType": "poi",
    "elementType": "geometry.fill",
    "stylers": [{ "color": "#769E72" }]
},
{
    "featureType": "poi",
    "elementType": "labels.text.fill",
    "stylers": [{ "color": "#7B8758" }]
},
{
    "featureType": "poi",
    "elementType": "labels.text.stroke",
    "stylers": [{ "color": "#EBF4A4" }]
},
{
    "featureType": "poi.park",
    "elementType": "geometry",
    "stylers": [{ "visibility": "simplified" }, { "color": "#8dab68" }]
},
{
    "featureType": "road",
    "elementType": "geometry.fill",
    "stylers": [{ "visibility": "simplified" }]
},
{
    "featureType": "road",
    "elementType": "labels.text.fill",
    "stylers": [{ "color": "#5B5B3F" }]
},
{
    "featureType": "road",
    "elementType": "labels.text.stroke",
    "stylers": [{ "color": "#ABCE83" }]
},
{
    "featureType": "road", "elementType":
      "labels.icon", "stylers": [{ "visibility": "off" }]
},
{
    "featureType": "road.highway",
    "elementType": "geometry", "stylers": [{ "color": "#EBF4A4" }]
},
{
    "featureType": "road.highway",
    "elementType": "geometry.stroke", "stylers": [{ "visibility": "off" }]
},
{
    "featureType": "road.arterial",
    "elementType": "geometry", "stylers": [{ "color": "#9BBF72" }]
},
{
    "featureType": "road.local",
    "elementType": "geometry", "stylers": [{ "color": "#A4C67D" }]
},
{
    "featureType": "transit",
    "elementType": "all", "stylers": [{ "visibility": "on" }]
},
{
    "featureType": "water",
    "elementType": "geometry",
    "stylers": [{ "visibility": "on" }, { "color": "#aee2e0" }]
},
{
    "featureType": "water",
    "elementType": "labels",
    "stylers": [{ "visibility": "on" }]
}]

    styledMap = new google.maps.StyledMapType(styles, { name: "RoutExtreme" });

    mapOptions = {
        zoom: 7,
        center: new google.maps.LatLng(42.6252706, 25.3785853),
        mapTypeControlOptions: {
            mapTypeIds: [google.maps.MapTypeId.ROADMAP, 'map_style']
        }
    };

    map = new google.maps.Map(document.getElementById('map'), mapOptions);

    map.mapTypes.set('map_style', styledMap);
    map.setMapTypeId('map_style');

    var url = document.URL;
    var id = url.substring(url.lastIndexOf('/') + 1);
    var trips;

    $.ajax({
        type: "GET",
        url: '/Home/GetTrips',
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            trips = res;
            // console.log(res[0].Route);
            console.log(res[0]);

            for (var i = 0, len = res.length; i < len; i++) {
                console.log(res[i])
                var test = res[i].Id;
                var marker = new google.maps.Marker({
                    position: res[i].Route[0],
                    map: map,
                    draggable: false,
                    animation: google.maps.Animation.DROP,
                    customInfo: res[i]
                });

                marker.addListener("dblclick", function () {
                    document.location.href = '/Trip/Details/' + this.customInfo.Id
                });
            }
        },
        error: function (res) { console.log(res); }
    });
}