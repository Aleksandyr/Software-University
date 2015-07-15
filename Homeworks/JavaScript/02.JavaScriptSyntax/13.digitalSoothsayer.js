'use strict'

function soothsayer(years, progrLneguages, cities, cars){
    var year = years[Math.floor(Math.random() * years.length)];
    var progrLneguage = progrLneguages[Math.floor(Math.random() * progrLneguages.length)];
    var city = cities[Math.floor(Math.random() * cities.length)];
    var car = cars[Math.floor(Math.random() * cars.length)];
    return "You will work " + year + " years on " + progrLneguage + ".\nYou will live in " + city +
        " and drive " + car;
}

console.log(soothsayer([3, 5, 2, 7, 9], ["Java", "Python", "C#", "JavaScript", "Ruby"],
    ["Silicon Valley","London", "Las Vegas", "Paris", "Sofia"],["BMW","Audi","Lada","Skoda","Opel"]));
