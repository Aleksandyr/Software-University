'use strict';

var app = app || {};

(function(scope){
    function Trainer(){
        scope.employee.apply(this, arguments);
        this.courses = [];
        this.feedbacks = [];

        return this;
    }

    Trainer.extends(scope.employee);

    Trainer.prototype.addFeedback  = function(feedBack){
        if(typeof feedBack === 'string' || feedBack instanceof String){
            this.feedbacks.push(feedBack);
        } else{
            throw new Error("Not instance of String");
        }
    };

    Trainer.prototype.addCourse  = function(course){
        if(course instanceof scope.course){
            this.courses.push(course);
        } else{
            throw new Error("Not instance of course!")
        }
    };

    scope.trainer = Trainer;

    return Trainer;

}(app));