'use strict';

var arr = [
    "Pesho",
    4,
    4.21,
    { name : 'Valyo', age : 16 },
    { type : 'fish', model : 'zlatna ribka' },
    [1,2,3],
    "Gosho",
    { name : 'Penka', height: 1.65}
];

function extractObjects(obj){
    var result = [];

    for(var i in obj){
        if(typeof obj[i] === 'object' && obj[i].constructor != Array){
            result.push(obj[i]);
        }
    }

    return result;
}

console.log(extractObjects(arr));
