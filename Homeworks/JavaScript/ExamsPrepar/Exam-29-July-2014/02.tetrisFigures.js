'use strict';

function solve(input){
    var figures = {'I': 0, 'L': 0, 'J': 0, 'O': 0, 'Z': 0, 'S': 0, 'T': 0};

    for(var i = 0; i < input.length; i += 1){
        for(var j = 0; j < input[i].length; j += 1){
            if(input[i][j] == 'o'){
                checkElemOfFig(i, j);
            }
        }
    }

    function checkElemOfFig(row, col){
        checkElem('I', row, col, 1, 0, 2, 0, 3, 0);
        checkElem('L', row, col, 1, 0, 2, 0, 2, 1);
        checkElem('J', row, col, 1, 0, 2, 0, 2, -1);
        checkElem('O', row, col, 1, 0, 1, 1, 0, 1);
        checkElem('Z', row, col, 0, 1, 1, 1, 1, 2);
        checkElem('S', row, col, 0, 1, 1, 0, 1, -1);
        checkElem('T', row, col, 0, 1, 0, 2, 1, 1);
    }

    function checkElem(elem, row, col, firstRow, firstCol, secondRow, secondCol, thirdRow, thirdCol){
        var maxCol = Math.max(firstCol, secondCol, thirdCol);
        var maxRow = Math.max(firstRow, secondRow, thirdRow);
        var minCol = Math.min(firstCol, secondCol, thirdCol);

        if(input[row + maxRow] == undefined ||
            input[row + maxRow][col + maxCol] == undefined ||
            input[row][col + minCol] == undefined){
            return false;
        }

        if(input[row][col] == input[row + firstRow][col + firstCol] &&
            input[row][col] == input[row + secondRow][col + secondCol] &&
            input[row][col] == input[row + thirdRow][col + thirdCol]){
            figures[elem] += 1;
        }
    }

    console.log(JSON.stringify(figures));
}

solve(['--o--o-',
    '--oo-oo',
    'ooo-oo-',
    '-ooooo-',
    '---oo--'
]);