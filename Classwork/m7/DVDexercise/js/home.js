$(document).ready(function () {
  loaddvds();

  $('#createDVDBtn').click(function (event){

      var haveValidationErrors = checkAndDisplayValidationErrors($('#createdvdform').find('input'));

      if(haveValidationErrors) {
        return false;
      }

      $.ajax({
        type: 'POST',
        url: 'http://localhost:8080/dvd',
        data: JSON.stringify({
          title: $('#create-title').val(),
          year: $('#create-year').val(),
          director: $('create-director').val(),
          rating: $('create-rating').val(),
          notes: $('create-notes').val()
        }),
        headers: {
           'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function(){
          $('#errorMessages').empty();

          title: $('#create-title').val('');
          year: $('#create-year').val('');
          director: $('create-director').val('');
          rating: $('create-rating').val('');
          notes: $('create-notes').val('');
          loaddvds();
          hideCreateForm();
        },
        error: function(){
          $('#errorMessages')
              .append($('<li>')
              .attr({class: 'list-group-item list-group-item-danger'})
              .text('Error calling web service.  Please try again later'));
        }
      });

    });

    $('#edit-button').click(function (event){

      var haveValidationErrors = checkAndDisplayValidationErrors($('#editdvdform').find('input'));

      if(haveValidationErrors) {
        return false;
      }

      $.ajax({
        type: 'PUT',
        url: 'http://localhost:8080/dvd/' + $('#edit-dvdId').val(),
        data: JSON.stringify({
          dvdId: $('#edit-dvdId').val(),
          title: $('#edit-title').val(),
          realeaseYear: $('#edit-year').val(),
          director: $('#edit-director').val(),
          rating: $('#edit-rating').val(),
          notes: $('#edit-notes').val()
        }),
        headers:{
          'Accept': 'application/json',
          'Content-Type': 'application/json'
        },
        'dataType': 'json',
        success: function(){
            //clear the errors//
            $('#errorMessages').empty();
            hideEditForm();
            loaddvds();
        },
        error: function(){
          $('#errorMessages')
              .append($('<li>')
              .attr({class: 'list-group-item list-group-item-danger'})
              .text('Error calling web service.  Please try again later'));
        }
      });
    });

});

function loaddvds() {
    // we need to clear the previous content so we don't append to it
    clearContactTable();
    // grab the the tbody element that will hold the rows of contact information
    var contentRows = $('#contentRows');
    $.ajax ({
        type: 'GET',
        url: 'http://localhost:8080/dvds',
        success: function (data, status) {
            $.each(data, function (index, dvd) {
                var title = dvd.title;
                var year = dvd.realeaseYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var id = dvd.dvdId;
                var row = '<tr>';
                    row += '<td>' + title + '</td>';
                    row += '<td>' + year + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><a onclick="showEditForm('+ id +')">Edit</a></td>';
                    row += '<td><a onclick="deleteDVD('+ id +')">Delete</a></td>';
                    row += '</tr>';
                contentRows.append(row);
            });
        },
        error: function() {
            $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service.  Please try again later.'));
        }
    });
}


function showCreateForm() {
    // clear errorMessages
    $('#errorMessages').empty();

    $('#create-title').val('');
    $('#create-director').val('');
    $('#create-year').val('');
    $('#create-rating').val('');
    $('#create-title').val('');
    $('#create-notes').val('');

    $('#dvdTable').hide();
    $('#createdvdFormDiv').show();
}

function hideCreateForm() {
  // clear errorMessages
  $('#errorMessages').empty();



  $('#createdvdFormDiv').hide();
  $('#dvdTable').show();
}

function showEditForm(dvdId) {
    // clear errorMessages
    $('#errorMessages').empty();

      $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/dvd/' + dvdId,
        success: function(data, status) {
          $('#edit-title').val(data.title);
          $('#edit-director').val(data.director);
          $('#edit-year').val(data.realeaseYear);
          $('#edit-rating').val(data.rating);
          $('#edit-notes').val(data.notes);
          $('#edit-dvdId').val(data.dvdId);
        },
        error: function(data, status) {
          $('#errorMessages')
            .append(('<li>')
            .attr({class: 'list-group-item list-group-item-danger'})
            .text('Error calling Web Service.  Please try again later.'));
        }
      });

    $('#dvdTable').hide();
    $('#editdvdFormDiv').show();
}

function checkAndDisplayValidationErrors(input) {
    // clear displayed error message if there are any
    $('#errorMessages').empty();
    // check for HTML5 validation errors and process/display appropriately
    // a place to hold error messages
    var errorMessages = [];

    // loop through each input and check for validation errors
    input.each(function() {
        // Use the HTML5 validation API to find the validation errors
        if(!this.validity.valid)
        {
            var errorField = $('label[for='+this.id+']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    // put any error messages in the errorMessages div
    if (errorMessages.length > 0){
        $.each(errorMessages,function(index,message){
            $('#errorMessages').append($('<li>').attr({class: 'list-group-item list-group-item-danger'}).text(message));
        });
        // return true, indicating that there were errors
        return true;
    } else {
        // return false, indicating that there were no errors
        return false;
    }
}

function hideEditForm() {
  // clear errorMessages
  $('#errorMessages').empty();

  $('#edit-title').val('');
  $('#edit-director').val('');
  $('#edit-year').val('');
  $('#edit-rating').val('');
  $('#edit-title').val('');
  $('#edit-notes').val('');
  $('#edit-dvdId').val('');

  $('#editdvdFormDiv').hide();
  $('#dvdTable').show();
}

function clearContactTable() {
    $('#contentRows').empty();
}

function deleteDVD(dvdId) {
  $.ajax({
    type: 'DELETE',
    url: 'http://localhost:8080/dvd/' + dvdId,
    success: function() {
      confirm('Are you sure that you want to delete this DVD?');
      loaddvds();
    }
  });
}
