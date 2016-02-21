'use strict';

var app = app || {};

(function(scope) {
    function Lecture(option) {
        scope._Event.call(this, option);
        this.setTrainer(option.trainer);
        this.setCourse(option.course);

        return this;
    }

    Lecture.extends(scope._Event);


    Lecture.prototype.getTrainer = function(){
        return this._trainer;
    };

    Lecture.prototype.setTrainer = function(trainer){
        if(checkInstance.call(this, trainer, scope.trainer)) {
            this._trainer = trainer;
        } else{
            throw new Error("Obj is not instance of Trainer")
        }

        return this;
    };

    Lecture.prototype.getCourse = function(){
        return this._course;
    };

    Lecture.prototype.setCourse = function(course){
        if(checkInstance.call(this, course, scope.course)) {
            this._course = course;
        } else{
            throw new Error("Obj is not instance of Course");
        }

        return this;
    };

    scope.lecture = Lecture;

    return Lecture;
}(app));