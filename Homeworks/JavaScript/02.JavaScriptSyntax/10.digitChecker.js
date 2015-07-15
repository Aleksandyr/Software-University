'use strict'

function checkDigit(value){
    return Math.floor(value / 100) % 10 == 3;
}

console.log(checkDigit(1235));
console.log(checkDigit(25368));
console.log(checkDigit(123456));