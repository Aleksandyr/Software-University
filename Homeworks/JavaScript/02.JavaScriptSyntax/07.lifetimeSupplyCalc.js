'use strict'

function calcSupply(){
    var yourAge = arguments[0];
    var yourMaxAge = arguments[1];
    var favouriteFood = arguments[2];
    var foodPerDay = arguments[3];

    var daysBetweenAge = (yourMaxAge - yourAge) * 365;
    return daysBetweenAge * foodPerDay + "kg of "+ favouriteFood + " would be enough until I am " +
        yourMaxAge + " years old.";
}

console.log(calcSupply(38, 118, "chocolate", 0.5));
console.log(calcSupply(20, 87, "fruits", 2));
console.log(calcSupply(16, 102, "nuts", 1.1));

