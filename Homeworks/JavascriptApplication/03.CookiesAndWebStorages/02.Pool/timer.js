'use strict';

var sessTimer = setInterval(Timer, 1000);

$(function() {
    if (!localStorage.timer) {
        sessionStorage.setItem('timer', 300000);
        localStorage.setItem('timer', 300000)
    } else {
        sessionStorage.setItem('timer', localStorage.getItem('timer'))
    }

    Timer();
})

function Timer() {
    var time = parseInt(sessionStorage.getItem('timer'));
    time -= 1000;

    var min = Math.floor(time / 60000),
        sec = (time % 60000) / 1000;
    $('#timer').text(min + ':' + sec);

    if (time <= 0) {
        alert('No time!');
        sessionStorage.clear();
        sessionStorage.clear();
        window.clearInterval(sessTimer);
        getAnswers();
    } else {
        sessionStorage.setItem('timer', time);
        localStorage.setItem('timer', time);
    }
}