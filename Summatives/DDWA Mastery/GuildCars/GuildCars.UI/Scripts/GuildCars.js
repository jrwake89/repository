$(document).ready(function () {


    $('#search-form-new').submit(function (e) {
        searchNew();
        return false;
    });

    $('#search-form-used').submit(function (e) {
        searchUsed();
        return false;
    });

    $('#search-form-sales').submit(function (e) {
        searchSales();
        return false;
    });

    $('#search-form-admin').submit(function (e) {
        searchAdmin();
        return false;
    });

    $('#search-form-salesReport').submit(function (e) {
        searchSalesReport();
        return false;
    });


    $('#vehicle_MakeId').click(function () {

        var makeid = $('#vehicle_MakeId').val();

        $.ajax({
            url: '/api/ModelsbyMakes?makeId=' + makeid,
            type: 'GET',
            dataType: 'json',
            success: function (modelArray) {
                var options = '';
                $.each(modelArray, function (index, model) {
                    options += '<option value="' + model.ModelId + '">' + model.ModelName + '</option>';
                });
                $('#vehicle_ModelId').prop('disabled', false).html(options);
            }
        });
    });

    $('#formAddVehicle').validate({
        rules: {
            'vehicle.Year': {
                required: true,
                number: true
            },
            'vehicle.Mileage': {
                required: true,
                number: true
            },
            'vehicle.VinNum': {
                required: true,
            },
            'vehicle.MSRP': {
                required: true,
                number: true
            },
            'vehicle.SalesPrice': {
                required: true,
                number: true
            }
        }
    })

    $('#formEditVehicle').validate({
        rules: {
            'vehicle.Year': {
                required: true,
                number: true
            },
            'vehicle.Mileage': {
                required: true,
                number: true
            },
            'vehicle.VinNum': {
                required: true,
            },
            'vehicle.MSRP': {
                required: true,
                number: true
            },
            'vehicle.SalesPrice': {
                required: true,
                number: true
            }
        }
    })

    $('#formPurchase').validate({
        rules: {
            'Sale.Street1': {
                required: true,
            },
            'Sale.City': {
                required: true,
            },
            'Sale.ZipCode': {
                required: true,
                number: true
            },
            'Sale.PurchasePrice': {
                required: true,
                number: true
            },
            'Sale.BuyerName': {
            required: true,
            }
        }
    })

    $('#formContactUs').validate({
        rules: {
            'ContactName': {
                required: true,

            },
            'ContactMessage': {
                required: true,
            },
        }
    })


    function searchAdmin() {
        clearSearchTable();

        var params;

        params = 'maxPrice=' + $('#maxPrice-box').val() + '&minPrice=' + $('#minPrice-box').val() + '&maxYear=' + $('#maxYear-box').val() + '&minYear=' + $('#minYear-box').val() + '&search=' + $('#search-box').val()

        $.ajax({
            type: 'GET',
            url: 'http://localhost:50156/api/admin/vehicles?' + params,
            success: function (vehicleArray) {

                $('#search-table-header').show();
                $.each(vehicleArray, function (index, vehicle) {
                    var vehicleId = vehicle.VehicleId;
                    var makeName = vehicle.MakeName;
                    var modelName = vehicle.ModelName;
                    var colorType = vehicle.ColorType;
                    var transmitionType = vehicle.TransmitionType;
                    var interiorType = vehicle.InteriorType;
                    var mileage = vehicle.Mileage;
                    var vinNum = vehicle.VinNum;
                    var year = vehicle.Year;
                    var msrp = vehicle.MSRP;
                    var salesPrice = vehicle.SalesPrice;
                    var pictureFileName = vehicle.PictureFileName;
                    var bodyStyle = vehicle.BodyStyle;
                    var descrip = vehicle.Descrip;
                    var isNew = vehicle.IsNew;
                    var isUsed = vehicle.IsUsed;
                    var isFeatured = vehicle.IsFeatured;
                    var row = '<table id="SearchVehicleTable"><tbody id="searchVehicleRows">';
                    row += '<tr><td colspan="8"><strong>' + year + ' ' + makeName + ' ' + modelName + '</strong></td></tr>';
                    row += '<tr>';
                    row += '<td rowspan="4"><img src="/Images/' + vehicle.PictureFileName + '"></td>';
                    row += '<td class="bold-search-cell"><strong>Body Style:</strong></td>';
                    row += '<td>' + bodyStyle + '</td>';
                    row += '<td class="bold-search-cell"><strong>Interior:</strong></td>';
                    row += '<td>' + interiorType + '</td>';
                    row += '<td class="bold-search-cell"><strong>Sales Price:</strong></td>';
                    row += '<td>$' + salesPrice.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,') + '</td>';
                    row += '</tr>'

                    row += '<tr>';
                    row += '<td class="bold-search-cell"><strong>Trans:</strong></td>';
                    row += '<td>' + transmitionType + '</td>';
                    row += '<td class="bold-search-cell"><strong>Mileage:</strong></td>';
                    row += '<td>' + mileage.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + '</td>';
                    row += '<td class="bold-search-cell"><strong>MSRP:</strong></td>';
                    row += '<td>$' + msrp.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,') + '</td>';
                    row += '</tr>'

                    row += '<tr>';

                    row += '<td class="bold-search-cell"><strong>Color:</strong></td>';
                    row += '<td>' + colorType + '</td>';
                    row += '<td class="bold-search-cell"><strong>VIN #:</strong></td>';
                    row += '<td>' + vinNum + '</td>';
                    row += '<td></td>';
                    row += '<td><a href="http://localhost:50156/admin/editvehicle/' + vehicleId + '\" class="btn btn-sm btn-dark" role="button">Edit</a></td>'
                    row += '</tr>';
                    row += '</tbody></table>';



                    $('#SearchVehicleTable').append(row.toString());

                });
            },
            error: function () {
                alert('Error with your search.')
            }
        });
    };

    function searchNew() {
      clearSearchTable();

      var params;

      params = 'maxPrice=' + $('#maxPrice-box').val() + '&minPrice=' + $('#minPrice-box').val() + '&maxYear=' + $('#maxYear-box').val() + '&minYear=' + $('#minYear-box').val() + '&search=' + $('#search-box').val()

      $.ajax({
        type: 'GET',
        url: 'http://localhost:50156/api/inventory/new?' + params,
          success: function (vehicleArray) {

          $('#search-table-header').show();
          $.each(vehicleArray, function(index, vehicle) {
            var vehicleId = vehicle.VehicleId;
            var makeName = vehicle.MakeName;
            var modelName = vehicle.ModelName;
            var colorType = vehicle.ColorType;
            var transmitionType = vehicle.TransmitionType;
            var interiorType = vehicle.InteriorType;
            var mileage = vehicle.Mileage;
            var vinNum = vehicle.VinNum;
            var year = vehicle.Year;
            var msrp = vehicle.MSRP;
            var salesPrice = vehicle.SalesPrice;
            var pictureFileName = vehicle.PictureFileName;
            var bodyStyle = vehicle.BodyStyle;
            var descrip = vehicle.Descrip;
            var isNew = vehicle.IsNew;
            var isUsed = vehicle.IsUsed;
            var isFeatured = vehicle.IsFeatured;
            var row = '<table id="SearchVehicleTable"><tbody id="searchVehicleRows">';
                row += '<tr><td colspan="8"><strong>' + year + ' ' + makeName + ' ' + modelName + '</strong></td></tr>';
                row += '<tr>';
                row += '<td rowspan="4"><img src="/Images/' + vehicle.PictureFileName +'"></td>';
                row += '<td class="bold-search-cell"><strong>Body Style:</strong></td>';
                row += '<td>'+ bodyStyle + '</td>';
                row += '<td class="bold-search-cell"><strong>Interior:</strong></td>';
                row += '<td>' + interiorType + '</td>';
                row += '<td class="bold-search-cell"><strong>Sales Price:</strong></td>';
              row += '<td>$' + salesPrice.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,') + '</td>';
                row += '</tr>'

                row += '<tr>';
                row += '<td class="bold-search-cell"><strong>Trans:</strong></td>';
                row += '<td>'+ transmitionType + '</td>';
                row += '<td class="bold-search-cell"><strong>Mileage:</strong></td>';
              row += '<td>' + mileage.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",")  + '</td>';
                row += '<td class="bold-search-cell"><strong>MSRP:</strong></td>';
              row += '<td>$' + msrp.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,') + '</td>';
                row += '</tr>'

                row += '<tr>';

                row += '<td class="bold-search-cell"><strong>Color:</strong></td>';
                row += '<td>'+ colorType + '</td>';
                row += '<td class="bold-search-cell"><strong>VIN #:</strong></td>';
                row += '<td>' + vinNum + '</td>';
                row += '<td></td>';
                row += '<td><button type="button" onclick="location.href=\'/inventory/details/' + vehicleId + '\'" class="btn btn-sm btn-dark">Details</button></td>'
                row += '</tr>';
                row += '</tbody></table>';



            $('#SearchVehicleTable').append(row.toString());

          });
        },
          error: function () {
              alert('Error with your search.')
          }
      });
    };

    function searchUsed() {
      clearSearchTable();

      var params;

      params = 'maxPrice=' + $('#maxPrice-box').val() + '&minPrice=' + $('#minPrice-box').val() + '&maxYear=' + $('#maxYear-box').val() + '&minYear=' + $('#minYear-box').val() + '&search=' + $('#search-box').val()

      $.ajax({
        type: 'GET',
        url: 'http://localhost:50156/api/inventory/used?' + params,
          success: function (vehicleArray) {

          $('#search-table-header').show();
          $.each(vehicleArray, function(index, vehicle) {
            var vehicleId = vehicle.VehicleId;
            var makeName = vehicle.MakeName;
            var modelName = vehicle.ModelName;
            var colorType = vehicle.ColorType;
            var transmitionType = vehicle.TransmitionType;
            var interiorType = vehicle.InteriorType;
            var mileage = vehicle.Mileage;
            var vinNum = vehicle.VinNum;
            var year = vehicle.Year;
            var msrp = vehicle.MSRP;
            var salesPrice = vehicle.SalesPrice;
            var pictureFileName = vehicle.PictureFileName;
            var bodyStyle = vehicle.BodyStyle;
            var descrip = vehicle.Descrip;
            var isNew = vehicle.IsNew;
            var isUsed = vehicle.IsUsed;
            var isFeatured = vehicle.IsFeatured;
            var row = '<table id="SearchVehicleTable"><tbody id="searchVehicleRows">';
                row += '<tr><td colspan="8"><strong>' + year + ' ' + makeName + ' ' + modelName + '</strong></td></tr>';
                row += '<tr>';
                row += '<td rowspan="4"><img src="/Images/' + vehicle.PictureFileName +'"></td>';
                row += '<td class="bold-search-cell"><strong>Body Style:</strong></td>';
                row += '<td>'+ bodyStyle + '</td>';
                row += '<td class="bold-search-cell"><strong>Interior:</strong></td>';
                row += '<td>' + interiorType + '</td>';
                row += '<td class="bold-search-cell"><strong>Sales Price:</strong></td>';
                row += '<td>$' + salesPrice.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,') + '</td>';
                row += '</tr>'

                row += '<tr>';
                row += '<td class="bold-search-cell"><strong>Trans:</strong></td>';
                row += '<td>'+ transmitionType + '</td>';
                row += '<td class="bold-search-cell"><strong>Mileage:</strong></td>';
                row += '<td>' + mileage.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + '</td>';
                row += '<td class="bold-search-cell"><strong>MSRP:</strong></td>';
                row += '<td>$' + msrp.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,') + '</td>';
                row += '</tr>'

                row += '<tr>';
                row += '<td class="bold-search-cell"><strong>Color:</strong></td>';
                row += '<td>'+ colorType + '</td>';
                row += '<td class="bold-search-cell"><strong>VIN #:</strong></td>';
                row += '<td>' + vinNum + '</td>';
                row += '<td></td>';
                row += '<td><button type="button" onclick="location.href=\'/inventory/details/' + vehicleId + '\'" class="btn btn-sm btn-dark">Details</button></td>'
                row += '</tr>';
                row += '</tbody></table>';



            $('#SearchVehicleTable').append(row.toString());

          });
        },
          error: function () {
              alert('Error with your search.')
          }
      });
    };

    function searchSales() {
     clearSalesTable();

      var params;

      params = 'maxPrice=' + $('#maxPrice-box').val() + '&minPrice=' + $('#minPrice-box').val() + '&maxYear=' + $('#maxYear-box').val() + '&minYear=' + $('#minYear-box').val() + '&search=' + $('#search-box').val()

      $.ajax({
        type: 'GET',
        url: 'http://localhost:50156/api/sales/index?' + params,
          success: function (vehicleArray) {
          $('#search-table-header').show();
          $.each(vehicleArray, function(index, vehicle) {
            var vehicleId = vehicle.VehicleId;
            var makeName = vehicle.MakeName;
            var modelName = vehicle.ModelName;
            var colorType = vehicle.ColorType;
            var transmitionType = vehicle.TransmitionType;
            var interiorType = vehicle.InteriorType;
            var mileage = vehicle.Mileage;
            var vinNum = vehicle.VinNum;
            var year = vehicle.Year;
            var msrp = vehicle.MSRP;
            var salesPrice = vehicle.SalesPrice;
            var pictureFileName = vehicle.PictureFileName;
            var bodyStyle = vehicle.BodyStyle;
            var descrip = vehicle.Descrip;
            var isNew = vehicle.IsNew;
            var isUsed = vehicle.IsUsed;
            var isFeatured = vehicle.IsFeatured;
            var row = '<table id="SalesTable"><tbody>';
                row += '<tr><td colspan="8"><strong>' + year + ' ' + makeName + ' ' + modelName + '</strong></td></tr>';
                row += '<tr>';
                row += '<td class="img-center" rowspan="4"><img src="/Images/' + vehicle.PictureFileName +'"></td>';
                row += '<td class="bold-search-cell"><strong>Body Style:</strong></td>';
                row += '<td>'+ bodyStyle + '</td>';
                row += '<td class="bold-search-cell"><strong>Interior:</strong></td>';
                row += '<td>' + interiorType + '</td>';
                row += '<td class="bold-search-cell"><strong>Sales Price:</strong></td>';
                row += '<td>$' + salesPrice.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,') + '</td>';
                row += '</tr>'

                row += '<tr>';
                row += '<td class="bold-search-cell"><strong>Trans:</strong></td>';
                row += '<td>'+ transmitionType + '</td>';
                row += '<td class="bold-search-cell"><strong>Mileage:</strong></td>';
                row += '<td>' + mileage.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",") + '</td>';
                row += '<td class="bold-search-cell"><strong>MSRP:</strong></td>';
                row += '<td>$' + msrp.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,') + '</td>';
                row += '<td></td>';
                row += '</tr>'

                row += '<tr>';
                row += '<td class="bold-search-cell"><strong>Color:</strong></td>';
                row += '<td>'+ colorType + '</td>';
                row += '<td class="bold-search-cell"><strong>VIN #:</strong></td>';
                row += '<td>' + vinNum + '</td>';
                row += '<td></td>';
              row += '<td><button type="button" onclick="location.href=\'/sales/purchase/' + vehicleId + '\'" class="btn btn-sm btn-dark">Purchase</button></td>';
                row += '</tr>';
                row += '</tbody></table>';

            $('#sales-table-div').append(row.toString());

          });
        },
          error: function () {
              alert('Error with your search.')
          }
      });
    };

    function searchSalesReport() {
        clearSalesReportTable();

        var params;

        params = 'userName=' + $('#username-salesreport').val() + '&fromDate=' + $('#from-date-input').val() + '&toDate=' + $('#to-date-input').val()

        $.ajax({
            type: 'GET',
            url: 'http://localhost:50156/api/reports/sales?' + params,
            success: function (salesArray) {
                $('#search-table-header').show();

                $.each(salesArray, function (index, sales) {
                    var userName = sales.FirstName + ' ' + sales.LastName;
                    var totalSales = sales.TotalSales;
                    var totalVehicle = sales.TotalVehicles;
                   
                    var row = '<tr class="salesreport-content-rows">';
                    row += '<td>' + userName + '</td>';
                    row += '<td>$' + totalSales.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,') + '</td > ';
                    row += '<td>' + totalVehicle + '</td>';  
                    row += '</tr>'

                    $('#ReportSalesTable').append(row.toString());

                });
            },
            error: function () {
                alert('Error with your search.')
            }
        });
    };

    $('#search-table-header').hide();
});



    $('#special-link').click(function(event){
    $('#special-div').empty();
    var haveValidationErrors = checkAndDisplayValidationErrors($("#search-form-specials").find('input'));

    if (haveValidationErrors) {
      return false;
    }

    $.ajax({
      type: 'GET',
      url: 'http://localhost:50156/api/home/specials?',
      success: function(specialArray) {
        $.each(specialArray, function(index, special) {
          var specialId = special.SpecialId;
          var specialTitle = special.SpecialTitle;
          var specialDesc = special.Descrip;
          var row = '<table id="SpecialTable"><tbody id="specialRows">';
              row += '<td rowspan="4">$</td>';
              row += '<td class="bold-search-cell"><strong>Special Title</strong></td>';
              row += '<tr>';
              row += '<td colspan="7">'+ specialDesc + '</td>';
              row += '</tr>';


          $('#SpecialTable').append(row.toString());

        });
      },
      error: function() {
        $("#errorMessages")
            .append($('<li>')
            .attr({class: 'list-group-item list-group-item-danger'})
            .text("Error calling web service. Please try again later."));
      }
    });
  });

    $('#details-button').click(function(event){

  clearVehicleDetailsTable();

  var haveValidationErrors = checkAndDisplayValidationErrors($("#VehicleDetailsTable").find('input'));

  if (haveValidationErrors) {
    return false;
  }
  var params;

  $.ajax({
    type: 'GET',
    url: 'http://localhost:50156/api/inventory/details/{vehicleId}',
    success: function(vehicleArray) {
      $.each(vehicleArray, function(index, vehicle) {
        var title = vehicle.VehicleId;
        var makeName = vehicle.MakeName;
        var modelName = vehicle.ModelName;
        var colorType = vehicle.ColorType;
        var transmitionType = vehicle.TransmitionType;
        var interiorType = vehicle.InteriorType;
        var mileage = vehicle.Mileage;
        var vinNum = vehicle.VinNum;
        var year = vehicle.Year;
        var msrp = vehicle.MSRP;
        var salesPrice = vehicle.SalesPrice;
        var pictureFileName = vehicle.PictureFileName;
        var bodyStyle = vehicle.BodyStyle;
        var descrip = vehicle.Descrip;
        var isNew = vehicle.IsNew;
        var isUsed = vehicle.IsUsed;
        var isFeatured = vehicle.IsFeatured;
        var row = '<tr><td colspan="8">' + year + ' ' + makeName + ' ' + modelName + '</td></tr>';
            row += '<tr>';
            row += '<td rowspan="4"><img src="/Images/' + vehicle.PictureFileName +'"></td>';
            row += '<td class="bold-search-cell"><strong>Body Style:</strong></td>';
            row += '<td>'+ bodyStyle + '</td>';
            row += '<td class="bold-search-cell"><strong>Interior:</strong></td>';
            row += '<td>' + interiorType + '</td>';
            row += '<td class="bold-search-cell"><strong>Sales Price:</strong></td>';
            row += '<td>' + salesPrice + '</td>';
            row += '</tr>'

            row += '<tr>';
            row += '<td></td>';
            row += '<td class="bold-search-cell"><strong>Trans:</strong></td>';
            row += '<td>'+ transmitionType + '</td>';
            row += '<td class="bold-search-cell"><strong>Mileage:</strong></td>';
            row += '<td>' + mileage + '</td>';
            row += '<td class="bold-search-cell"><strong>MSRP:</strong></td>';
            row += '<td>' + msrp + '</td>';
            row += '</tr>'

            row += '<tr>';
            row += '<td></td>';
            row += '<td class="bold-search-cell"><strong>Color:</strong></td>';
            row += '<td>'+ colorType + '</td>';
            row += '<td class="bold-search-cell"><strong>VIN #:</strong></td>';
            row += '<td>' + vinNum + '</td>';
            row += '<td></td>';
            row += '<td></td>'
            row += '</tr>';

            row += '<tr>';
            row += "</tr>";

            row += '<tr>';
            row += '<td></td>';
            row += '<td colspan="6" class="bold-search-cell"><strong>Description:</strong></td>';
            row += '<td>'+ descrip + '</td>';
            row += '<td><button id="contact-button" type="submit" class="btn btn-primary"><a href="http://localhost:50156/inventory/'+'"Contact Us</button></td>'
            row += '</tr>';

            row += '<tr>';
            row += '<td></td>';
            row += '<td></td>';
            row += '<td></td>';
            row += '<td></td>';
            row += '<td></td>';
            row += '<td></td>';
            row += '<td><button id="contact-button" type="submit" class="btn btn-primary"><a href="http://localhost:50156/inventory/'+'"Contact Us</button></td>'
            row += '</tr>';




        $('#SearchVehicleTable').append(row.toString());
        $('#search-category').val('');
        $('#search-term').val('');
        $('#contentRows').hide();
        $('#searchContentRows').show();
        $('#search-back-button').show();

      });
    },
    error: function() {
      $("#errorMessages")
          .append($('<li>')
          .attr({class: 'list-group-item list-group-item-danger'})
          .text("Error calling web service. Please try again later."));
    }
  });
});

function clearSearchTable() {
  $("#SearchVehicleTable").empty();
}

function clearSalesTable() {
    $('#sales-table-div').empty();
}

function clearSalesReportTable() {
    $(".salesreport-content-rows").empty();
}

function clearSpecialTable() {
  $("#special-div").empty();
}

function clearVehicleDetailsTable() {
  $("#VehicleDetailsTable").empty();
}
