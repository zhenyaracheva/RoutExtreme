//(function () {
var map;

function initMap() {

    var styledMap,
        mapOptions,
        marker,
        styles,
        route = [];

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

    styledMap = new google.maps.StyledMapType(styles, { name: "Styled Map" });

    mapOptions = {
        zoom: 7,
        center: new google.maps.LatLng(42.6252706, 25.3785853),
        mapTypeControlOptions: {
            mapTypeIds: [google.maps.MapTypeId.ROADMAP, 'map_style']
        }
    };

    map = new google.maps.Map(document.getElementById('map'),
     mapOptions);

    map.mapTypes.set('map_style', styledMap);
    map.setMapTypeId('map_style');

    marker = new google.maps.Marker({
        position: { lat: 42.6252706, lng: 25.3785853 },
        map: map,
        title: 'Hello World!'
    });

    google.maps.event.addListener(map, 'click', function (e) {
        placeMarker(e.latLng, map);
    });

    function placeMarker(position, map) {
        var marker = new google.maps.Marker({
            position: position,
            map: map
        });

        route
        //console.log(marker);
        route.push(marker.position);
        console.log(route);
        $('#routePoints').val(route.toString());
        map.panTo(position);
    }
}
//}())