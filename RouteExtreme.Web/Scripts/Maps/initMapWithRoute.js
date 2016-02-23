var map;

function initMap() {
    var styledMap,
        mapOptions;

    mapOptions = {
        zoom: 7,
        center: new google.maps.LatLng(42.6252706, 25.3785853),
        mapTypeControlOptions: {
            mapTypeIds: [google.maps.MapTypeId.ROADMAP, 'map_style']
        }
    };

    var url = document.URL;
    var id = url.substring(url.lastIndexOf('/') + 1);
    var trips;

    $.ajax({
        type: "GET",
        url: '@Url.Action("GetTripRoute", "Trip")' + '/' + id,
        contentType: "application/json; charset=utf-8",
        success: function (res) {
            trips = res;
        },
        error: function (res) { console.log(res); }
    });

    var flightPath = new google.maps.Polyline({
        path: trips,
        geodesic: true,
        strokeColor: '#FF0000',
        strokeOpacity: 1.0,
        strokeWeight: 2
    });

    flightPath.setMap(map);
}