'use strict';

var app = app || {};

(function(scope){
    function Event(option){
		if (this.constructor === Event) {
			throw new Error("Can't instantiate abstract class!");
		}
        this.setTitle(option.title);
        this.setType(option.type);
        this.setDuration(option.duration);
        this.setDate(option.date);

        return this;
    }

    Event.prototype.getTitle = function(){
        return this._title;
    };

    Event.prototype.setTitle = function(title){
        validateString.call(this, title);
        this._title = title;

        return this;
    };

    Event.prototype.getType = function(){
        return this._type;
    };

    Event.prototype.setType = function(type){
        validateString.call(this, type);
        this._type = type;

        return this;
    };

    Event.prototype.getDuration = function(){
        return this._duration;
    };

    Event.prototype.setDuration = function(duration){
        validateNumber.call(this, duration);
        this._duration = duration;

        return this;
    };

    Event.prototype.getDate = function(){
        return this._date;
    };

    Event.prototype.setDate = function(date){
        if(checkInstance.call(this, date, Date)){
            this._date = date;
        } else{
            throw new Error("Obj is not instance of Date!");
        }
        //validateIsCorrectInstance.call(this, date, Date);


        return this;
    };


    scope._Event = Event;

    return Event;

}(app));