'use strict';
$(function(){
    $('#btn').on('click', function(e){
        var className = $("#class_name").val();
        var color = $("#color").val();

        if(className){
            $('.' + className).css('background', color);
        }

        e.preventDefault();
    });
}());
