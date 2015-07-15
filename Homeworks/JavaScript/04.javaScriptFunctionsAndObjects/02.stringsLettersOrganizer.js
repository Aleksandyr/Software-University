'use strict';

function sortLetters(str, isAscending){
    if(isAscending) {
        str = str.split('').sort(function (x, y){
            return x.toLowerCase() > y.toLowerCase();
        });
    } else{
        str = str.split('').sort(function (x, y){
            return x.toLowerCase() < y.toLowerCase();
        });
    }

   return str.join('');
}


console.log(sortLetters('HelloWorld', true));
console.log(sortLetters('HelloWorld', false));