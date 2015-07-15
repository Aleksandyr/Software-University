'use strict';

function solve(input) {
    var newTable = [];
    var result = {'&': 0, '*': 0, '#': 0, '!': 0, 'wallHits': 0};
    for (var i = 1; i < input.length; i += 1) {
        var move = input[0].trim().split(',');
        newTable[i - 1] = input[i] = input[i].trim().split(',');
    }


    //for(var i = 0; i < move.length; i += 1){
    //    var currMove = move[i];
        for(var row = 0; row < newTable.length; row += 1){
            for(var col = 0; col < newTable[row].length; col += 1){
                //if(currMove == 'up'){
                //    row -= 1;
                //} else if(currMove == 'down'){
                //    row += 1;
                //} else if(currMove == 'left'){
                //    col -= 1;
                //} else{
                //    col += 1;
                //}
                //
                //if(row < 0 || row >= newTable[i].length - 1){
                //    row = 0;
                //    result.wallHits++;
                //    continue;
                //}
                //if(col < 0 || col >= newTable[i].length - 1){
                //    col = 0;
                //    result.wallHits++;
                //    continue;
                //}
                console.log(newTable[row][col]);
            }
        }
    //}

}
solve(['right, up, up, down',
    'asdf, as{#}aj{g}dasd, kjldk{}fdffd, jdflk{#}jdfj',
    'tr{X}yrty, zxx{*}zxc, mncvnvcn, popipoip',
    'poiopipo, nmf{X}d{X}ei, mzoijwq, omcxzne']);