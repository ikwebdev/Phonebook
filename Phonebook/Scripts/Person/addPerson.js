var geocoder = new google.maps.Geocoder();
var map;
var markers = [];
//initialize map
function initMap() {
    var pos = { lat: -34.397, lng: 150.644 };
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            pos = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };
            map.setCenter(pos);
        }, function () {
            handleLocationError(true, infoWindow, map.getCenter());
        });
    } else {
        handleLocationError(false, infoWindow, map.getCenter());
    }

    map = new google.maps.Map(document.getElementById('googleMap'), {
        zoom: 17,
        center: pos
    });

    document.getElementById('submit').addEventListener('click', function () {
        geocodeAddress(geocoder, map);
    });

    google.maps.event.addListener(map, 'click', function (event) {
        addMarker(event.latLng, map);
    });
}

function addMarker(location, map) {
    // Add the marker at the clicked location, and add the next-available label
    // from the array of alphabetical characters.
    var marker = new google.maps.Marker({
        position: location,
        label: "",
        map: map
    });

    markers.push(marker);

    geocoder.geocode({ 'location': location }, function (results, status) {
        if (status === google.maps.GeocoderStatus.OK) {
            //   resultsMap.setCenter(results[0].geometry.location);
            addAddress(results[0].address_components);
            //add addresrese
        } else {
            alert('Geocode was not successful for the following reason: ' + status);
        }
    });
}



function geocodeAddress(geocoder, resultsMap) {
    var addresses_for_map = [];
    var addresses = [];

    $.each($(".address_group"), function () {
        var current = $(this).find("input");

        var add = "";
        if (current[3].value) {
            add += current[3].value + ",";
        }
        if (current[2].value) {
            add += current[2].value + ",";
        }
        if (current[1].value) {
            add += current[1].value + ",";
        }
        if (current[0].value) {
            add += current[0].value;
        }
        addresses_for_map.push(add);
        var extend = {
            "House": current[0].value,
            "street": {
                "street": current[1].value,
                "city": {
                    "city": current[2].value,
                    "country": {
                        "country": current[3].value,
                    }
                }
            }
        };
        addresses.push(extend);
    });

    setMapOnAll(null);
    markers = [];

    addresses_for_map.forEach(function (item, i) {
        geocoder.geocode({ 'address': item }, function (results, status) {
            if (status === google.maps.GeocoderStatus.OK) {
                resultsMap.setCenter(results[0].geometry.location);
                var marker = new google.maps.Marker({
                    map: resultsMap,
                    position: results[0].geometry.location
                });

                markers.push(marker);

                addresses[i].Latitude = results[0].geometry.location.lat().toString();
                addresses[i].Longtitude = results[0].geometry.location.lng().toString();
            } else {
                alert('Geocode was not successful for the following reason: ' + status);
            }
        });
    });
    return addresses;
}
google.maps.event.addDomListener(window, 'load', initMap);

function setMapOnAll(map) {
    for (var i = 0; i < markers.length; i++) {
        markers[i].setMap(map);
    }
}

$("#create_new").click(function (event) {

    var data = {
        "FirstName": $("#FirstName").val(),
        "LastName": $("#LastName").val(),
        "Age": $("#Age").val(),
    };
    var phones = [];

    $.each($(".phone_group"), function () {
        var current = $(this).find("input");
        var extend = {
            "Mobile": current[0].value,
            "Type": current[1].value,
        };
        phones.push(extend);
    })

    data.Phones = phones;

    data.Addresses = geocodeAddress(geocoder, map);

    console.log(data);
    setTimeout(function () {
        $.ajax({
            type: 'POST',
            data: data,
            url: "/Person/AddPerson/",
            success: function (data) {
                alert("HaslQ!");
            }
        });
    }, 3000);

});

$("#add").click(function () {
    var el = " <div class=\"phone_group form-inline col-md-10\"><br /><label class=\"control-label col-md-2\">Phone</label><input type=\"text\" name=\"phone\" class=\"form-control\" /> <br /> <label class=\"control-label col-md-2\">Type</label><input type=\"text\" name=\"type\" class=\"form-control\" /></div>";
    $("#phones").append(el);
});

$("#adadd").click(function () {
    var el = ' <div class="address_group form-inline col-md-10"><label class="control-label col-md-2">House</label><input type="text" name="house" class="form-control" /><br /><label class="control-label col-md-2">Street</label><input type="text" name="street" class="form-control" /> <br /><label class="control-label col-md-2">City</label><input type="text" name="city" class="form-control" /><br /><label class="control-label col-md-2">Country</label><input type="text" name="city" class="form-control" /></div>';

    $("#addresses").append(el);
});

function addAddress(address_components) {
    var el = ' <div class="address_group form-inline col-md-10">' +
        '<label class="control-label col-md-2">House</label>' +
        '<input type="text" name="house" class="form-control" value="' + address_components[0].long_name + '"/><br />' +
        '<label class="control-label col-md-2">Street</label>' +
        '<input type="text" name="street" class="form-control" value="' + address_components[1].long_name + '"/> <br />' +
        '<label class="control-label col-md-2">City</label>' +
        '<input type="text" name="city" class="form-control" value="' + address_components[3].long_name + '" /><br />' +
        '<label class="control-label col-md-2">Country</label>' +
        '<input type="text" name="city" class="form-control" value="' + address_components[6].long_name + '"/></div>';
    $("#addresses").append(el);
}