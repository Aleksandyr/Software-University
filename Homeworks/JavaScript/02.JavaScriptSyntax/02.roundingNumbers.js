'use strict'

function roundNumber(value){
    return Math.floor(value) + "\n" + Math.round(value);
}

console.log(roundNumber(22.7));
console.log();
console.log(roundNumber(12.3));
console.log();
console.log(roundNumber(58.7));