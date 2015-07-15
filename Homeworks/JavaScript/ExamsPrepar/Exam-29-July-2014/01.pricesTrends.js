'use strict';

function solve(input){
    console.log('<table>');
    console.log('<tr><th>Price</th><th>Trend</th></tr>');
    if(input.length != 0){
        console.log('<tr><td>' + parseFloat(input[0]).toFixed(2) + '</td><td><img src=\"fixed.png\"/></td></td>');
    }

    var trend = '';
    for(var i = 1; i < input.length; i += 1){
        var number = Number(parseFloat(input[i]).toFixed(2));
        var prevNum = Number(parseFloat(input[i - 1]).toFixed(2));
        if(number > prevNum){
            trend = 'up';
        } else if(number < prevNum){
            trend = 'down';
        } else{
            trend = 'fixed';
        }
        console.log('<tr><td>' + number.toFixed(2) + '</td><td><img src=\"' + trend + '.png\"/></td></td>');
    }
    console.log('</table>')
}

solve(['36.333',
    '36.5',
    '37.019',
    '35.4',
    '35',
    '35.001',
    '36.225']);