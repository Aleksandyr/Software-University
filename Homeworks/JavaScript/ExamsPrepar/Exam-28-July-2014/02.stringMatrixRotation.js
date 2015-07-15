'use strcit';

function solve(input){
    var matrix = [];
    var degAsString = input[0].match(/\d+/g);
    var deg = Number(degAsString[0]);
    var turns = deg % 360 / 90;
    var maxLength = 0;

    matrix = loadMatrix(input);
    for(var i = 0; i < turns; i++){
        matrix = rotateMatrix(matrix);
    }
    printMatrix(matrix);


    function loadMatrix(input){
        for(var i = 1; i < input.length; i += 1){
            if(input[i].length > maxLength){
                maxLength = input[i].length;
            }
        }

        for(var i = 1; i < input.length; i += 1){
            var row = input[i] + Array(maxLength - input[i].length + 1).join(' ');
            matrix.push(row.split(''));
        }

        return matrix;
    }

    function rotateMatrix(matrix){
        var maxRow = matrix.length;
        var maxCol = matrix[0].length;
        var result = new Array(maxCol);
        for(var col = 0; col < maxCol; col += 1){
            result[col] = new Array(maxRow);
            for(var row = 0; row < maxRow; row += 1){
                result[col][maxRow - row] = matrix[row][col];
            }
        }
        return result;
    }

    function printMatrix(matrix){
        for(var i = 0; i < matrix.length; i++){
            console.log(matrix[i].join(''));
        }
    }
}

solve(['[Rotate(180)',
    'hello',
    'softuni',
    'exam']);