'use strict';

function menu() {
    var button = document.getElementById('StartButton');
    var menu = document.getElementById('SplashScreen');
    var canvas = document.getElementById('canvas');

    menu.style.display = 'none';
    canvas.style.display = 'block';

    var script = document.createElement('script');
    script.src += 'scripts/main.js';
    document.getElementsByTagName('body')[0].appendChild(script);
    //console.log(document.getElementsByTagName('body')[0]);
};