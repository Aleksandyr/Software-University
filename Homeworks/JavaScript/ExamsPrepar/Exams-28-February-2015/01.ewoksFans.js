'use strict';

function solve(args){
    var item,
        startDate,
        dateParts,
        date,
        min = new Date('January 1, 1900'),
        breakPoint = new Date('May 25, 1973'),
        max = new Date('January 1, 2015'),
        dateArray = [],
        hasHater = false,
        hasFan = false;

    for(item in args){
        startDate = args[item];
        dateParts = startDate.split('.');
        date = new Date(dateParts[2], (dateParts[1] - 1), dateParts[0]);
        if(date > min && date < max){
            if(date < breakPoint){
                hasHater = true;
            }
            if(date >= breakPoint){
                hasFan = true;
            }
            dateArray.push(date);
        }
    }

    return dateArray + '\n' + hasFan + '\n' + hasHater;
}

console.log(solve(['22.03.2014']));

