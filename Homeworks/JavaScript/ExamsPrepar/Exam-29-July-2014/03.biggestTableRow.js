'use strict';

function solve(input){
    var max = -Infinity;
    var numsWithBigSum = [];
    var result = '';
    var haveDate = false;
    for(var i = 2; i < input.length - 1; i += 1) {
        var nums = input[i].match(/\-?[\d\.]+/g);

        var sum = 0;
        if (nums != undefined) {
            haveDate = true;
            for (var j = 0; j < nums.length; j += 1) {
                sum += parseFloat(nums[j]);
            }
            if (sum > max) {
                max = sum;
                numsWithBigSum = nums;
            }
        }
    }
    if(!haveDate){
        console.log('no data');
    } else{
        result += max + ' = ';
        for(var k = 0; k < numsWithBigSum.length; k += 1){
            result += numsWithBigSum[k] + ' + ';
        }
        console.log(result.slice(0, result.length - 3));
    }
}

solve(['<table>',
    '<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>',
    '<tr><td>Sofia</td><td>3</td><td>2</td><td>1</td></tr>',
    '<tr><td>Sofia</td><td>-</td><td>-</td><td>-</td></tr>',
    '</table>'
]);