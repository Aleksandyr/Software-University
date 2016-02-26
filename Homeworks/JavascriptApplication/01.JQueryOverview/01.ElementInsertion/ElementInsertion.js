'use strict';

$(function(){
    $("#element").before($("<div>").text("first element"));
    $("#element").after($("<div>").text("second element"));
}());