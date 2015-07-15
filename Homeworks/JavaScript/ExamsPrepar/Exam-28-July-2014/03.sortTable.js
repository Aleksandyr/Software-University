'use strict';

function solve(input){
    var table = [];
    var regex = /<td>([\d\.]+)<\/td>/;
    for(var i = 2; i < input.length - 1; i += 1){
      var match = regex.exec(input[i]);
        table.push({
            price: Number(match[1]),
            row: input[i]
        });
    }

    table.sort(function(x, y){
        if(x.price == y.price){
            return x.row.localeCompare(y.row);
        } else{
            return x.price - y.price;
        }
    });
    console.log(input[0]);
    console.log(input[1]);
    table.forEach(function(currRow){
        console.log(currRow.row);
    });
    console.log(input[input.length - 1]);
}

solve(['<table>',
'<tr><th>Product</th><th>Price</th><th>Votes</th></tr>',
'<tr><td>Vodka Finlandia 1 l</td><td>19.35</td><td>+12</td></tr>',
'<tr><td>Ariana Radler 0.5 l</td><td>1.19</td><td>+33</td></tr>',
'<tr><td>Laptop HP 250 G2</td><td>629</td><td>+1</td></tr>',
'<tr><td>Kamenitza Grapefruit 1 l</td><td>1.85</td><td>+7</td></tr>',
'<tr><td>Ariana Grapefruit 1.5 l</td><td>1.85</td><td>+7</td></tr>',
'<tr><td>Coffee Davidoff 250 gr.</td><td>11.99</td><td>+11</td></tr>',
'</table>']);