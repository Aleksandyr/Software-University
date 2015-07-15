'use strict'

function calcCylinderVol(){
    var r = arguments[0];
    var h = arguments[1];

    return Math.round((Math.PI * (r * r) * h) * 1000) / 1000;
}

console.log(calcCylinderVol(2, 4));
console.log(calcCylinderVol(5, 8));
console.log(calcCylinderVol(12, 3));