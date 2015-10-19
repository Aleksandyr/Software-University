'use strict';

function add(a){
    var f = function (b){
        return add(a + b);
    };

    f.valueOf = f.toString = function(){
        return a;
    };

    return f;
}
var addTwo = add(2);
console.log(+addTwo);
console.log(+addTwo(3));
console.log(+addTwo(3)(5));