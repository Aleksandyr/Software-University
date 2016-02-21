'use strict';

var app = app || {};

(function(scope) {
    function Party(option) {
        scope._Event.call(this, option);
        this.setIsCatered(option.isCatered);
        this.setIsBirthday(option.isBirthday);
        this.setOrganiser(option.organiser);

        return this;
    }

    Party.extends(scope._Event);


    Party.prototype.checkIsCatered = function(){
        return this._isCatered;
    };

    Party.prototype.setIsCatered = function(isCatered){
        var convertedValue = convertBooleanValue.call(this, isCatered);
        this._isCatered = convertedValue;

        return this;
    };

    Party.prototype.checkIsBirthday = function(){
        return this._isBirthday;
    };

    Party.prototype.setIsBirthday = function(isBirthday){
        var convertedValue = convertBooleanValue.call(this, isBirthday);
        this._isBirthday = convertedValue;

        return this;
    };

    Party.prototype.getOrganiser = function(){
        return this._organiser;
    };

    Party.prototype.setOrganiser = function(organiser){
        if(checkInstance.call(this, organiser, scope.employee)) {
            this._organiser = organiser;
        } else{
            throw new Error("Obj is not instance of employee");
        }

        return this;
    };

    scope.party = Party;

    return Party;
}(app));