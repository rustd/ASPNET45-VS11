
var _map;
$(document).ready(function () {
    var map = document.getElementById("map");
    if (!map) return;

    _map = new Microsoft.Maps.Map(map,
    {
        credentials: "Ar5HA40Rl7FHpZrKWW-R5Utb4GyiJ-x_10q_iwevvv5VD8ONlO3QQpl3Tu0oXrXB"
    });
    
    
    if (!navigator.geolocation)
        alert("This browser doesn't support geolocation");
    else
        navigator.geolocation.getCurrentPosition(onPositionReady, onError);
});

function onPositionReady(position) {
    var location = new Microsoft.Maps.Location(position.coords.latitude,
            position.coords.longitude);
    _map.setView({ zoom: 18, center: location });
    var pin = new Microsoft.Maps.Pushpin(location);
    _map.entities.push(pin);
}

function onError(err) {
    switch (err.code) {
        case 0:
            alert("Unknown error");
            break;
        case 1:
            alert("The user said no!");
            break;
        case 2:
            alert("Location data unavailable");
            break;
        case 3:
            alert("Location request timed out");
            break;
    }
}