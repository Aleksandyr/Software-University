'use strict';

var app = app || {};

(function(scope){
    function Course(name, numberOfLectures){
        this.setName(name);
        this.setNumberOfLectures(numberOfLectures);

        return this;
    }

    Course.prototype.getName = function(){
        return this._name;
    };

    Course.prototype.setName = function(name){
        validateString.call(this, name);
        this._name = name;

        return this;
    };

    Course.prototype.getNumberOfLectures = function(){
        return this._numberOfLectures;
    };

    Course.prototype.setNumberOfLectures = function(numberOfLectures){
        validateNumber.call(this, numberOfLectures);
        this._numberOfLectures = numberOfLectures;

        return this;
    };

    scope.course = Course;

    return Course;

}(app));