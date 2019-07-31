$(document).ready(function () {

  loadItems();


});

$('#make-purchase').click(function(event){

  purchaseItem();
});

$('#change-return').click(function(event){
    var amount = Number($('#amount').val());

    var quarter = Math.floor(amount / 0.25);
    amount = amount - quarter*(0.25);

    var dime = Math.floor(amount / 0.10);
    amount = amount - dime*(0.10);

    var nickel = Math.floor(amount / 0.05);
    amount = amount - nickel*(0.05);

    var penny = Math.floor(amount);

    var change;

    getChange(quarter, dime, nickel, penny);
  });

$('#add-dollar-button').click(function(event){

  if($('#amountMessage').val() != '' || $('#change').val() != '')
  {
    if($('#amountMessage').val() == 'SOLD OUT!!!' || $('#change').val() != '')
    {
      clearMessages();
    }
    $('#change-return').show();
  }

  amount = Number($('#amount').val());
  amount = amount + 1.00;
  $('#amount').val(amount);
});

$('#add-quarter-button').click(function(event){
  if($('#amountMessage').val() != '' || $('#change').val() != '')
  {
    if($('#amountMessage').val() == 'SOLD OUT!!!' || $('#change').val() != '')
    {
      clearMessages();
    }
    $('#change-return').show();
  }
  amount = Number($('#amount').val());
  amount = amount + 0.25;
  $('#amount').val(amount);
});

$('#add-dime-button').click(function(event){
  if($('#amountMessage').val() != ''  || $('#change').val() != '')
  {
    if($('#amountMessage').val() == 'SOLD OUT!!!' || $('#change').val() != '')
    {
      clearMessages();
    }
    $('#change-return').show();
  }
  amount = Number($('#amount').val());
  amount = amount + 0.10;
  $('#amount').val(amount);
});

$('#add-nickel-button').click(function(event){
  if($('#amountMessage').val() != '' || $('#change').val() != '')
  {
    if($('#amountMessage').val() == 'SOLD OUT!!!' || $('#change').val() != '')
    {
      clearMessages();
    }
    $('#change-return').show();
  }
  amount = Number($('#amount').val());
  amount = amount + 0.05;
  $('#amount').val(amount);
});

function purchaseItem()
{
  var itemNum = $('#item').val();
  var amount = Number($('#amount').val());

  $.ajax({
    type: 'GET',
    url: 'http://localhost:8080/money/' + amount +'/item/' + itemNum,
    success: function(changeArray){
        var quarter = changeArray.quarters;
        var dime = changeArray.dimes;
        var nickel = changeArray.nickels;
        var penny = changeArray.pennies;

        var moneyBack = quarter, dime, nickel, penny;
        $('#amountMessage').val('Thank You!!!');
        getChange(quarter, dime, nickel, penny);

        clearItems();
        amount = Number($('#amount').val());
        $('#amount').val(amount);
        loadItems();
      },
      statusCode: {
                    422: function(jqXHR) {
                      var message = jqXHR.responseJSON.message
                      $('#amountMessage').val(message);
                    }
                  },
      error: function(message) {
        if(status == "424" || message == "Please deposit: <amount short>")
        {
          $('#amountMessage').val(message);
        }
        else {
          $('#errorMessages')
                  .append($('<li>')
                  .attr({class: 'list-group-item list-group-item-danger'})
                  .text("Error calling web service. Please try again later"));
        }
      }
    });
  }

  function getChange(quarter, dime, nickel, penny)
  {
    var change = '';

    if(quarter > 0)
    {
      if(quarter == 1)
      {
        change = change + quarter + ' Quarter ';
      }
      else {
        change = change + quarter + ' Quarters ';
      }

    }
    if(dime > 0)
    {
      if(dime == 1)
      {
        change = change + dime + ' Dime ';
      }
      else {
        change = change + dime + ' Dimes ';
      }
    }
    if(nickel > 0)
    {
      if(nickel == 1)
      {
        change = change + nickel + ' Nickel ';
      }
      else {
        change = change + nickel + ' Nickels ';
      }
    }
    if(penny > 0)
    {
        if(penny == 1)
        {
          change = change + penny + ' Penny ';
        }
        else {
          change = change + penny + ' Pennies ';
        }
    }

    $('#change').val(change);
    $('#change-return').hide();
  }
function clearItems()
{
  $('#tableThree').empty();
  $('#tableTwo').empty();
  $('#tableOne').empty();
}

function clearMessages()
{
    $('#amountMessage').val('');
    $('#change').val('');
    $('#item').val('');
    $('#change').val('');
    $('#amount').val(0.00);
}

function loadItems() {
  $.ajax({
    type: 'GET',
    url: 'http://localhost:8080/items',
    success: function(itemArray){
      var items = '<div class="form-group">';
      $.each(itemArray, function(index, item){
          var id = item.id;
          var name = item.name;
          var price = item.price;
          var quantity = item.quantity;

          items = '<td id="items"><button type="button" class="button" id="' + id + '"><span class="pull-left">' + id +'</span><br><span>' + name + '</span><br><span id="price' + id + '">$' + price + '</span><br><br>Quantity Left: ' + quantity +'</button></td></div>';
          if(id > 3)
          {
            if(id > 6 )
            {
                $('#tableThree').append(items);
            }
            else
            {
              $('#tableTwo').append(items);
            }
          }
          else{
            $('#tableOne').append(items);
          }

          //click to add item//
          $('#1').click(function (event) {

            document.getElementById('item').value = 1;
          });

          $('#2').click(function (event) {

            document.getElementById('item').value = 2;
          });

          $('#3').click(function (event) {

            document.getElementById('item').value = 3;
          });

          $('#4').click(function (event) {

            document.getElementById('item').value = 4;
          });

          $('#5').click(function (event) {

            document.getElementById('item').value = 5;
          });

          $('#6').click(function (event) {

            document.getElementById('item').value = 6;
          });

          $('#7').click(function (event) {

            document.getElementById('item').value = 7;
          });

          $('#8').click(function (event) {

            document.getElementById('item').value = 8;
          });

          $('#9').click(function (event) {

            document.getElementById('item').value = 9;
          });
      });
    },
    error: function()
    {
      $('#errorMessages')
              .append($('<li>')
              .attr({class: 'list-group-item list-group-item-danger'})
              .text("Error calling web service. Please try again later"));
    }

  })
}
