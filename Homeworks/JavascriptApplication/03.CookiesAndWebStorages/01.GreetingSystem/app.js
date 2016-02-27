'use strict';

(function(){
    function login(){
        var username = $('#username').val();
        localStorage.setItem('username', username);

        localStorage.removeItem('visitCount');
        sessionStorage.removeItem('visitCount');
    }

    function reLogin(){
        localStorage.removeItem('username');
        login();
        $('form').show();
    }

    if(!localStorage['visitCount']){
        localStorage.setItem('visitCount', 0);
    }

    if(!sessionStorage['visitCount']){
        sessionStorage.setItem('visitCount', 0);
    }

    localStorage['visitCount']++;
    sessionStorage['visitCount']++;

    $('<div>').text('Total visits ' + localStorage['visitCount']).appendTo('#wrapper');
    $('<div>').text('Session visits ' + sessionStorage['visitCount']).appendTo('#wrapper');

    if(localStorage['username']){
        $('form').hide();
        $('#greeting').text('Hello ' + localStorage['username'] + '!');
        $('#reenterName').on('click', reLogin);
    } else{
        $('#loginButton').on('click', login);
    }
}());
