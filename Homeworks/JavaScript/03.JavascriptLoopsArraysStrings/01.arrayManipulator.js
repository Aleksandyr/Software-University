'use strict'

function arrayManipulator(arr){
    var currArr = [];
    var max = Number.MIN_VALUE;
    var min = Number.MAX_VALUE;
    var counter = 0;
    var mostFreqNum;
    var maxCounter = Number.MIN_VALUE;
    for(var i = 0; i < arr.length; i++){
        if(!isNaN(arr[i])){
            currArr.push(arr[i]);
        }
    }

    for(var i = 0; i < currArr.length; i++){
        if(currArr[i] > max){
            max = currArr[i];
        }

        if(currArr[i] < min){
            min = currArr[i];
        }

        for(var j = 0; j < currArr.length - 1; j++){
            if(arr[i] == arr[j]){
                counter++;
            }
        }
        if(counter > maxCounter){
            maxCounter = counter;
            mostFreqNum = currArr[i];
        }
        counter = 0;
    }

    for(var i = 0; i < currArr.length - 1; i++){
        for(var j = 0; j < currArr.length - 1; j++){
            if(currArr[j] < currArr[j + 1]){
                var change = currArr[j];
                currArr[j] = currArr[j + 1];
                currArr[j + 1] = change;
            }
        }
    }

    return 'Min number:' + min + '\n' + 'Max number:' + max + '\n' + 'Most frequent number:' + mostFreqNum + '\n' +
        '[' + currArr + ']';
}

console.log(arrayManipulator(["Pesho", 2, "Gosho", 12, 2, "true", 9, undefined, 0, "Penka", { bunniesCount : 10}, [10, 20, 30, 40]]));