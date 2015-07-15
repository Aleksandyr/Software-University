'use strict'

Array.prototype.removeItem = function(item){
    for(var i = 0; i < this.length; i ++){
        if(item === this[i]){
            this.splice(i, 1);
        }
    }
}

var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];
arr.removeItem(1);
console.log(arr);

var secArr = ['hi', 'bye', 'hello' ];
secArr.removeItem('hi');
console.log(secArr);