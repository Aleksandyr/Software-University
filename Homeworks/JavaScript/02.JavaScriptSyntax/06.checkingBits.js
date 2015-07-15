'use strict'

function bitChecker(value){
    var bit = (value >> 3) & 1;
    return bit == 1;
}

console.log(bitChecker(333));
console.log(bitChecker(425));
console.log(bitChecker(2567564754));