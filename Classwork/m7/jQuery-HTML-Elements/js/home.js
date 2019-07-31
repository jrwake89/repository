$(document).ready(function() {
    alert("I'm Ready");
    $('H1').css('text-align', 'center');
    $('H2').css('text-align', 'center');
    $('#yellowHeading').prepend('H2').text('Yellow Team');
    $('#yellowTeamList').append('<li>Joseph Banks</li>');
    $('#yellowTeamList').prepend('<li>Simon Jomes</li>');
    $('#oops').hide('H1');
    $('#footerPlaceholder').remove('H2');
    $('#footer').append('p').text("My name is Joshua Wakefield.  If you'd like to contact me my e-mail is jrwake89@gmail.com");
    $('#footer').css({ 'font-family': 'Courier', 'font-size': '24px' });
    $('H1').removeClass();  
    $('H1').addClass('page-header');
});