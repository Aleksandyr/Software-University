'use strict';
function solve(input){
    var maxJump = Number(input[0]);
    var jumpsAllowed = Number(input[1]);
    var jumpDistFlea = [];
    var name = [];
    var winner = '';

    for(var i = 0; i < 2; i += 1){
        for(var j = 0; j < jumpsAllowed; j += 1){
            process.stdout.write('#');
        }
        console.log();
    }

    for(var i = 2; i < input.length; i += 1) {
        var currFlea = input[i].split(',');
        jumpDistFlea.push(Number(currFlea[1].trim()));
        name.push(currFlea[0]);
    }
    for(var i = 0; i < maxJump; i += 1){
        for(var j = 0; j < jumpDistFlea.length; j += 1){
            jumpDistFlea[j] += jumpDistFlea[j];
            if(jumpDistFlea[i] >= (jumpsAllowed)){
                winner = name[j];

                for(var k = 0; k < name.length; k += 1){
                    for(var m = 1; m < jumpsAllowed; m += 1){
                        process.stdout.write('.');
                        if(jumpDistFlea[k] == m){
                            process.stdout.write(name[k][0].toUpperCase());
                        }
                    }
                    console.log();
                }
                for(var i = 0; i < 2; i += 1){
                    for(var j = 0; j < jumpsAllowed; j += 1){
                        process.stdout.write('#');
                    }
                    console.log();
                }
                console.log('Winner: ' + winner);
                return
            }
        }
    }
}

solve(['3','5','cura, 1','Pepi, 1','UlTraFlee, 1','BOIKO, 1']);