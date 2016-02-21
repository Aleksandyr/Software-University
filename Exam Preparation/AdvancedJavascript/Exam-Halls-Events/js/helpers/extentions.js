Function.prototype.extends = function(parent){
    this.prototype = Object.create(parent.prototype);
    this.prototype.constructor = this;
};

function validateString(str){
    var regex = /^[a-zA-Z\s]*$/i;
    var isStringValid = str.search(regex);

    if(isStringValid == -1){
        throw new Error("Invalid string!");
    }
}

function validateNumber(num){
    var regex = /^[0-9]*$/i;
    var isStringValid = regex.test(num);

    if(isStringValid == -1){
        throw new Error("Invalid number!");
    }
}

function convertBooleanValue(val){
    if(val === false){
        return false;
    } else {
        return true;
    }
}

function checkInstance(currObj, currInst){
    if(currObj instanceof currInst){
        return true;
    }

    return false;
}