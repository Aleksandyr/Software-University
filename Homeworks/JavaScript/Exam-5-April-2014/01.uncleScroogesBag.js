'use strict';

function solve(input){
    var gold = 0,
        silver = 0,
        bronze = 0,
        coins = 0;

    for(var i = 0; i < input.length; i += 1) {
        var lineStr = input[i].split(" ");
        var coinStr = lineStr[0].trim();
        var currNum = lineStr[1].trim();
        if(currNum < 0 || !(currNum%1===0) || (coinStr.toUpperCase() !== "COIN")) {
            continue;
        } else{
            coins += parseInt(currNum);
        }
    }

    gold += Math.floor(coins / 100);
    silver += Math.floor(coins / 10) % 10;
    bronze += (coins % 10);

    console.log('gold : ' + gold);
    console.log('silver : ' + silver);
    console.log('bronze : ' + bronze);

}

//solve(['Coin 1','coin 2','coin 5.00','coin 10','coin 20','coin 50','coin 100','coin 200','coin 500','cigars 1']);
solve(['coin 1', 'coin 23111.20', 'COiN 1001']);