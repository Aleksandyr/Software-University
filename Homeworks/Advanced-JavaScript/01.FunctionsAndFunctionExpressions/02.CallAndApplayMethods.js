'use strict';

function printArgsInfo(){
    for (var argument in arguments) {
        var currArgument = arguments[argument];
        var currArgumentType = typeof(arguments[argument]);

        if(Array.isArray(currArgument)){
            currArgumentType = 'array';
        }
        console.log(currArgument + ' ' + '(' + currArgumentType + ')');
    }
}

printArgsInfo.call();
printArgsInfo.call(this, 2, ['asd'], undefined);
printArgsInfo.apply();
printArgsInfo.apply(this, [2,['asd'], undefined]);
