'use strict';

function solve(input) {
    var firstNum = Number(input[0]);
    var secondNum = Number(input[1]);
    if (firstNum <= secondNum) {
        console.log('<ul>');
        for(var i = firstNum; i <= secondNum; i += 1){
            var number = i.toString();
            var isRakiaNum = false;
            var length = input[0].length;

            for(var j = 0; j < length - 1; j += 1){
                var firstCheckNum = number[j] + '' + number[j + 1];
                for(var k = 0; k < length - 1; k += 1){
                    var secondCheckNum = number[k] + '' + number[k + 1];
                    if(firstCheckNum  == secondCheckNum && Math.abs(j - k) >= 2){
                        isRakiaNum = true;
                    }
                }
            }
            if(isRakiaNum){
                console.log('<li><span class=\'rakiya\'>' + number + '</span><a href=\"view.php?id=' + number + '>View</a></li>');
            } else{
                console.log('<li><span class=\'num\'>' + number + '</span></li>');
            }
        }
        console.log('</ul>');
    }
}

solve(['11210', '11215']);