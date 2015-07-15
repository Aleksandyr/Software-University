'use strict';

function solve(input){
    for(var i = 0; i < input.length; i += 1){
        var currLine = input[i].split(/\s+/g);
        var carModel = currLine[0];
        var fuelType = currLine[1];
        var routNum = Number(currLine[2]);
        var luggageWeight = Number(currLine[3]);

        var fuelPerHundredKm = 0;
        if(fuelType === 'gas'){
            fuelPerHundredKm = 1.2 * 10;
        } else if(fuelType == 'petrol'){
            fuelPerHundredKm = 10;
        } else{
            fuelPerHundredKm = 0.8 * 10;
        }

        var totalFuelConsump = calcFuelConsumption(routNum, luggageWeight, fuelPerHundredKm);
        console.log(carModel + ' ' + fuelType + ' ' + routNum + ' ' + totalFuelConsump);
    }

    function calcFuelConsumption(routNum, luggageWeight, fuelPerHundredKm){
        var clearRoud = 0,
            snowyRoad = 0;
        if(routNum == 1){
            clearRoud = 100;
            snowyRoad = 10;
        } else {
            clearRoud = 65;
            snowyRoad = 30;
        }

        luggageWeight = (luggageWeight * 0.01) + fuelPerHundredKm;
        var consumption = (clearRoud + snowyRoad) * (luggageWeight / 100);
        var extraSnowConsump = 0.3 * luggageWeight;
        extraSnowConsump = snowyRoad * (extraSnowConsump / 100);
        return Math.round(consumption + extraSnowConsump);
    }
}

solve(['BMW petrol 1 320.5',
    'Golf petrol 2 150.75',
    'Lada gas 1 202',
    'Mercedes diesel 2 312.54']);