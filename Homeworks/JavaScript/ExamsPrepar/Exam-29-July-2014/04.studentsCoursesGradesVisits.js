'use strict';

function solve(input){

    var courses = {};
    for(var i = 2; i < input.length - 1; i += 1){
        var allStudentInfo = input[i].split(/[\s]?\|[\s]?/g);
        var course = allStudentInfo[1].trim();
        var name = allStudentInfo[0].trim();
        var grade = Number(allStudentInfo[2].trim());
        var visits = Number(allStudentInfo[3].trim());

        if(!courses[course]){
            courses[course] = {
                'avgGrade': 0,
                'avgVisits': 0,
                'students': [],
                'countInputs': 0
            };
        }

        courses[course].avgGrade += grade;
        courses[course].avgVisits += visits;
        if(courses[course].students.indexOf(name) == -1){
            courses[course].students.push(name);
        }
        courses[course].countInputs += 1;
    }

    var courseKeys = Object.keys(courses).sort();
    var outputArr = {};

    for(var j = 0; j < courseKeys.length; j += 1){
        var currCourse = courseKeys[j];
        outputArr[currCourse] = courses[currCourse];
        outputArr[currCourse].students.sort();
        outputArr[currCourse].avgGrade = Number((outputArr[currCourse].avgGrade /
        outputArr[currCourse].countInputs).toFixed(2));
        outputArr[currCourse].avgVisits = Number((outputArr[currCourse].avgVisits /
        outputArr[currCourse].countInputs).toFixed(2));
        delete outputArr[currCourse].countInputs;
    }

    console.log(JSON.stringify(outputArr));
}

solve(['Peter Nikolov | PHP  | 5.50 | 8',
    'Maria Ivanova | Java | 5.83 | 7',
    'Ivan Petrov   | PHP  | 3.00 | 2',
    'Ivan Petrov   | C#   | 3.00 | 2',
    'Peter Nikolov | C#   | 5.50 | 8',
    'Maria Ivanova | C#   | 5.83 | 7',
    'Ivan Petrov   | C#   | 4.12 | 5',
    'Ivan Petrov   | PHP  | 3.10 | 2',
    'Peter Nikolov | Java | 6.00 | 9'
]);