$(document).ready(function () {
    $('#akronInfoDiv').hide();
    $('#minneapolisInfoDiv').hide();
    $('#louisvilleInfoDiv').hide();


    $('#mainButton').on('click', function () {
        $('#mainInfoDiv').show();
        $('#akronInfoDiv').hide();
        $('#minneapolisInfoDiv').hide();
        $('#louisvilleInfoDiv').hide();

        $('#akronWeatherButton').on('click', function () {
            $('#akronWeather').toggle('slow');
        });
    });

    $('#akronButton').on('click', function () {
        $('#mainInfoDiv').hide();
        $('#akronWeather').hide();
        $('#minneapolisInfoDiv').hide();
        $('#louisvilleInfoDiv').hide();
        $('#akronInfoDiv').show();     

        $('#akronWeatherButton').on('click', function () {
            $('#akronWeather').toggle('slow');
        });
    });

    $('#minneapolisButton').on('click', function () {
        $('#mainInfoDiv').hide();
        $('#minneapolisWeather').hide();
        $('#louisvilleInfoDiv').hide();
        $('#akronInfoDiv').hide();
        $('#minneapolisInfoDiv').show();

        $('#minneapolisWeatherButton').on('click', function () {
            $('#minneapolisWeather').toggle('slow');
        });
    });

    $('#louisvilleButton').on('click', function () {
        $('#mainInfoDiv').hide();
        $('#minneapolisInfoDiv').hide();
        $('#akronInfoDiv').hide();
        $('#louisvilleWeather').hide();
        $('#louisvilleInfoDiv').show();

        $('#louisvilleWeatherButton').on('click', function () {
            $('#louisvilleWeather').toggle('slow');
        });
    });

    $(".table").hover(
        // in callback
        function () {
            $('.table').css("background-color", "WhiteSmoke");
        },
        // out callback
        function () {
            $('.table').css("background-color", "");
        }
    );

});