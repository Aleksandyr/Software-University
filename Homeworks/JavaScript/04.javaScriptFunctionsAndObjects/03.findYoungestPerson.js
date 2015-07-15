'use strict';

var people = [
    { firstname : 'George', lastname: 'Kolev', age: 32, hasSmartphone: false },
    { firstname : 'Vasil', lastname: 'Kovachev', age: 40, hasSmartphone: true },
    { firstname : 'Bay', lastname: 'Ivan', age: 81, hasSmartphone: true },
    { firstname : 'Baba', lastname: 'Ginka', age: 40, hasSmartphone: false }
];

function findYoungestPerson(arr){
    var min = Number.MAX_VALUE;
    var fullName = '';

    arr.forEach(function(arr){
        if(arr.age < min && arr.hasSmartphone){
            min = arr.age;
            fullName = arr.firstname + ' ' + arr.lastname;
        }
    });

    return fullName;
}

console.log(findYoungestPerson(people));