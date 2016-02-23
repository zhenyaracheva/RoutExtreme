//(function () {
function initMap() {
    var styledMap,
        styles,
        mapOptions;

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
}];

    styledMap = new google.maps.StyledMapType(styles, { name: "RoutExtreme" });

    var url = document.URL;
    var id = url.substring(url.lastIndexOf('/') + 1);
    var trips;

    $.ajax({
        type: "GET",
        url: '/Trip/GetTripRoute/' + id,
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            trips = res;

            console.log(trips)
            var map = new google.maps.Map(document.getElementById('map'), {
                zoom: 10,
                center: { lat: res[0].lat, lng: res[0].lng },
                mapTypeControlOptions: {
                    mapTypeIds: [google.maps.MapTypeId.ROADMAP, 'map_style']
                }
            });

            var flightPath = new google.maps.Polyline({
                path: trips,
                geodesic: true,
                strokeColor: '#FF0000',
                strokeOpacity: 1.0,
                strokeWeight: 2
            });

            map.mapTypes.set('map_style', styledMap);
            flightPath.setMap(map);

        },
        error: function (res) { console.log(res); }
    });

}
//}())