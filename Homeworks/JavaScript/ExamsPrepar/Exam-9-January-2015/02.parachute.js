'use strict';

function solve(input){
    var inputLine, pos;
    var ahaa = false;

    for(var i in input){
        inputLine = input[i];

        if(ahaa){
            for(var c in inputLine){
                if(inputLine[c] === '>'){
                    pos += 1;
                } else if(inputLine[c] === '<'){
                    pos -= 1;
                }
            }

            switch (inputLine[pos]){
                case '_':
                    console.log("Landed on the ground like a boss!");
                    console.log(i + ' ' + pos);
                    return;
                    break;
                case '~':
                    console.log("Drowned in the water like a cat!");
                    console.log(i + ' ' + pos);
                    return;
                    break;
                case '/':
                case '|':
                case '\\':
                    console.log("Got smacked on the rock like a dog!");
                    console.log(i + ' ' + pos);
                    return;
                    break;
                default :
                    break;
            }
        }

        if(!ahaa){
            pos = inputLine.indexOf('o');
            if(pos > - 1){
                ahaa = true;
            }
        }
    }
}

var input =
    [
        ">>>>>>>>>>>o<<<<<<<<<<<<<",
        "----------~~~------------",
        "--------~/~~~\\~----------",
        "-------~/~---~\\~---------",
        "------~/~-----~\\~--------",
        "-----~/~-------~\\~-------",
        "----~/~---------~\\~------",
        "---~/~-----------~\\~-----",
        "--~/~-------------~\\~----",
        "-~/~---------------~\\~---"
    ];

solve(input);
