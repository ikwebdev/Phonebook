$("#edit_new").click(function (event) {

    var data = {
        "Id": $(".ajaxeble > #Id").val(),
        "FirstName": $(".ajaxeble > #FirstName").val(),
        "LastName": $(".ajaxeble > #LastName").val(),
        "Age": $(".ajaxeble > #Age").val(),
    };
    var phones = [];

    $.each($(".phone_group"), function () {
        var current = $(this).find("input");
        var extend = {
            "Id": current[0].value ? current[0].value : null,
            "Person_Id": current[1].value ? current[1].value : null,
            "Mobile": current[2].value,
            "Type": current[3].value,
        };
        phones.push(extend);

    })
    $.extend(data,
        {
            "Phones": phones
        }
    );

    var addresses = [];

    $.each($(".address_group"), function () {
        var current = $(this).find("input");
        var extend = {
            "Id": current[0].value,
            "House": current[1].value,
            "Steeet_Id": current[2].value ? current[2].value : null,
            "Longtitude": current[9].value,
            "Latitude": current[8].value,
            "street": {
                "Id": current[2].value ? current[2].value : null,
                "city_Id": current[4].value ? current[4].value : null,
                "street": current[3].value,
                "city": {
                    "Id": current[4].value ? current[4].value : null,
                    "country_Id": current[6].value ? current[6].value : null,
                    "city": current[5].value,
                    "country": {
                        "Id": current[6].value ? current[6].value : null,
                        "country": current[7].value,
                    }
                }
            }
        };
        addresses.push(extend);
    })

    data.Addresses = addresses;


    console.log(data);
    $.ajax({
        type: 'POST',
        data: data,
        url: "/Person/EditPerson/",
        success: function (data) {
            window.location.href = "/Person/AllPersons";
        }
    });
});
$("#add").click(function () {
    var el = " <div class=\"phone_group col-md-10\"><br />  <input type=\"hidden\" /> <input type=\"hidden\"/><label class=\"control-label col-md-2\">Phone</label><input type=\"text\" name=\"phone\" class=\"form-control\" /> <br /> <label class=\"control-label col-md-2\">Type</label><input type=\"text\" name=\"type\" class=\"form-control\" /></div>";

    $("#phones").append(el);
});

$("#adadd").click(function () {
    var el = '<div class="address_group form-inline col-md-10">' +
                 '<label class="control-label col-md-2">House</label>' +
                 '<input type="hidden"/>' +
                 '<input type="text" name="house" class="form-control" />' +
                 '<br />' +
                '<input type="hidden" value= />' +
                '<label class="control-label col-md-2">Street</label>' +
                '<input type="text" name="street" class="form-control"/>' +
                '<br />' +
                ' <input type="hidden" />' +
                '<label class="control-label col-md-2">City</label>' +
                '  <input type="text" name="city" class="form-control" />' +
                '<br />' +
                '    <input type="hidden" />' +
                '  <label class="control-label col-md-2">Country</label>' +
                '       <input type="text" name="city" class="form-control" />' +
                ' <br />' +
                ' <input type="text" name="latitude" class=""  />' +
                '      <input type="text" name="city" class=""/>' +
                ' </div>';

    $("#addresses").append(el);
});