'use strict'

function scoreModification(arr){
    var curArr = [];
    for(var i = 0; i < arr.length; i++){
        if(arr[i] >= 0 && arr[i] <= 400){
            curArr.push(Math.round((arr[i] * 0.8) * 10) / 10);
        }
    }

    curArr.sort(function (x, y){
        return x > y;
    })

    return curArr.join(', ');
}

console.log(scoreModification([200, 120, 23, 67, 350, 420, 170, 212, 401, 615, -1]));