'use strict';

function solve(input){
    var regex = /<p>(.*?)<\/p>/g;
    var mathcArr;
    var output = '';
    while(mathcArr = regex.exec(input[0])){
        var match = mathcArr[1];

        match = match.replace(/[^a-z0-9]+/g, ' ');
        for(var i = 0; i < match.length; i += 1){
            output += changeLetter(match[i]);
        }
    }
    console.log(output);

    function changeLetter(str){
        var currCharCode = str.charCodeAt(0);
        if(currCharCode >= 97 && currCharCode <= 109){
            currCharCode += 13;
        } else if(currCharCode > 109 && currCharCode <= 122){
            currCharCode -= 13;
        }
        return String.fromCharCode(currCharCode);
    }
}

solve(['<html><head><title></title></head><body><h1>hello</h1><p>znahny!@#%&&&&****</p><div><button>dsad</button></div><p>grkg^^^^%%%)))([]12</p></body></html>']);