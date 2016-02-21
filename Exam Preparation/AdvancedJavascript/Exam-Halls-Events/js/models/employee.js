'use strict';

var app = app || {};

(function(scope){
    function Employee(name, workHours){
        this.setName(name);
        this.setWorkHours(workHours);

        return this;
    }

    Employee.prototype.getName = function(){
        return this._name;
    };

    Employee.prototype.setName = function(name){
        validateString.call(this, name);
        this._name = name;

        return this;
    };

    Employee.prototype.getWorkhours = function(){
        return this._workHours;
    };

    Employee.prototype.setWorkHours = function(workHours){
        validateNumber.call(this, workHours);
        this._workHours = workHours;

        return this;
    };

    scope.employee = Employee;

    return Employee;

}(app));