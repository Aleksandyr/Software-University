'use strict';

var app = app || {};

(function(scope){
    function Hall(name, capacity){
        this.setName(name);
        this.setCapacity(capacity);
        this.parties = [];
        this.lectures = [];

        return this;
    }

    Hall.prototype.getName = function(){
        return this._name;
    };

    Hall.prototype.setName = function(name){
        validateString.call(this, name);
        this._name = name;

        return this;
    };

    Hall.prototype.getCapacity = function(){
        return this._capacity;
    };

    Hall.prototype.setCapacity = function(capacity){
        validateNumber.call(this, capacity);
        this._capacity = capacity;

        return this;
    };

    Hall.prototype.addEvent = function(event){
        if(checkInstance.call(this, event, scope.lecture)){
            this.lectures.push(event);
        } else if(checkInstance.call(this, event, scope.party)){
            this.parties.push(event);
        } else{
            throw new Error("not instance of lecture or party!");
        }
    };

    scope.hall = Hall;

    return Hall;

}(app));